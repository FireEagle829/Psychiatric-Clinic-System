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
    public partial class PayCustomer : Form
    {
        String custName;
        Database db = new Database();
        public PayCustomer(String name)
        {
            InitializeComponent();
            custName = name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PayCustomer_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int price = 0, number = 0;
            try
            {
                price = Convert.ToInt32(textBox1.Text);
                number = Convert.ToInt32(textBox2.Text);
            } catch(Exception x)
            {
                MessageBox.Show("حدث خطأ ما", "خطأ");
                return;
            }
            db.Write("UPDATE psychiatric.dbo.sessionNumber SET Number = Number + "+number+", paidPrice = paidPrice + "+price+" WHERE Name = N'"+custName+"'");
            MessageBox.Show("تم الدفع");
            sessionNumber s = (sessionNumber)Application.OpenForms["sessionNumber"];
            s.Init();
            Close();
        }
    }
}
