using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System;

namespace MusicalInstruments
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\T1000\Desktop\Musicalinstruments.mdb");

        private void Populate()
        {
            conn.Open();
            string query = "select * from Заказы";
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            OrdersDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            if (IdTb.Text == "" || OrderDateTb.Text == "" || ClientTb.Text == "" || ProductTb.Text == "" || PriceTb.Text == "" || QuantityTb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Заказы values (" + IdTb.Text + ",  '" + OrderDateTb.Text + "', '" + ClientTb.Text + "', '" + ProductTb.Text + "', " +
                        "'" + PriceTb.Text + "', '" + QuantityTb.Text + "', '" + AmountTb.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Заказ добавлен");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
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
                    string query = "delete from Заказы where [Код заказа]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Заказ удален");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OrdersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = OrdersDGV.SelectedRows[0].Cells[0].Value.ToString();
            OrderDateTb.Text = OrdersDGV.SelectedRows[0].Cells[1].Value.ToString();
            ClientTb.Text = OrdersDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProductTb.Text = OrdersDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = OrdersDGV.SelectedRows[0].Cells[4].Value.ToString();
            QuantityTb.Text = OrdersDGV.SelectedRows[0].Cells[5].Value.ToString();            
            AmountTb.Text = OrdersDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            double quantity;
            double price;

            price = Convert.ToDouble(PriceTb.Text);
            quantity = Convert.ToDouble(QuantityTb.Text);
         

            switch (guna2ComboBox1.Text)
            {
                case "*":
                    AmountTb.Text = Convert.ToString(price * quantity);
                    break;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || OrderDateTb.Text == "" || ClientTb.Text == "" || ProductTb.Text == "" || PriceTb.Text == "" || QuantityTb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Заказы set Дата='" + OrderDateTb.Text + "', Клиент='" + ClientTb.Text + "', Товар='" + ProductTb.Text + "', Цена='" + PriceTb.Text + "', Количество='" + QuantityTb.Text + "', Сумма ='" + AmountTb.Text + "'  where [Код заказа]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Заказ обновлен");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SearchOrders searchOrders = new SearchOrders();
            searchOrders.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
