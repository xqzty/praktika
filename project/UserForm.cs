using MetroFramework.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class UserForm : MetroFramework.Forms.MetroForm
    {
        DataBase DB = new DataBase();
        private MetroTextBox[] metroTextFields;
        public class Computers
        {
            public int ID_Оборудования { get; set; }
            public string Наименование { get; set; }
            public string Модель { get; set; }
            public string Серийный_Номер { get; set; }
            public string Место_Хранения { get; set; }
            public string Состояние { get; set; }

        }
        public class Requests
        {
            public int ID_Оборудования { get; set; }
            public DateTime Дата_Запроса { get; set; }
            public string Описание { get; set; }
            public string Приоритет { get; set; }
            public string Статус { get; set; }

        }

        private void FillDataGridView()
        {
            DB.OpenConnection();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM equipment", DB.getConnection()))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<Computers> computersList = new List<Computers>();

                    while (reader.Read())
                    {
                        Computers computer = new Computers
                        {
                            ID_Оборудования = reader.GetInt32(0),
                            Наименование = reader.GetString(1),
                            Модель = reader.GetString(2),
                            Серийный_Номер = reader.GetString(3),
                            Место_Хранения = reader.GetString(4),
                            Состояние = reader.GetString(5),
                        };

                        computersList.Add(computer);
                    }

                    dataGridView1.DataSource = computersList;
                }
            }
            dataGridView1.Columns["ID_Оборудования"].ReadOnly = true;
            dataGridView1.Columns["Наименование"].ReadOnly = true;
            dataGridView1.Columns["Модель"].ReadOnly = true;
            dataGridView1.Columns["Серийный_Номер"].ReadOnly = true;
            dataGridView1.Columns["Место_Хранения"].ReadOnly = true;
            dataGridView1.Columns["Состояние"].ReadOnly = true;
        }
        private void FillDataGridView1()
        {
            DB.OpenConnection();

            using (MySqlCommand command = new MySqlCommand("SELECT equipment_id, request_date, description, priority, status FROM repair_request ORDER BY equipment_id ASC", DB.getConnection()))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<Requests> RequestsList = new List<Requests>();

                    while (reader.Read())
                    {
                        Requests request = new Requests
                        {
                            ID_Оборудования = reader.GetInt32(0),
                            Дата_Запроса = reader.GetDateTime(1),
                            Описание = reader.GetString(2),
                            Приоритет = reader.GetString(3),
                            Статус = reader.GetString(4)
                        };

                        RequestsList.Add(request);
                    }

                    metroGrid1.DataSource = RequestsList;
                }
            }
            metroGrid1.Columns["ID_Оборудования"].ReadOnly = true;
            metroGrid1.Columns["Дата_Запроса"].ReadOnly = true;
            metroGrid1.Columns["Описание"].ReadOnly = true;
            metroGrid1.Columns["Приоритет"].ReadOnly = true;
            metroGrid1.Columns["Статус"].ReadOnly = true;
            DB.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (MetroTextBox metroTextField in metroTextFields)
            {
                if (string.IsNullOrWhiteSpace(metroTextField.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Пожалуйста, заполните все поля.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (metroComboBox1.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "Пожалуйста, выберите значение из списка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DB.OpenConnection();
            using (MySqlCommand command = new MySqlCommand("INSERT INTO repair_request (equipment_id, request_date, description, priority, status) VALUES (@equipment_id, @request_date, @description, @priority, @status);", DB.getConnection()))
            {
                command.Parameters.AddWithValue("@request_date", DateTime.Now);
                command.Parameters.AddWithValue("@equipment_id", Convert.ToInt32(metroComboBox1.Text));
                command.Parameters.AddWithValue("@description", metroTextBox2.Text);
                command.Parameters.AddWithValue("@priority", metroTextBox3.Text);
                command.Parameters.AddWithValue("@status", "На рассмотрении");
                command.ExecuteNonQuery();
                string equipment_id = metroComboBox1.Text;
                MessageBox.Show($"Вы успешно добавили запрос на оборудование #{equipment_id}");
            }
            using (MySqlCommand command = new MySqlCommand("UPDATE equipment SET status = @status WHERE equipment_id = @equipment_id", DB.getConnection()))
            {
                command.Parameters.AddWithValue("@equipment_id", Convert.ToInt32(metroComboBox1.Text));
                command.Parameters.AddWithValue("@status", "broken");
                command.ExecuteNonQuery();
            }
            DB.CloseConnection();
            FillDataGridView();
            LoadMetroComboBox();
            FillDataGridView1();


        }
        private void LoadMetroComboBox()
        {
            metroComboBox1.Items.Clear();
            string query = "SELECT equipment_id FROM equipment WHERE status = 'working'";

            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(query, DB.getConnection());

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    metroComboBox1.Items.Add(reader["equipment_id"]);
                }

                reader.Close();
            }
        }
        public UserForm()
        {
            InitializeComponent();
            metroTextFields = new MetroTextBox[] {metroTextBox2, metroTextBox3};
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            LoadMetroComboBox();
            FillDataGridView1();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
