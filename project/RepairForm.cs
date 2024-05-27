using MetroFramework.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class RepairForm : MetroFramework.Forms.MetroForm
    {
        
        public RepairForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            RepairRequestForm sm = new RepairRequestForm();
            sm.ShowDialog();

        }

        private void RepairForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CheckBDRepairForm sm = new CheckBDRepairForm();
            sm.ShowDialog();
        }
    }
}
