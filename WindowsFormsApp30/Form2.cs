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
    public partial class Form2 : Form
    {
        Form3 form3 = new Form3();
        public Form2()
        {
            InitializeComponent();
            form3.tamam_listele();
            
        }
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\Ozan;Initial Catalog=master;Integrated Security=True");

       private void tamam_listele()
        {

        }

    
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Yönetici İşlemleri";
            label13.ForeColor = Color.DarkBlue;
            label13.Text = Form1.adi + "" + Form1.soyadi;
            maskedTextBox1.MaxLength = 9;
            maskedTextBox4.MaxLength = 4;
            textBox4.MaxLength = 10;
            tamam_listele();
            maskedTextBox1.Mask = "000000000";
            maskedTextBox4.Mask = "0000";
            maskedTextBox2.Text.ToUpper();
            maskedTextBox3.Text.ToUpper();
           



            comboBox1.Items.Add("İlköğretim"); comboBox1.Items.Add("Ortaöğretim"); comboBox1.Items.Add("Lise"); comboBox1.Items.Add("Üniversite");
            comboBox2.Items.Add("Yönetici"); comboBox2.Items.Add("İşçi"); comboBox2.Items.Add("Aşçı"); comboBox2.Items.Add("Şoför");
            comboBox2.Items.Add("Güvenlik");
            comboBox3.Items.Add("Mutfak"); comboBox3.Items.Add("Sanayi"); comboBox3.Items.Add("Minibüs"); comboBox3.Items.Add("Büro");
            comboBox3.Items.Add("Güvenlik Bürosu");
            comboBox4.Items.Add("BAY"); comboBox4.Items.Add("BAYAN");
            

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("mm"));
            int gun = int.Parse(zaman.ToString("dd"));
            dateTimePicker1.MinDate = new DateTime(1970, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(2005, 1, 1);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            

          
            
 

        }


      
      
         
           


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox1.Text.Length < 9)
                errorProvider1.SetError(maskedTextBox1, "Tc Kimlik No 9 Karakterli Olmalı!");
            else
                errorProvider1.Clear();
        }
            

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator
                (e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void maskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator
                (e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

       

       

      

       

        

        private void button7_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void button6_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            this.Hide();
            Form6 frm2 = new Form6();
            frm2.ShowDialog();
            this.Close();
            connection.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
                label14.ForeColor = Color.Red;
            else
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string kayit = "DELETE FROM tamam WHERE tcno=@tcno";
                    SqlCommand komut = new SqlCommand(kayit, connection);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox1.Text);
                    komut.ExecuteNonQuery();
                    connection.Close();
                    tamam_listele();
                    MessageBox.Show("Bir Kullanıcımız Artık Yok!");
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message);

                }
                label14.ForeColor = Color.White;
                maskedTextBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
                label14.ForeColor = Color.Red;
            if (maskedTextBox2.Text == "")
                label15.ForeColor = Color.Red;
            if (maskedTextBox3.Text == "")
                label16.ForeColor = Color.Red;
            if (textBox4.Text == "")
                label18.ForeColor = Color.Red;
            if (comboBox1.Text == "")
                label19.ForeColor = Color.Red;
            if (comboBox2.Text == "")
                label20.ForeColor = Color.Red;
            if (comboBox3.Text == "")
                label22.ForeColor = Color.Red;
            if (comboBox4.Text == "")
                label23.ForeColor = Color.Red;
            if (maskedTextBox4.Text == "")
                label24.ForeColor = Color.Red;
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string kayit = "UPDATE tamam SET tcno=@tcno,adi=@adi,soyadi=@soyadi,yetki=@yetki,kullaniciadi=@kullaniciadi,cinsiyeti=@cinsiyeti,mezuniyeti=@mezuniyeti,datetimepicker=@datetimepicker,gorevi=@gorevi,gorevyeri=@gorevyeri,maasi=@maasi where tcno=@tcno";
                    SqlCommand komut = new SqlCommand(kayit, connection);
                    komut = new SqlCommand(kayit, connection);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox1.Text);
                    komut.Parameters.AddWithValue("@adi", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@soyadi", maskedTextBox3.Text);  
                    if (radioButton1.Checked == true)
                        komut.Parameters.AddWithValue("@yetki", radioButton1.Text);
                    else
                        komut.Parameters.AddWithValue("@yetki", radioButton2.Text);
                    komut.Parameters.AddWithValue("@kullaniciadi", textBox4.Text);
                    komut.Parameters.AddWithValue("@cinsiyeti", comboBox4.Text);
                    komut.Parameters.AddWithValue("@mezuniyeti", comboBox1.Text);
                    komut.Parameters.AddWithValue("@datetimepicker", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@gorevi", comboBox2.Text);
                    komut.Parameters.AddWithValue("@gorevyeri", comboBox3.Text);
                    komut.Parameters.AddWithValue("@maasi", maskedTextBox4.Text);
                    komut.ExecuteNonQuery();
                    connection.Close();
                    tamam_listele();
                    MessageBox.Show("Çalışanımız Artık Yeni Bir Bilgiye Sahip");

                }
                catch (Exception )
                {

                }
                label14.ForeColor = Color.White;
                label15.ForeColor = Color.White;
                label16.ForeColor = Color.White;
                label18.ForeColor = Color.White;
                label19.ForeColor = Color.White;
                label20.ForeColor = Color.White;
                label22.ForeColor = Color.White;
                label23.ForeColor = Color.White;
                label24.ForeColor = Color.White;
            }
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            textBox4.Clear();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text== "")
               label14.ForeColor = Color.Red;
            if (maskedTextBox2.Text == "")
                label15.ForeColor = Color.Red;
            if (maskedTextBox3.Text == "")
                label16.ForeColor = Color.Red;
            if (textBox4.Text == "")
                label18.ForeColor = Color.Red;
            if (comboBox1.Text == "")
                label19.ForeColor = Color.Red;
            if (comboBox2.Text == "")
            label20.ForeColor = Color.Red;
            if (comboBox3.Text == "")
                label22.ForeColor = Color.Red;
            if (comboBox4.Text == "")
                label23.ForeColor = Color.Red;
            if (maskedTextBox4.Text == "")
                label24.ForeColor = Color.Red;
            else
            {
                try
                {
                    connection.Open();
                    String kayit = "insert into tamam(tcno,adi,soyadi,yetki,kullaniciadi,cinsiyeti,mezuniyeti,datetimepicker,gorevi,gorevyeri,maasi) values (@tcno,@adi,@soyadi,@yetki,@kullaniciadi,@cinsiyeti,@mezuniyeti,@dogumtarihi,@gorevi,@gorevyeri,@maasi)";

                    SqlCommand komut = new SqlCommand(kayit, connection);
                    komut.Parameters.AddWithValue("tcno", maskedTextBox1.Text);
                    komut.Parameters.AddWithValue("@adi", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@soyadi", maskedTextBox3.Text);
                    if (radioButton1.Checked == true)
                        komut.Parameters.AddWithValue("@yetki", radioButton1.Text);
                    else if (radioButton2.Checked == true)
                        komut.Parameters.AddWithValue("@yetki", radioButton2.Text);
                    komut.Parameters.AddWithValue("@kullaniciadi", textBox4.Text);
                    komut.Parameters.AddWithValue("@cinsiyeti", comboBox4.Text);
                    komut.Parameters.AddWithValue("@mezuniyeti", comboBox1.Text);
                    komut.Parameters.AddWithValue("@dogumtarihi", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@gorevi", comboBox2.Text);
                    komut.Parameters.AddWithValue("@gorevyeri", comboBox3.Text);
                    komut.Parameters.AddWithValue("@maasi", maskedTextBox4.Text);
                    komut.ExecuteNonQuery();
                    connection.Close();
                    tamam_listele();
                    MessageBox.Show("Artık Yeni Bir Çalışanımız Var");
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Bilgileri Kontrol Ediniz!");
                }
                label14.ForeColor = Color.White;            
                label15.ForeColor = Color.White;
                label16.ForeColor = Color.White;   
                label18.ForeColor = Color.White;
                label19.ForeColor = Color.White;
                label20.ForeColor = Color.White;
                label22.ForeColor = Color.White;
                label23.ForeColor = Color.White;
                label24.ForeColor = Color.White;
            }
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            this.Hide();
            Form5 frm2 = new Form5();
            frm2.ShowDialog();
            this.Close();
            connection.Close();
        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            label14.ForeColor = Color.White;
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
            label15.ForeColor = Color.White;
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
            label16.ForeColor = Color.White;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label17.ForeColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label18.ForeColor = Color.White;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label19.ForeColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label20.ForeColor = Color.White;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label21.ForeColor = Color.White;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label22.ForeColor = Color.White;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label23.ForeColor = Color.White;
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            label24.ForeColor = Color.White;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
  
   
}
