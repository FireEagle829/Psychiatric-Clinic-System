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
    public partial class sessionNumber : Form
    {
        Database db = new Database();
        public sessionNumber()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            listBox1.Items.Clear();
            label7.Text = "";
            label5.Text = "";
            label8.Text = "";
            DataTable table = db.Read("SELECT Name FROM psychiatric.dbo.sessionNumber");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listBox1.Items.Add(table.Rows[i][0]);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void sessionNumber_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            addSessionNumber s = new addSessionNumber();
            s.ShowDialog();
            s.BringToFront();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            DataTable table = db.Read("SELECT Name, Number, paidPrice FROM psychiatric.dbo.sessionNumber WHERE Name = N'"+listBox1.SelectedItem.ToString()+"'");
            label5.Text = table.Rows[0][0].ToString();
            label7.Text = table.Rows[0][1].ToString();
            label8.Text = table.Rows[0][2].ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            DataTable table = db.Read("SELECT Number FROM psychiatric.dbo.sessionNumber WHERE Name = N'"+listBox1.SelectedItem.ToString()+"'");
            int num = Convert.ToInt32(table.Rows[0][0]);
            if (num == 0)
            {
                MessageBox.Show("حدث خطأ ما", "خطأ");
                return;
            }
            num -= 1;
            db.Write("UPDATE psychiatric.dbo.sessionNumber SET Number = "+num+" WHERE Name = N'"+listBox1.SelectedItem.ToString()+"'");
            MessageBox.Show("تم الحجز", "Success");
            Init();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            db.Write("DELETE FROM psychiatric.dbo.sessionNumber WHERE Name = N'"+listBox1.SelectedItem.ToString()+"'");
            MessageBox.Show("تم المسح", "Success");
            Init();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            PayCustomer x = new PayCustomer(listBox1.SelectedItem.ToString());
            x.ShowDialog();
            x.BringToFront();
        }
    }
}
