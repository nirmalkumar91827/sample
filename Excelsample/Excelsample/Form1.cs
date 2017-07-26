using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excelsample
{  
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ESTSERVER\\SQL2012;Initial Catalog=Interview;User ID=sa;password=est$123");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        Microsoft.Office.Interop.Excel.Application excel;
        Microsoft.Office.Interop.Excel.Workbook excelworkBook;
        Microsoft.Office.Interop.Excel.Worksheet excelSheet;
        Microsoft.Office.Interop.Excel.Range excelCellrange;
        Microsoft.Office.Interop.Excel.Sheets xlBigSheet;
        private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        String folderPath = @"F:\New folder\sample1.xlsx";

        public Form1()
        {
            InitializeComponent();
        }
        private void DisplayData()
        {
            con.Open();
            System.Data.DataTable dt = new System.Data.DataTable();
            adapt = new SqlDataAdapter("select * from customers", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            int i;
            int ColumnIndex = 0;
            System.Data.DataTable dt = new System.Data.DataTable();
            if (!File.Exists(folderPath))
            {
                FileStream fileStream = new FileStream(folderPath, FileMode.Create);
                fileStream.Close();
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("Mobile No");
                dt.Columns.Add("Address");
                dt.Rows.Add(txtid.Text, txtname.Text, txtage.Text, txtmobile.Text, txtaddress.Text);

                excel.Application.Workbooks.Add(Type.Missing);


                foreach (DataColumn col in dt.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[1, ColumnIndex] = col.ColumnName;
                }

                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow row = dt.Rows[i];
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        excel.Cells[i + 2, j + 1] = row.ItemArray[j].ToString();
                    }
                }
                excel.ActiveWorkbook.SaveCopyAs(folderPath);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
                txtid.Text = "";
                txtname.Text = "";
                txtage.Text = "";
                txtmobile.Text = "";
                txtaddress.Text = "";
            }
            else
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //  excelworkBook = excel.Workbooks.Open(folderPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                dt = new System.Data.DataTable();

                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("Mobile No");
                dt.Columns.Add("Address");
                dt.Rows.Add(txtid.Text, txtname.Text, txtage.Text, txtmobile.Text, txtaddress.Text);

                string filepath = folderPath;

                excel.Application.Workbooks.Add(Type.Missing);
                foreach (DataColumn col in dt.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[1, ColumnIndex] = col.ColumnName;
                }
                excelworkBook = excel.Workbooks.Open(folderPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlBigSheet = excelworkBook.Worksheets;
                mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)xlBigSheet.get_Item("Sheet1");
                Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                int colCount = range.Columns.Count;
                int rowCount = range.Rows.Count;

                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow row = dt.Rows[i];
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        excel.Cells[rowCount + 1, j + 1] = row.ItemArray[j].ToString();
                    }
                }
                excel.ActiveWorkbook.SaveCopyAs(folderPath);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
                txtid.Text = "";
                txtname.Text = "";
                txtage.Text = "";
                txtmobile.Text = "";
                txtaddress.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            int i;
            int ColumnIndex = 0;
            if (!File.Exists(folderPath))
            {
                FileStream fileStream = new FileStream(folderPath, FileMode.Create);
                fileStream.Close();
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                
                excel.Application.Workbooks.Add(Type.Missing);


                for (int k = 1; k < dataGridView1.Columns.Count + 1; k++)
                {
                    excel.Cells[1, k] = dataGridView1.Columns[k - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int l = 0; l < dataGridView1.Rows.Count - 1; l++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        excel.Cells[l + 2, j + 1] = dataGridView1.Rows[l].Cells[j].Value.ToString();
                    }
                }
                excel.ActiveWorkbook.SaveCopyAs(folderPath);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }
            else
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                string filepath = folderPath;

                excel.Application.Workbooks.Add(Type.Missing);
                // storing Each row and column value to excel sheet
                for (int l = 0; l < dataGridView1.Rows.Count - 1; l++)
                {
                    excelworkBook = excel.Workbooks.Open(folderPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlBigSheet = excelworkBook.Worksheets;
                    mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)xlBigSheet.get_Item("Sheet1");
                    Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                    int colCount = range.Columns.Count;
                    int rowCount = range.Rows.Count;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {                       
                        excel.Cells[rowCount + 1, j + 1] = dataGridView1.Rows[l].Cells[j].Value.ToString();
                    }
                    excel.ActiveWorkbook.SaveCopyAs(folderPath);
                    excel.ActiveWorkbook.Saved = true;
                    excel.Quit();
                }
            }
            
           
        }
    }
}
