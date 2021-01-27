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
    public partial class customerSchedule : Form
    {
        Database db = new Database();
        String name;
        public customerSchedule(String custName)
        {
            InitializeComponent();
            name = custName;
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
            DataTable table = db.Read("SELECT Day, Hour FROM psychiatric.dbo.reservations WHERE CustName = N'"+custName+"'");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                String day, hour;
                int rowIndex = 0, columnIndex = 0;
                day = table.Rows[i][0].ToString();
                hour = table.Rows[i][1].ToString();
                if (day == "السبت")
                {
                    columnIndex = 1;
                }
                else if (day == "الأحد")
                {
                    columnIndex = 2;
                }
                else if (day == "الأثنين")
                {
                    columnIndex = 3;
                }
                else if (day == "الثلاثاء")
                {
                    columnIndex = 4;
                }
                else if (day == "الأربعاء")
                {
                    columnIndex = 5;
                }
                else if (day == "الخميس")
                {
                    columnIndex = 6;
                }

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

                dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = "محجوز";
            }
        }

        private void customerSchedule_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("الساعة");
            dt.Columns.Add("السبت");
            dt.Columns.Add("الأحد");
            dt.Columns.Add("الأثنين");
            dt.Columns.Add("الثلاثاء");
            dt.Columns.Add("الأربعاء");
            dt.Columns.Add("الخميس");
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("document.xml");
            customerReport cr = new customerReport();
            cr.SetDataSource(ds);
            cr.SetParameterValue("name", name);
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            cr.PrintOptions.PrinterName = printDoc.PrinterSettings.PrinterName;
            cr.PrintToPrinter(1, true, 0, 0);
        }
    }
}
