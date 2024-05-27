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
    public partial class CheckBDEquipmentForm : MetroFramework.Forms.MetroForm
    {
        DataBase DB = new DataBase();
        public class Equipment
        {
            public int ID { get; set; }
            public string Наименование { get; set; }
            public string Модель { get; set; }
            public string Серийный_Номер { get; set; }
            public string Место_Хранения { get; set; }
            public string Состояние { get; set; }

        }
        private void FillDataGridView()
        {
            DB.OpenConnection();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM equipment", DB.getConnection()))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<Equipment> EquipmentsList = new List<Equipment>();

                    while (reader.Read())
                    {
                        Equipment equipment = new Equipment
                        {
                            ID = reader.GetInt32(0),
                            Наименование = reader.GetString(1),
                            Модель = reader.GetString(2),
                            Серийный_Номер = reader.GetString(3),
                            Место_Хранения = reader.GetString(4),
                            Состояние = reader.GetString(5)
                        };

                        EquipmentsList.Add(equipment);
                    }

                    dataGridView1.DataSource = EquipmentsList;
                }
            }
            dataGridView1.Columns["ID"].ReadOnly = false;
            dataGridView1.Columns["Наименование"].ReadOnly = false;
            dataGridView1.Columns["Модель"].ReadOnly = false;
            dataGridView1.Columns["Серийный_Номер"].ReadOnly = false;
            dataGridView1.Columns["Место_Хранения"].ReadOnly = false;
            dataGridView1.Columns["Состояние"].ReadOnly = false;
        }
        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;
        //    Equipment equipment = (Equipment)dgv.Rows[e.RowIndex].DataBoundItem;

        //    equipment.Eq_name = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        //    // Update the equipment name in the database
        //    DB.OpenConnection();
        //    using (MySqlCommand command = new MySqlCommand("UPDATE equipment SET eq_name = @eq_name WHERE id_equipment = @id_equipment", DB.getConnection()))
        //    {
        //        command.Parameters.AddWithValue("@id_equipment", equipment.Id_equipment);
        //        command.Parameters.AddWithValue("@eq_name", equipment.Eq_name);

        //        command.ExecuteNonQuery();
        //    }
        //}

        public CheckBDEquipmentForm()
        {
            InitializeComponent();
        }

        private void CheckBDEquipmentForm_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            LoadMetroComboBox1();
            //dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }
        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            addequipment sm = new addequipment();
            sm.ShowDialog();
        }
        private void LoadMetroComboBox1()
        {
            toolStripComboBox1.Items.Clear();
            string query = "SELECT equipment_id FROM equipment";

            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(query, DB.getConnection());

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    toolStripComboBox1.Items.Add(reader["equipment_id"]);
                }

                reader.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(toolStripComboBox1.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Пожалуйста, выберите что то из списка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string id = toolStripComboBox1.SelectedItem.ToString();
            string what_delete = "DELETE FROM equipment WHERE equipment_id = @id";
            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(what_delete, DB.getConnection());
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                MessageBox.Show($"Вы успешно удалили оборудование #{id}!");
            }
            FillDataGridView();
            LoadMetroComboBox1();
            toolStripComboBox1.SelectedIndex = 0;
        }
    }
}
