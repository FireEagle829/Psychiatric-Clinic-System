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
    public partial class DoctorSchedule_List : Form
    {
        Database db = new Database();
        public DoctorSchedule_List()
        {
            InitializeComponent();
            DataTable table = db.Read("SELECT Name FROM psychiatric.dbo.doctors");
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = db.Read("SELECT COUNT(*) FROM psychiatric.dbo.doctors WHERE Name = N'" + comboBox2.Text + "'");
            if (table.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("حدث خطأ ما", "خطأ");
            } else
            {
                MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];
                doctorSchedule doc = new doctorSchedule(comboBox2.Text);
                obj.OpenForm(doc);
                Close();
            }
        }
    }
}
