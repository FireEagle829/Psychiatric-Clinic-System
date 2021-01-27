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
    public partial class customerSchedule_List : Form
    {
        Database db = new Database();
        public customerSchedule_List()
        {
            InitializeComponent();
            DataTable table = db.Read("SELECT Name FROM psychiatric.dbo.customers");
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = db.Read("SELECT COUNT(*) FROM psychiatric.dbo.customers WHERE Name = N'"+comboBox2.Text+"'");
            if (table.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("حدث خطأ ما", "خطأ");
            }
            else
            {
                MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];
                customerSchedule schedule = new customerSchedule(comboBox2.Text);
                obj.OpenForm(schedule);
                Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
