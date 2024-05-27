using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace project
{
    public partial class AdminForm : MetroFramework.Forms.MetroForm
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void Repair_requestFormButton_Click(object sender, EventArgs e)
        {
            RepairRequestForm sm = new RepairRequestForm();
            sm.ShowDialog();
        }

        private void EquipmentFormButton_Click(object sender, EventArgs e)
        {
            CheckBDEquipmentForm sm = new CheckBDEquipmentForm();
            sm.ShowDialog();
        }

        private void UserFormButton_Click(object sender, EventArgs e)
        {
            CheckBDUserForm sm = new CheckBDUserForm();
            sm.ShowDialog();
        }

        private void RepairFormButton_Click(object sender, EventArgs e)
        {
            CheckBDRepairForm sm = new CheckBDRepairForm();
            sm.ShowDialog();
        }
    }
}
