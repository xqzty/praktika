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
using static project.RepairRequestForm;

namespace project
{
    public partial class CheckBDRepairForm : MetroFramework.Forms.MetroForm
    {
        DataBase DB = new DataBase();
        public class Requests
        {
            public int ID_Ремонта { get; set; }
            public int ID_Запроса { get; set; }
            public DateTime Дата_Починки { get; set; }
            public decimal Цена { get; set; }

        }
        public CheckBDRepairForm()
        {
            InitializeComponent();
        }

        private void CheckBDRepairForm_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }
        private void FillDataGridView()
        {
            DB.OpenConnection();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM repair", DB.getConnection()))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<Requests> RequestsList = new List<Requests>();

                    while (reader.Read())
                    {
                        Requests request = new Requests
                        {
                            ID_Ремонта = reader.GetInt32(0),
                            ID_Запроса = reader.GetInt32(1),
                            Дата_Починки = reader.GetDateTime(2),
                            Цена = reader.GetDecimal(3),
                        };

                        RequestsList.Add(request);
                    }

                    dataGridView1.DataSource = RequestsList;
                }
            }
            dataGridView1.Columns["ID_Ремонта"].ReadOnly = false;
            dataGridView1.Columns["ID_Запроса"].ReadOnly = false;
            dataGridView1.Columns["Дата_Починки"].ReadOnly = false;
            dataGridView1.Columns["Цена"].ReadOnly = false;
            DB.CloseConnection();
        }
    }
}
