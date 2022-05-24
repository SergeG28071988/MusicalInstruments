using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MusicalInstruments
{
    public partial class SearchOrders : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\T1000\Desktop\Musicalinstruments.mdb";
        private OleDbConnection myConnection;
        public SearchOrders()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            string client = ClientTb.Text;
            string query = "select Дата, Товар, Сумма from Заказы where Клиент like '%" + client + "%'";

            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            OrdersDGV.DataSource = dt;
            myConnection.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClientTb.Text = "";
            OrdersDGV.Columns.Clear();
            OrdersDGV.Refresh();
        }
    }
}
