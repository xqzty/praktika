namespace project
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Repair_requestFormButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.EquipmentFormButton = new MetroFramework.Controls.MetroButton();
            this.UserFormButton = new MetroFramework.Controls.MetroButton();
            this.RepairFormButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Repair_requestFormButton
            // 
            this.Repair_requestFormButton.Location = new System.Drawing.Point(331, 143);
            this.Repair_requestFormButton.Name = "Repair_requestFormButton";
            this.Repair_requestFormButton.Size = new System.Drawing.Size(75, 41);
            this.Repair_requestFormButton.TabIndex = 4;
            this.Repair_requestFormButton.Text = "Изменить";
            this.Repair_requestFormButton.UseSelectable = true;
            this.Repair_requestFormButton.Click += new System.EventHandler(this.Repair_requestFormButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(54, 121);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(154, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Таблица оборудования";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 259);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(201, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Таблица выполненных заказов";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(278, 121);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(191, 19);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Таблица запросов на ремонт";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(292, 259);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(157, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Таблица Пользователей";
            // 
            // EquipmentFormButton
            // 
            this.EquipmentFormButton.Location = new System.Drawing.Point(92, 143);
            this.EquipmentFormButton.Name = "EquipmentFormButton";
            this.EquipmentFormButton.Size = new System.Drawing.Size(75, 41);
            this.EquipmentFormButton.TabIndex = 12;
            this.EquipmentFormButton.Text = "Изменить";
            this.EquipmentFormButton.UseSelectable = true;
            this.EquipmentFormButton.Click += new System.EventHandler(this.EquipmentFormButton_Click);
            // 
            // UserFormButton
            // 
            this.UserFormButton.Location = new System.Drawing.Point(331, 281);
            this.UserFormButton.Name = "UserFormButton";
            this.UserFormButton.Size = new System.Drawing.Size(75, 41);
            this.UserFormButton.TabIndex = 13;
            this.UserFormButton.Text = "Изменить";
            this.UserFormButton.UseSelectable = true;
            this.UserFormButton.Click += new System.EventHandler(this.UserFormButton_Click);
            // 
            // RepairFormButton
            // 
            this.RepairFormButton.Location = new System.Drawing.Point(92, 281);
            this.RepairFormButton.Name = "RepairFormButton";
            this.RepairFormButton.Size = new System.Drawing.Size(75, 41);
            this.RepairFormButton.TabIndex = 14;
            this.RepairFormButton.Text = "Изменить";
            this.RepairFormButton.UseSelectable = true;
            this.RepairFormButton.Click += new System.EventHandler(this.RepairFormButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 370);
            this.Controls.Add(this.RepairFormButton);
            this.Controls.Add(this.UserFormButton);
            this.Controls.Add(this.EquipmentFormButton);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.Repair_requestFormButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Панель Администратора";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton Repair_requestFormButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton EquipmentFormButton;
        private MetroFramework.Controls.MetroButton UserFormButton;
        private MetroFramework.Controls.MetroButton RepairFormButton;
    }
}