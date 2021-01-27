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
    public partial class newReservation : Form
    {
        Database db = new Database();
        public newReservation()
        {
            InitializeComponent();
            DataTable table = db.Read("SELECT Name FROM psychiatric.dbo.customers");
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";

            table = db.Read("SELECT Name FROM psychiatric.dbo.doctors");
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Name";

            table = db.Read("SELECT Name FROM psychiatric.dbo.places");
            comboBox3.DataSource = table;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Name";

            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
        }

        private void newReservation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = db.Read("SELECT Name FROM psychiatric.dbo.customers WHERE Name = N'"+comboBox1.Text+"'");
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("حدث خطأ ما", "Error");
                return;
            }

            table = db.Read("SELECT Name FROM psychiatric.dbo.doctors WHERE Name = N'" + comboBox2.Text + "'");
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("حدث خطأ ما", "Error");
                return;
            }

            table = db.Read("SELECT Name FROM psychiatric.dbo.places WHERE Name = N'" + comboBox3.Text + "'");
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("حدث خطأ ما", "Error");
                return;
            }

            table = db.Read("SELECT COUNT(*) FROM psychiatric.dbo.reservations WHERE Place = N'" + comboBox3.Text + "' AND Day = N'" + comboBox5.Text + "' AND Hour = N'" + comboBox4.Text + "'");
            if (Convert.ToInt64(table.Rows[0][0]) == 0)
            {
                db.Write("INSERT INTO psychiatric.dbo.reservations VALUES (N'"+comboBox1.Text+"', N'"+comboBox2.Text+"', N'"+comboBox3.Text+"', N'"+comboBox5.Text+"', N'"+comboBox4.Text+"')");
                MessageBox.Show("تم الحجز", "Success", MessageBoxButtons.OK);
            } 
            else
            {
                MessageBox.Show("لم يتم الحجز, هناك حجز اخر في نفس المكان والوقت", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
