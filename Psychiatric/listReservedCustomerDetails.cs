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
    public partial class listReservedCustomerDetails : Form
    {
        Database db = new Database();
        public listReservedCustomerDetails(String day, String hour, String custname)
        {
            InitializeComponent();
            DataTable table = db.Read("SELECT DocName, Place FROM psychiatric.dbo.reservations WHERE CustName = N'"+custname+"' AND Day = N'"+day+"' AND Hour = N'"+hour+"'");
            label3.Text = table.Rows[0][0].ToString();
            label5.Text = table.Rows[0][1].ToString();
            label1.Text = custname;
            label7.Text = day;
            label9.Text = hour;
        }
    }
}
