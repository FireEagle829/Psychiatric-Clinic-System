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
    public partial class showDailySchedule : Form
    {

        Database db = new Database();

        public showDailySchedule()
        {
            InitializeComponent();
            init();
        }
        String dayAr = "";
        public void init()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 22);
            dataGridView1.RowHeadersDefaultCellStyle.Font = new Font("Arial", 15);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 20);
            dataGridView1.EnableHeadersVisualStyles = false;
            for (int i = 1; i < 9; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                dataGridView1.Rows.Add(row);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 80;
            }
            dataGridView1.Rows[0].Cells[0].Value = 12;
            for (int i = 1; i < 9; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i;
            }

            String dayEng = DateTime.Now.ToString("dddd");

            if (dayEng == "Saturday")
                dayAr = "السبت";
            else if (dayEng == "Sunday")
                dayAr = "الأحد";
            else if (dayEng == "Monday")
                dayAr = "الأثنين";
            else if (dayEng == "Tuesday")
                dayAr = "الثلاثاء";
            else if (dayEng == "Wednesday")
                dayAr = "الأربعاء";
            else if (dayEng == "Thursday")
                dayAr = "الخميس";
            else if (dayEng == "Friday")
                dayAr = "الجمعه";

            dataGridView1.Columns[1].HeaderText = dayAr;

            if (dayAr == "الجمعه")
                return;

            DataTable table = db.Read("SELECT Hour FROM psychiatric.dbo.reservations WHERE Day = N'"+dayAr+"'");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                String hour;
                int rowIndex = 0;
                hour = table.Rows[i][0].ToString();

                if (hour == "12")
                    rowIndex = 0;
                else if (hour == "1")
                    rowIndex = 1;
                else if (hour == "2")
                    rowIndex = 2;
                else if (hour == "3")
                    rowIndex = 3;
                else if (hour == "4")
                    rowIndex = 4;
                else if (hour == "5")
                    rowIndex = 5;
                else if (hour == "6")
                    rowIndex = 6;
                else if (hour == "7")
                    rowIndex = 7;
                else if (hour == "8")
                    rowIndex = 8;

                dataGridView1.Rows[rowIndex].Cells[1].Value = "محجوز";
            }
        }

        private void showDailySchedule_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 1 || dataGridView1.SelectedCells[0].Value == null)
            {
                return;
            }

            else
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                listReservedCustomers list = new listReservedCustomers(rowIndex, -1, dayAr);
                list.ShowDialog();
                list.BringToFront();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("الساعة");
            dt.Columns.Add(dayAr);
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("document.xml");
            dailyReport cr = new dailyReport();
            cr.SetDataSource(ds);
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            cr.PrintOptions.PrinterName = printDoc.PrinterSettings.PrinterName;
            cr.PrintToPrinter(1, true, 0, 0);
        }
    }
}
