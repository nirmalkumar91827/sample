using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace window_employee
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ESTSERVER\\SQL2012;Initial Catalog=Interview;User ID=sa;password=est$123");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public Form1()
        {
            InitializeComponent();
        }
        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            adddetails.Visible = false;
            employeedetails.Visible = false;
            btnshow.Enabled = false;
            DisplayData();
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from employeedetails", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClearData();
            login.Visible = false;
            employeedetails.Visible = false;
            adddetails.Visible = true;
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            var radio = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if(radio=="Male")
            {
                radmale.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select skillid,skillsname from skills where Employeeid="+ txtid.Text +"", con);
            adapt.Fill(dt);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    string a = checkedListBox1.Items[j].ToString(); 
                    string skills = dt.Rows[i]["skillsname"].ToString();
                    if (a == skills)
                    {                      
                        checkedListBox1.SetItemChecked(j, true);
                    }
                }
            }
            dt.Clear();
        }
        private void ClearData()
        {
            txtid.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            radmale.Checked = false;
            radioButton2.Checked = false;
            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                {
                    checkedListBox1.SetItemChecked(j, false);
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearData();
            login.Visible = false;
            employeedetails.Visible = false;
            adddetails.Visible = true;
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            var radio = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (radio == "Male")
            {
                radmale.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select skillid,skillsname from skills where Employeeid=" + txtid.Text + "", con);
            adapt.Fill(dt);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    string a = checkedListBox1.Items[j].ToString();
                    string skills = dt.Rows[i]["skillsname"].ToString();
                    if (a == skills)
                    {
                        checkedListBox1.SetItemChecked(j, true);
                    }
                }
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            bool ismaleChecked = radioButton1.Checked;
            bool isfemaleChecked = radioButton2.Checked;
            string value = "";
            string a = "";
            if (txtname.Text == "")
            {
                MessageBox.Show("Please Provide Username!");
            }
            if (ismaleChecked)
            {
                value = radioButton1.Text;
            }
            if (isfemaleChecked)
            {
                value = radioButton2.Text;
                MessageBox.Show("Please Provide Gender!");
            }
            else
            {
                cmd = new SqlCommand("checklogin", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", txtname.Text);
                cmd.Parameters.AddWithValue("@gender", value);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                     a = Convert.ToString(dr["UserExists"]);
                }
                if (a == "true")
                {
                    MessageBox.Show("Use Can See Your Details,Click Show Button!");
                    btnshow.Enabled = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    txtname.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Provide Valid Details!");
                }
                con.Close();
                employeedetails.Visible = false;
                login.Visible = true;
                adddetails.Visible = false;
            }
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            login.Visible = false;
            employeedetails.Visible = false;
            adddetails.Visible = true;
        }
       
        private void btnsave_Click(object sender, EventArgs e)
        {
            string value = "";
            bool ismaleChecked = radmale.Checked;
            bool isfemaleChecked = radioButton2.Checked;
            var count = checkedListBox1.Items.Count;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Provide Name!");
                
            }
            if (ismaleChecked)
            {
                value = radmale.Text;
            }
            if (isfemaleChecked)
            {
                value = radioButton2.Text;

                MessageBox.Show("Please Provide Gender!");
            }
            if (!ismaleChecked||isfemaleChecked)
            {
                MessageBox.Show("Please Provide Gender!");
            }
            if (count != 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string str = (string)checkedListBox1.Items[i];
                        if (str == "")
                        {
                            MessageBox.Show("Please Select Skills!");
                        }
                    }
                }
            }
                cmd = new SqlCommand("InsertEmployee", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Dateofbirth", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@gender", value);
               // cmd.Parameters.AddWithValue("@Employeeid", DBNull.Value);
                SqlParameter Employeeid = new SqlParameter("@Employeeid", SqlDbType.BigInt);
                Employeeid.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Employeeid);
                cmd.ExecuteNonQuery();
                con.Close();
            
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {                             
                if (checkedListBox1.GetItemChecked(i))
                    {
                    cmd = new SqlCommand("InsertEmployeedetail", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    string str = (string)checkedListBox1.Items[i];
                    cmd.Parameters.AddWithValue("@id", Employeeid.Value);
                    cmd.Parameters.AddWithValue("@Skillsname", str);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                }           
                MessageBox.Show("Record Inserted Successfully");
            DisplayData();
            ClearData();
            login.Visible = false;
            employeedetails.Visible = true;
            adddetails.Visible = false;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string value = "";
            bool ismaleChecked = radmale.Checked;
            bool isfemaleChecked = radioButton2.Checked;
            var count = checkedListBox1.Items.Count;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Provide Name!");

            }
            if (ismaleChecked)
            {
                value = radmale.Text;
            }
            if (isfemaleChecked)
            {
                value = radioButton2.Text;

                MessageBox.Show("Please Provide Gender!");
            }
            if (!ismaleChecked || isfemaleChecked)
            {
                MessageBox.Show("Please Provide Gender!");
            }
            if (count != 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string str = (string)checkedListBox1.Items[i];
                        if (str == "")
                        {
                            MessageBox.Show("Please Select Skills!");
                        }
                    }
                }
            }
            cmd = new SqlCommand("updateemployee", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Employeeid", txtid.Text);
            cmd.Parameters.AddWithValue("@Dateofbirth", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@gender", value);
            cmd.ExecuteNonQuery();
            con.Close();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    cmd = new SqlCommand("updateskills", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    string str = (string)checkedListBox1.Items[i];
                    cmd.Parameters.AddWithValue("@Skillsname", str);
                    cmd.Parameters.AddWithValue("@Employeeid", txtid.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            MessageBox.Show("Record Updated Successfully");
            DisplayData();
            ClearData();
            login.Visible = false;
            employeedetails.Visible = true;
            adddetails.Visible = false;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearData();
            adddetails.Visible = false;
            employeedetails.Visible = false;
            login.Visible = true;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            ClearData();
            DisplayData();
            adddetails.Visible = false;
            employeedetails.Visible = false;
            login.Visible = true;
            btnshow.Enabled = true;
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            ClearData();
            DisplayData();
            adddetails.Visible = false;
            employeedetails.Visible = true;
            login.Visible = false;
        }
    }
}
