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
    public partial class MainWindow : Form
    {
        Database db = new Database();
        public MainWindow()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            db.Write(@"IF  NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'psychiatric')
    BEGIN
        CREATE DATABASE[psychiatric]
    END; ");
            db.Write(@"IF object_id('psychiatric.dbo.customers', 'U') is null
    BEGIN
        CREATE TABLE psychiatric.dbo.customers (
            ID int IDENTITY(1,1) PRIMARY KEY,
            Name nvarchar(200)
        )
    END; ");

            db.Write(@"IF object_id('psychiatric.dbo.doctors', 'U') is null
    BEGIN
        CREATE TABLE psychiatric.dbo.doctors (
            ID int IDENTITY(1,1) PRIMARY KEY,
            Name nvarchar(200)
        )
    END; ");

            db.Write(@"IF object_id('psychiatric.dbo.places', 'U') is null
    BEGIN
        CREATE TABLE psychiatric.dbo.places (
            ID int IDENTITY(1,1) PRIMARY KEY,
            Name nvarchar(200)
        )
    END; ");

            db.Write(@"IF object_id('psychiatric.dbo.reservations', 'U') is null
    BEGIN
        CREATE TABLE psychiatric.dbo.reservations (
            ID int IDENTITY(1,1) PRIMARY KEY,
            CustName nvarchar(200),
            DocName nvarchar(200),
            Place nvarchar(200),
            Day nvarchar(50),
            Hour nvarchar(50)
        )
    END; ");

            db.Write(@"IF object_id('psychiatric.dbo.sessionNumber', 'U') is null
    BEGIN
        CREATE TABLE psychiatric.dbo.sessionNumber (
            ID int IDENTITY(1,1) PRIMARY KEY,
            Name nvarchar(200),
            Number int,
            paidPrice real
        )
    END; ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
                panel3.Visible = true;
            else
                panel3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
                panel5.Visible = true;
            else
                panel5.Visible = false;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (panel6.Visible == false)
                panel6.Visible = true;
            else
                panel6.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        public void OpenForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            childForm.Show();
            childForm.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addCustomer addCustomer = new addCustomer();
            OpenForm(addCustomer);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addDoctor addDoctor = new addDoctor();
            OpenForm(addDoctor);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addPlace addPlace = new addPlace();
            OpenForm(addPlace);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listCustomers listCustomers = new listCustomers();
            OpenForm(listCustomers);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listDoctors listDoctors = new listDoctors();
            OpenForm(listDoctors);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listPlaces listPlaces = new listPlaces();
            OpenForm(listPlaces);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            newReservation newReservation = new newReservation();
            OpenForm(newReservation);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showWeeklyschedule show = new showWeeklyschedule();
            OpenForm(show);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            showDailySchedule show = new showDailySchedule();
            OpenForm(show);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            customerSchedule_List list = new customerSchedule_List();
            list.ShowDialog();
            list.BringToFront();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DoctorSchedule_List list = new DoctorSchedule_List();
            list.ShowDialog();
            list.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sessionNumber s = new sessionNumber();
            OpenForm(s);
        }
    }
}
