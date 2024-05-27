using Google.Protobuf.Reflection;
using MetroFramework.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{

    public partial class RepairRequestForm : MetroFramework.Forms.MetroForm
    {
        DataBase DB = new DataBase();
        public class Requests
        {
            public int ID_Запроса { get; set; }
            public int ID_Оборудования { get; set; }
            public DateTime Дата_Запроса { get; set; }
            public string Описание { get; set; }
            public string Приоритет { get; set; }
            public string Статус { get; set; }

        }

        private void FillDataGridView()
        {
            DB.OpenConnection();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM repair_request WHERE status != 'Завершено'", DB.getConnection()))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<Requests> RequestsList = new List<Requests>();

                    while (reader.Read())
                    {
                        Requests request = new Requests
                        {
                            ID_Запроса = reader.GetInt32(0),
                            ID_Оборудования = reader.GetInt32(1),
                            Дата_Запроса = reader.GetDateTime(2),
                            Описание = reader.GetString(3),
                            Приоритет = reader.GetString(4),
                            Статус = reader.GetString(5)
                        };

                        RequestsList.Add(request);
                    }

                    dataGridView1.DataSource = RequestsList;
                }
            }
            dataGridView1.Columns["ID_Запроса"].ReadOnly = false;
            dataGridView1.Columns["ID_Оборудования"].ReadOnly = false;
            dataGridView1.Columns["Дата_Запроса"].ReadOnly = false;
            dataGridView1.Columns["Описание"].ReadOnly = false;
            dataGridView1.Columns["Приоритет"].ReadOnly = false;
            dataGridView1.Columns["Статус"].ReadOnly = false;
            DB.CloseConnection();
        }
        public RepairRequestForm()
        {
            InitializeComponent();
        }

        private void CheckBDRepairRequestForm_Load(object sender, EventArgs e)
        {
            LoadMetroComboBox1();
            LoadMetroComboBox2();
            FillDataGridView();
        }
        private void LoadMetroComboBox1()
        {
            metroComboBox1.Items.Clear();
            string query = "SELECT request_id, description FROM repair_request WHERE status = 'На рассмотрении'";

            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(query, DB.getConnection());

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    metroComboBox1.Items.Add(reader["request_id"]);
                }

                reader.Close();
            }
        }
        private void LoadMetroComboBox2()
        {
            metroComboBox2.Items.Clear();
            string query = "SELECT request_id, description FROM repair_request WHERE status = 'Выполняется'";

            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(query, DB.getConnection());

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    metroComboBox2.Items.Add(reader["request_id"]);
                }
                
                reader.Close();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(metroComboBox1.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Пожалуйста, выберите что то из списка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string what_updating = metroComboBox1.Text.ToString();
            string updating = "UPDATE repair_request SET status = 'Выполняется' WHERE request_id = @request_id";

            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(updating, DB.getConnection());
                command.Parameters.AddWithValue("request_id", what_updating);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                MessageBox.Show($"Вы успешно приняли заказ #{what_updating}");
            }
            FillDataGridView();
            LoadMetroComboBox1();
            LoadMetroComboBox2();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(metroComboBox2.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Пожалуйста, выберите что то из списка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string summ = metroTextBox1.Text;
            string id = metroComboBox2.Text;
            string query1 = "INSERT INTO repair (request_id, repair_date, cost) VALUES (@id, @date, @cost)";
            string query2 = "UPDATE repair_request SET status = 'Завершено' WHERE request_id = @id";
            string query3 = "UPDATE equipment SET status = @status WHERE equipment_id = @equipment_id";
            string query4 = $"SELECT equipment_id FROM repair_request WHERE request_id = '{id}'";
            DB.OpenConnection();
            MySqlCommand comm = new MySqlCommand(query4, DB.getConnection());
            int equipment_id = Convert.ToInt32(comm.ExecuteScalar());
            DB.CloseConnection();
            {
                DB.OpenConnection();
                MySqlCommand command = new MySqlCommand(query1, DB.getConnection());
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@cost", summ);
                command.ExecuteNonQuery();
                DB.CloseConnection();
            }
            {
                DB.OpenConnection();
                MySqlCommand command1 = new MySqlCommand(query2, DB.getConnection());
                command1.Parameters.AddWithValue("@id", id);
                command1.ExecuteNonQuery();
                DB.CloseConnection();
            }
            {
                DB.OpenConnection();
                MySqlCommand command1 = new MySqlCommand(query3, DB.getConnection());
                command1.Parameters.AddWithValue("@equipment_id", equipment_id);
                command1.Parameters.AddWithValue("@status", "working");
                command1.ExecuteNonQuery();
                DB.CloseConnection();
            }
            MessageBox.Show($"Вы успешно завершили заказ #{id}");
            FillDataGridView();
            LoadMetroComboBox1();
            LoadMetroComboBox2();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
