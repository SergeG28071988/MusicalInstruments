using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MusicalInstruments
{
    public partial class SearchClientsForm : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\T1000\Desktop\Musicalinstruments.mdb";
        private OleDbConnection myConnection;
        public SearchClientsForm()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            string address = AddressTb.Text;
            string query = "select Фамилия, Имя, Телефон from Клиенты where Адрес like '%" + address + "%'";

            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            ClientsDGV.DataSource = dt;
            myConnection.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClientsForm clients = new ClientsForm();
            clients.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddressTb.Text = "";

            ClientsDGV.Columns.Clear();
            ClientsDGV.Refresh();
        }
    }
}
