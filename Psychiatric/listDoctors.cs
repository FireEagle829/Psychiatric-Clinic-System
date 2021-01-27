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
    public partial class listDoctors : Form
    {
        Database db = new Database();
        public listDoctors()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            table = db.Read("SELECT Name FROM psychiatric.dbo.doctors");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listBox1.Items.Add(table.Rows[i][0]);
            }
        }

        private void listDoctors_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر اخصائي", "خطأ");
                return;
            }
            String name = listBox1.SelectedItem.ToString();
            db.Write("DELETE FROM psychiatric.dbo.doctors WHERE Name = N'" + name + "'");
            MessageBox.Show("تم مسح الأخصائي", "نجاح");
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            listBox1.Items.Clear();
            String searchString = textBox2.Text;
            DataTable table = db.Read("SELECT Name FROM psychiatric.dbo.doctors WHERE Name LIKE N'%" + searchString + "%'");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listBox1.Items.Add(table.Rows[i][0]);
            }
        }
    }
}
