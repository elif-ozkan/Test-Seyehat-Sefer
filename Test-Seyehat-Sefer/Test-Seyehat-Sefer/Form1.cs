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

namespace Test_Seyehat_Sefer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01
        //Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog="Film Arşivim";Integrated Security=True
        SqlConnection baglantı = new SqlConnection(@"Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Test Yolcu Bilet;Integrated Security=True");

        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBLSEFERBILGI",baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut=new SqlCommand("insert into TBLYOLCUBILGI(ad,soyad,telefon,tc,cınsıyet,maıl)values(@p1,@p2,@p3,@p4,@p5,@p6)",baglantı);
            komut.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",MskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", MskMail.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Yolcu Kaydınız başarıyla gerçekleşmiştir","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void MskSoyad_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void BtnKaptan_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKAPTAN(kaptanno,adsoyad,telefon)values(@p1,@p2,@p3)", baglantı);
            komut.Parameters.AddWithValue("@p1",TxtKaptanNo.Text);
            komut.Parameters.AddWithValue("@p2", TxtADSOYAD.Text);
            komut.Parameters.AddWithValue("@p3",maskedTextBox5.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kaptan bilgisi sisteme kaydedildi");

        }

        private void BtnSeferOluştur_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut=new SqlCommand("insert into TBLSEFERBILGI(kalkıs,varıs,tarıh,saat,kaptan,fıyat)values(@p1,@p2,@p3,@p4,@p5,@p6)",baglantı);
            komut.Parameters.AddWithValue("@p1", TxtKalkış.Text);
            komut.Parameters.AddWithValue("@p2", TxtVarış.Text);
            komut.Parameters.AddWithValue("@p3", MskTarih.Text);
            komut.Parameters.AddWithValue("@p4",MskSaat.Text);
            komut.Parameters.AddWithValue("@p5", MskKaptan.Text);
            komut.Parameters.AddWithValue("@p6", TxtFiyat.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void TxtVarış_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "2";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text="3"; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text="4"; 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text="5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text = "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TxtKoltuk.Text="9"; 
        }

        private void BtnRezervasyon_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERDETAY(seferno,yolcutc,koltuk)values(@p1,@p2,@p3)", baglantı);
            komut.Parameters.AddWithValue("@p1",TxtSefer.Text);
            komut.Parameters.AddWithValue("@p2", MskKimlik.Text);
            komut.Parameters.AddWithValue("@p3", TxtKoltuk.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Rezervasyonunuz Yapıldı");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtSefer.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString(); 
        }
    }
}
