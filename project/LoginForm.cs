using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        DataBase DB = new DataBase();
        public int Connection(string login, string password)
        {
            DB.OpenConnection();
            //Выбор всех данных из таблицы users и их фильтрование по подходящим логину и паролю
            string commandStr = $"SELECT * FROM users WHERE login = '{login}' AND password = '{password}'";
            MySqlCommand comm1 = new MySqlCommand(commandStr, DB.getConnection());
            int k = Convert.ToInt32(comm1.ExecuteScalar());
            if (k != 0)
            {
                //Выбор столбца rang в зависимости от логина и пароля
                string commandStr2 = $"SELECT role FROM users WHERE login = '{login}' AND password = '{password}'";
                MySqlCommand comm2 = new MySqlCommand(commandStr2, DB.getConnection());
                Auth.auth_role = Convert.ToInt32(comm2.ExecuteScalar());
                string commandStr3 = $"SELECT id FROM users WHERE login = '{login}' AND password = '{password}'";
                MySqlCommand comm3 = new MySqlCommand(commandStr3, DB.getConnection());
                Auth.auth_id = Convert.ToInt32(comm3.ExecuteScalar());
            }
            
            //Закрытие соединения
            DB.CloseConnection();
            return Auth.auth_role;
        }
        public void Rang()
        {

            if (Connection(logtext.Text, passtext.Text) == 0)
            {
                MessageBox.Show("Неверные данные");
                LoginForm sm = new LoginForm();
                sm.ShowDialog();
            }

            else if (Connection(logtext.Text, passtext.Text) == 2)
            {
                MessageBox.Show($"Вы авторизированы как Админ");
                //Скрытие данной формы и запуск следующей в зависимости от введёных данных
                AdminForm sm = new AdminForm();
                sm.ShowDialog();
            }
            else if (Connection(logtext.Text, passtext.Text) == 1)
            {
                MessageBox.Show($"Вы авторизированы как Учитель");
                //Скрытие данной формы и запуск следующей в зависимости от введёных данных
                UserForm sm = new UserForm();
                sm.ShowDialog();
            }
            else if (Connection(logtext.Text, passtext.Text) == 3)
            {
                MessageBox.Show($"Вы авторизированы как Мастер по Ремонту");
                //Скрытие данной формы и запуск следующей в зависимости от введёных данных
                RepairForm sm = new RepairForm();
                sm.ShowDialog();
            }

        }
        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Thread myThread1 = new Thread(Rang);
            myThread1.SetApartmentState(ApartmentState.STA);
            myThread1.Start();
            this.Hide();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void logtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter key
            {
                // Focus on the second TextBox
                passtext.Focus();
            }
        }

        private void passtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter key
            {
                // Focus on the second TextBox
                metroButton1.Focus();
            }
        }
    }
}
