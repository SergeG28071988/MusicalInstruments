using System;
using System.Windows.Forms;

namespace MusicalInstruments
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm clients = new ClientsForm();
            clients.Show();
            this.Hide();
        }

        private void InstrumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstrumentsForm instruments = new InstrumentsForm();
            instruments.Show();
            this.Hide();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersForm orders = new OrdersForm();
            orders.Show();
            this.Hide();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор программы Музыкальные инструменты: Александра. \nДата релиза: 25.05.2022 г.", "Внимание!!!");
        }
    }
}
