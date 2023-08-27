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

namespace Test_Sefer_Seyahat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection bgl = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=TestYolcuBilet;Integrated Security=True");
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komutEkle = new SqlCommand("insert into TBLYOLCUBILGI (AD,SOYAD,TELEFON,TC,CİNSİYET,MAIL) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl);
            komutEkle.Parameters.AddWithValue("@p1", TxTAD.Text);
            komutEkle.Parameters.AddWithValue("@p2", TxTSoyad.Text);
            komutEkle.Parameters.AddWithValue("@p3", MskTel.Text);
            komutEkle.Parameters.AddWithValue("@p4", MaskTc.Text);
            var cinsiyet=CmbCinsiyet.Text;
            if (cinsiyet == "ERKEK")
            {
                komutEkle.Parameters.AddWithValue("@p5",0);
            }
            else
            {
                komutEkle.Parameters.AddWithValue("@p5",1);
            }
            komutEkle.Parameters.AddWithValue("@p6", TxtMail.Text);
            komutEkle.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Yolcu Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void BtnKaptanEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKAPTAN (KAPTANNO,ADSOYAD,TELEFON) values (@p1,@p2,@p3)", bgl);
            komut.Parameters.AddWithValue("@p1", TxtKaptanNo.Text);
            komut.Parameters.AddWithValue("@p2", TxtAdSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kaptan Bilgisi Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void BtnSefer_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERBILGI(KALKIS,VARIS,TARIH,SAAT,KAPTAN,FİYAT) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl);
            komut.Parameters.AddWithValue("@p1", TxtKalkıs.Text);
            komut.Parameters.AddWithValue("@p2", TxtVarıs.Text);
            komut.Parameters.AddWithValue("@p3", MskTarih.Text);
            komut.Parameters.AddWithValue("@p4", MskSaat.Text);
            komut.Parameters.AddWithValue("@p5", MskKaptan.Text);
            komut.Parameters.AddWithValue("@p6", TxtFiyat.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Sefer Bilgisi Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            seferListesi();


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        void seferListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select*from TBLSEFERBILGI", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            seferListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtSefer.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "9";
        }

        private void BtnRezervasyon_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERDETAY(SEFERNO,YOLCUTC,KOLTUK) values (@p1,@p2,@p3)", bgl);
            komut.Parameters.AddWithValue("@p1", TxtSefer.Text);
            komut.Parameters.AddWithValue("@p2", msktc.Text);
            komut.Parameters.AddWithValue("@p3", TxtKoltukNo.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Rezervasyon Bilgisi Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
