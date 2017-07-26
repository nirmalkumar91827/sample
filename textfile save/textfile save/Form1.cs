using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textfile_save
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ESTSERVER\\SQL2012;Initial Catalog=Interview;User ID=sa;password=est$123");
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();          
        }
        String folderPath = @"F:\New folder\sample1.txt";
        private void btnsave_Click(object sender, EventArgs e)
        {
            var value = textBox1.Text;           
            FileStream fs = null;
            if (!File.Exists(folderPath))
            {
                fs = File.Create(folderPath);
                fs.Close();
            }
            fs = new FileStream(folderPath, FileMode.OpenOrCreate);
            StreamWriter str = new StreamWriter(fs);
            str.BaseStream.Seek(0, SeekOrigin.End);
            str.WriteLine(value);
            str.Flush();
            str.Close();
            fs.Close();
            textBox1.Text = "";
            
        }
        private void btnread_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(folderPath))
            {
                using (StreamReader tr = new StreamReader(folderPath))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(tr.ReadToEnd());
                    richTextBox1.Text = sb.ToString();
                }
            }
        }
    }
}

