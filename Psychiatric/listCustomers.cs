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
    public partial class listCustomers : Form
    {

        Database db = new Database();

        public listCustomers()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            table = db.Read("SELECT Name FROM psychiatric.dbo.customers");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listBox1.Items.Add(table.Rows[i][0]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listCustomers_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر عميلا", "خطأ");
                return;
            }
            String name = listBox1.SelectedItem.ToString();
            db.Write("DELETE FROM psychiatric.dbo.customers WHERE Name = N'"+name+"'");
            MessageBox.Show("تم مسح العميل", "نجاح");
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            listBox1.Items.Clear();
            String searchString = textBox2.Text;
            DataTable table = db.Read("SELECT Name FROM psychiatric.dbo.customers WHERE Name LIKE N'%"+searchString+"%'");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listBox1.Items.Add(table.Rows[i][0]);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
