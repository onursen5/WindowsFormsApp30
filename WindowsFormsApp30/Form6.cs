using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp30
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\Ozan;Initial Catalog=master;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            this.Hide();
            Form3 frm2 = new Form3();
            frm2.ShowDialog();
            this.Close();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            this.Hide();
            Form5 frm2 = new Form5();
            frm2.ShowDialog();
            this.Close();
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 geri = new Form2();
            geri.ShowDialog();
            this.Close();

            Form2 frm2 = new Form2();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
