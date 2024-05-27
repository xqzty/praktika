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
    public partial class adduser : MetroFramework.Forms.MetroForm
    {
        DataBase DB = new DataBase();
        private MetroTextBox[] metroTextFields;
        public adduser()
        {
            InitializeComponent();
            LoadMetroComboBox();
            metroTextFields = new MetroTextBox[] { metroTextBox1, metroTextBox2 };
        }
        
        private void adduser_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadMetroComboBox()
        {
            metroComboBox1.Items.Add("Учитель");
            metroComboBox1.Items.Add("Администратор");
            metroComboBox1.Items.Add("Мастер по ремонту");
        }

        private void metroButton1_Click(object sender, EventArgs e)
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
            Int32 role = 0;
            String selected_item = metroComboBox1.SelectedItem.ToString();
            if (selected_item == "Учитель")
            {
                role = 1;
            }
            if (selected_item == "Администратор")
            {
                role = 2;
            }
            if (selected_item == "Мастер по ремонту")
            {
                role = 3;
            }
            String login = metroTextBox1.Text;
            String password = metroTextBox2.Text;
            string what_add = $"INSERT INTO users (login, password, role) VALUES (@login, @password, @role)";
            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(what_add, DB.getConnection());
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                MessageBox.Show($"Вы успешно добавили пользователя {login}!");
            }
        }
    }
}
