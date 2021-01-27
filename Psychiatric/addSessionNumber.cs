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
    public partial class addSessionNumber : Form
    {
        Database db = new Database();
        public addSessionNumber()
        {
            InitializeComponent();
            comboBox2.DataSource = db.Read("SELECT Name FROM psychiatric.dbo.customers");
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Name";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable table = db.Read("SELECT COUNT(*) FROM psychiatric.dbo.customers WHERE Name = N'" + comboBox2.Text + "'");
            if (table.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("حدث خطأ ما", "خطأ");
                return;
            }
            int amount, number;
            try
            {
                amount = Convert.ToInt32(textBox2.Text);
                number = Convert.ToInt32(textBox1.Text);
            } catch(Exception x)
            {
                MessageBox.Show("حدث خطأ ما", "خطأ");
                return;
            }

            table = db.Read("SELECT COUNT(*) FROM psychiatric.dbo.sessionNumber WHERE Name = N'" + comboBox2.Text + "'");
            if (table.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("هذا العميل مسجل بالفعل ", "خطأ");
                return;
            }

            db.Write("INSERT INTO psychiatric.dbo.sessionNumber VALUES (N'"+comboBox2.Text+"', "+number+", "+amount+")");
            MessageBox.Show("تمت الأضافة");
            sessionNumber obj = (sessionNumber)Application.OpenForms["sessionNumber"];
            obj.Init();
            Close();
        }
    }
}
