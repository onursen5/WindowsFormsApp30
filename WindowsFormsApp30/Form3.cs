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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\Ozan;Initial Catalog=master;Integrated Security=True");

        
        SqlDataAdapter da;


        

        public void tamam_listele()
        {
            
            connection.Open();
            da = new SqlDataAdapter("SELECT * FROM tamam", connection);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {




        }

        
     

        private void button2_Click_1(object sender, EventArgs e)
        {
            

           








        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            da = new SqlDataAdapter("SELECT * FROM tamam", connection);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();

 
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
                Form2 geri = new Form2();
                geri.maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["tcno"].Value.ToString();
                geri.maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["adi"].Value.ToString();
                geri.maskedTextBox3.Text = dataGridView1.CurrentRow.Cells["soyadi"].Value.ToString();
                geri.radioButton1.Text = dataGridView1.CurrentRow.Cells["yetki"].Value.ToString();
                geri.textBox4.Text = dataGridView1.CurrentRow.Cells["kullaniciadi"].Value.ToString();
                geri.comboBox1.Text = dataGridView1.CurrentRow.Cells["cinsiyeti"].Value.ToString();
                geri.comboBox2.Text = dataGridView1.CurrentRow.Cells["mezuniyeti"].Value.ToString();
                geri.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["datetimepicker"].Value.ToString();
                geri.comboBox3.Text = dataGridView1.CurrentRow.Cells["gorevi"].Value.ToString();
                geri.comboBox4.Text = dataGridView1.CurrentRow.Cells["gorevyeri"].Value.ToString();
                geri.maskedTextBox4.Text = dataGridView1.CurrentRow.Cells["maasi"].Value.ToString();
                this.Hide();
                geri.ShowDialog();
                this.Close();
            
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="")
            {
                MessageBox.Show("Bu İsimde Bir Çalışanınız Yok!");
            }
            else
                connection.Open();
            SqlCommand komut = new SqlCommand("Select * from tamam where adi like '%" + textBox1.Text + "%'", connection);
            da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
            textBox1.Clear();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form6 geri = new Form6();
            geri.ShowDialog();
            this.Close();

            Form6 frm2 = new Form6();
        }
    }
}
 