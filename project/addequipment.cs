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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class addequipment : MetroFramework.Forms.MetroForm
    {
        private MetroTextBox[] metroTextFields;
        DataBase DB = new DataBase();
        public addequipment()
        {
            InitializeComponent();
            metroTextFields = new MetroTextBox[] { metroTextBox1, metroTextBox2, metroTextBox3, metroTextBox4 };
        }
        
        private void addequipment_Load(object sender, EventArgs e)
        {
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
            String name = metroTextBox1.Text;
            String model = metroTextBox2.Text;
            String serial_number = metroTextBox3.Text;
            String location = metroTextBox4.Text;
            string what_add = $"INSERT INTO equipment (name, model, serial_number, location, status) VALUES (@name, @model, @serial_number, @location, 'working')";
            DB.OpenConnection();
            {
                MySqlCommand command = new MySqlCommand(what_add, DB.getConnection());
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@serial_number", serial_number);
                command.Parameters.AddWithValue("@location", location);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                MessageBox.Show($"Вы успешно приняли добавили оборудование {name}!");
            }
        }
    }
}
