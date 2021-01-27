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
    public partial class listReservedCustomers : Form
    {
        String day = "", hour = "";
        Database db = new Database();
        public listReservedCustomers(int rowIndex, int columnIndex = -1, String dayAr = "")
        {
            InitializeComponent();

            if (rowIndex == 0)
                hour = "12";
            else if (rowIndex == 1)
                hour = "1";
            else if (rowIndex == 2)
                hour = "2";
            else if (rowIndex == 3)
                hour = "3";
            else if (rowIndex == 4)
                hour = "4";
            else if (rowIndex == 5)
                hour = "5";
            else if (rowIndex == 6)
                hour = "6";
            else if (rowIndex == 7)
                hour = "7";
            else if (rowIndex == 8)
                hour = "8";

            if (columnIndex == 1)
                day = "السبت";
            else if (columnIndex == 2)
                day = "الأحد";
            else if (columnIndex == 3)
                day = "الأثنين";
            else if (columnIndex == 4)
                day = "الثلاثاء";
            else if (columnIndex == 5)
                day = "الأربعاء";
            else if (columnIndex == 6)
                day = "الخميس";
            else if (columnIndex == -1)
                day = dayAr;

            DataTable table = db.Read("SELECT CustName FROM psychiatric.dbo.reservations WHERE Day = N'"+day+"' AND Hour = N'"+hour+"'");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listBox1.Items.Add(table.Rows[i][0]);
            }
        }

        private void listReservedCustomers_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 1 || listBox1.SelectedItems.Count == 0)
                return;
            db.Write("DELETE FROM psychiatric.dbo.reservations WHERE CustName = N'"+listBox1.SelectedItem.ToString()+"' AND Day = N'"+day+"' AND Hour = N'"+hour+"'");
            MessageBox.Show("تم المسح بنجاح", "Success");
            listBox1.Items.Remove(listBox1.SelectedItem);

            String window = Application.OpenForms[1].ToString();

            if (window == "Psychiatric.showWeeklyschedule, Text: showWeeklyschedule")
            {
                showWeeklyschedule obj = (showWeeklyschedule)Application.OpenForms["showWeeklyschedule"];
                obj.init();
            } else if (window == "Psychiatric.showDailySchedule, Text: showDailySchedule")
            {
                showDailySchedule obj = (showDailySchedule)Application.OpenForms["showDailySchedule"];
                obj.init();
            }
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 1 || listBox1.SelectedItems.Count == 0)
            {
                return;
            } else
            {
                listReservedCustomerDetails list = new listReservedCustomerDetails(day, hour, listBox1.SelectedItem.ToString());
                list.ShowDialog();
                list.BringToFront();
                Close();
            }
        }
    }
}
