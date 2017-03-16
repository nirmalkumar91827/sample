﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using dssi.Models;

namespace dssi.Controllers
{
    public class Default1Controller : Controller
    {
        string connection = "Data Source=WEB-SERVER\\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;password=fresher";
        SqlConnection conn = null;
        SqlCommand cmd = null;

        public ActionResult Index()
        {
            return View();
        }

        public string Save(string aaa, string bbb, string ccc, Int64 ddd, Int64 eee)
        {
            Class1 fff = new Class1();
            fff.name = aaa;
            fff.dob = bbb;
            fff.gender = ccc;
            fff.slider =ddd;
            fff.check = eee;

            return Save1(fff);
        }
        public string Save1(Class1 ffff)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("sp_dssisave", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@name", ffff.name));
                    cmd.Parameters.Add(new SqlParameter("@dob", ffff.dob));
                    cmd.Parameters.Add(new SqlParameter("@gender", ffff.gender));
                    cmd.Parameters.Add(new SqlParameter("@status", ffff.slider));
                    cmd.Parameters.Add(new SqlParameter("@check", ffff.check));
                    cmd.Parameters.Add(new SqlParameter("@activeflag", 1));

                    cmd.ExecuteNonQuery();
                    return "";
                }

            }
        }
        public ActionResult mygrid()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = null;
            SqlDataReader dr;
            List<Class1> lst = new List<Class1>();
            con.Open();
            using (cmd = new SqlCommand("dssi_grid", con))
            {

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Class1 obj = new Class1();
                    obj.id = Convert.ToInt64(dr["id"]);
                    obj.name = Convert.ToString(dr["name"]);
                    obj.dob = Convert.ToString(dr["DOB"]);
                    obj.gender = Convert.ToString(dr["gender"]);
                    obj.slider = Convert.ToInt64(dr["slider"]);
                    obj.check = Convert.ToInt64(dr["status"]);
                    lst.Add(obj);
                }
                var result = from value in lst
                             select new[]
            {
               "",
               "",
               value.id.ToString(),
               value.name.ToString(),
               value.dob.ToString(),
               value.gender.ToString(),
               value.slider.ToString(),
               value.check.ToString(),
            };
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult mygrid1()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = null;
            SqlDataReader dr;
            List<Class1> lst = new List<Class1>();
            con.Open();
            using (cmd = new SqlCommand("dssi_grid1", con))
            {

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Class1 obj = new Class1();
                    obj.name = Convert.ToString(dr["name"]);
                    obj.dob = Convert.ToString(dr["DOB"]);
                    obj.gender = Convert.ToString(dr["gender"]);
                    obj.slider = Convert.ToInt64(dr["slider"]);
                    obj.check = Convert.ToInt64(dr["status"]);
                    lst.Add(obj);
                }
                var result = from value in lst
                             select new[]
            {
               value.name.ToString(),
               value.dob.ToString(),
               value.gender.ToString(),
               value.slider.ToString(),
               value.check.ToString(),
            };
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }
        public string Update(string aaa, string bbb, string ccc, string ddd, string eee, string id)
        {
            Class1 fff = new Class1();
            fff.name = aaa;
            fff.dob = bbb;
            fff.gender = ccc;
            fff.slider = Convert.ToInt64(ddd);
            fff.check = Convert.ToInt64(eee);
            fff.id = Convert.ToInt64(id);

            return Update1(fff);
        }
        public string Update1(Class1 ffff)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("sp_dssigridupdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id",ffff.id));
                    cmd.Parameters.Add(new SqlParameter("@name", ffff.name));
                    cmd.Parameters.Add(new SqlParameter("@dob", ffff.dob));
                    cmd.Parameters.Add(new SqlParameter("@gender", ffff.gender));
                    cmd.Parameters.Add(new SqlParameter("@status", ffff.slider));
                    cmd.Parameters.Add(new SqlParameter("@check", ffff.check));

                    cmd.ExecuteNonQuery();
                    return "";
                }

            }
        }

        public string Delete(int id)
        {

            Class1 fff = new Class1();
            fff.id = Convert.ToInt16(id);
            return Delete1(fff);
        }

        public string Delete1(Class1 ffff)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = new SqlCommand("sp_dssigriddelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", ffff.id));
                    cmd.ExecuteNonQuery();
                    return "";
                }

            }
        }
    }
}
    

