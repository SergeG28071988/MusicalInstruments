using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MusicalInstruments
{
    public partial class InstrumentsForm : Form
    {
        public InstrumentsForm()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\T1000\Desktop\Musicalinstruments.mdb");

        private void Populate()
        {
            conn.Open();
            string query = "select * from Инструменты";
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            InstrumentsDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || CategoryCb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Инструменты values (" + IdTb.Text + ",  '" + NameTb.Text + "', '" +  CategoryCb.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Инструменты добавлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InstrumentsForm_Load(object sender, EventArgs e)
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
                    string query = "delete from Инструменты where [Код инструмента]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Инструменты удалены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void InstrumentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = InstrumentsDGV.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = InstrumentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            CategoryCb.Text = InstrumentsDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || CategoryCb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Инструменты set Название='" + NameTb.Text + "', Категория='" + CategoryCb.Text + "' where [Код инструмента]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Инструменты обновлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
