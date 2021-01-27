using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Psychiatric
{
    public partial class addCustomer : Form
    {

        Database db = new Database();

        public addCustomer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = db.Read("SELECT Name FROM psychiatric.dbo.customers WHERE Name = N'"+textBox1.Text+"'");
            if (table.Rows.Count == 0)
            {
                if (textBox1.Text != "")
                {
                    db.Write("INSERT INTO psychiatric.dbo.customers VALUES (N'" + textBox1.Text + "')");
                    MessageBox.Show("تم التسجيل بنجاح", "نجاح");
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("من فضلك ادخل الأسم", "خطأ");
                }
            } else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل الأسم", "خطأ");
                } else
                {
                    MessageBox.Show("هذا الأسم مسجل", "خطأ");
                    return;
                }
            }
        }

        private void addCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
