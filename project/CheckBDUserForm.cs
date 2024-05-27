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
    public partial class CheckBDUserForm : MetroFramework.Forms.MetroForm
    {
        DataBase DB = new DataBase();
        public class Users
        {
            public int ID { get; set; }
            public string Логин { get; set; }
            public string Пароль { get; set; }
            public int Роль { get; set; }
        }
        private void FillDataGridView_user()
        {
            DB.OpenConnection();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM users", DB.getConnection()))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<Users> UsersList = new List<Users>();

                    while (reader.Read())
                    {
                        Users user = new Users
                        {
                            ID = reader.GetInt32(0),
                            Логин = reader.GetString(1),
                            Пароль = reader.GetString(2),
                            Роль = reader.GetInt32(3)
                        };

                        UsersList.Add(user);
                    }

                    dataGridView1.DataSource = UsersList;
                }
            }
            dataGridView1.Columns["ID"].ReadOnly = false;
            dataGridView1.Columns["Логин"].ReadOnly = false;
            dataGridView1.Columns["Пароль"].ReadOnly = false;
            dataGridView1.Columns["Роль"].ReadOnly = false;
        }
        public CheckBDUserForm()
        {
            InitializeComponent();
            FillDataGridView_user();
            LoadMetroComboBox1();
        }
        private void LoadMetroComboBox1()
        {
            toolStripComboBox1.Items.Clear();
            string query = "SELECT id FROM users";

            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(query, DB.getConnection());

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    toolStripComboBox1.Items.Add(reader["id"]);
                }

                reader.Close();
            }
        }

        private void CheckBDUserForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FillDataGridView_user();
            LoadMetroComboBox1();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            adduser sm = new adduser();
            sm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(toolStripComboBox1.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Пожалуйста, выберите что то из списка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string id = toolStripComboBox1.SelectedItem.ToString();
            string what_delete = "DELETE FROM users WHERE id = @id";
            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(what_delete, DB.getConnection());
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                MessageBox.Show($"Вы успешно удалили пользователя #{id}!");
            }
            FillDataGridView_user();
            LoadMetroComboBox1();
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
