using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System;

namespace MusicalInstruments
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\T1000\Desktop\Musicalinstruments.mdb"); // строка подключения

        private void Populate()
        {
            conn.Open(); // открываем подключение
            string query = "select * from Клиенты"; // получаем всех клиентов
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ClientsDGV.DataSource = ds.Tables[0];
            conn.Close(); // закрываем подключение
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Добавление данных
        {
            if (IdTb.Text == "" || SurnameTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Клиенты values (" + IdTb.Text + ", '" + SurnameTb.Text + "', '" + NameTb.Text + "', '" + AddressTb.Text + "', '" + PhoneTb.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Клиенты добавлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e) // удаление данных
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from Клиенты where [Код клиента]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Клиенты удалены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e) // данный метод позволяет выгрузить все столбцы из БД
        {
            IdTb.Text = ClientsDGV.SelectedRows[0].Cells[0].Value.ToString();
            SurnameTb.Text = ClientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            NameTb.Text = ClientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = ClientsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = ClientsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e) // обновление данных
        {
            if (IdTb.Text == "" || SurnameTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Клиенты  set Фамилия='" + SurnameTb.Text + "', Имя='" + NameTb.Text + "', Адрес='" + AddressTb.Text + "', Телефон='" + PhoneTb.Text + "' where [Код клиента]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Клиенты обновлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e) // возврат к главному меню
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e) // позволяет перейти на форму поиска клиентов
        {
            SearchClientsForm searchClients = new SearchClientsForm();
            searchClients.Show();
            this.Hide();
        }
    }
}
