using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proje
{
    public partial class kisiselVeri : Form
    {
        private string kullaniciTc;
        public kisiselVeri()
        {
            InitializeComponent();
        }

        sqlbaglanti sqlbaglanti = new sqlbaglanti();
        Kullanici_bilgi kullanici_Bilgi = new Kullanici_bilgi();
        Giris_yap giris = new Giris_yap();
        SqlConnection baglanti;

        private void kisiselVeri_Load(object sender, EventArgs e)
        {

            listele();

            this.Width = groupBox1.Width + 50;

            label1.Width = this.Width;




        }


        private void listele()
        {
            try
            {
                sqlbaglanti.SqlOpen();
                kullaniciTc = Kullanici_bilgi.Tc;
                baglanti = sqlbaglanti.connect;
                string sorgu = "SELECT Tc, ad_soyad, telefon, sifre FROM kullanici_bilgi WHERE Tc = @Tc";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Tc", kullaniciTc);

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblTc.Text = "Tc: " + dr["Tc"].ToString();
                        lblAd.Text = "Ad: " + dr["ad_soyad"].ToString();
                        lblSoyad.Text = "Telefon: " + dr["telefon"].ToString();
                        lblTelefon.Text = "Şifre: " + dr["sifre"].ToString();

                        textBox1.Text = dr["Tc"].ToString();
                        textBox2.Text = dr["ad_soyad"].ToString();
                        textBox3.Text = dr["telefon"].ToString();
                        textBox4.Text = dr["sifre"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                }

                dr.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hata " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Width = 820;
            this.Width = 820;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string isim;
        private void button2_Click(object sender, EventArgs e)
        {



            this.Width = groupBox1.Width + 50;

            label1.Width = this.Width;

            try
            {
                sqlbaglanti.SqlOpen();

                baglanti = sqlbaglanti.connect;
                string sorgu = "UPDATE kullanici_bilgi SET Ad_Soyad = @AdSoyad, Telefon = @Telefon, Sifre = @Sifre WHERE Tc = @Tc";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@Tc", textBox1.Text.Trim());         
                komut.Parameters.AddWithValue("@AdSoyad", textBox2.Text.Trim());  
                komut.Parameters.AddWithValue("@Telefon", textBox3.Text.Trim());   
                komut.Parameters.AddWithValue("@Sifre", textBox4.Text.Trim());     

                try
                {
                    int rowsAffected = komut.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        listele();
                        MessageBox.Show("Kayıt başarıyla güncellendi.");



                        Form1 frm1 = new Form1();
                        isim = textBox2.Text;

                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    sqlbaglanti.SqlClose();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void lblTc_Click(object sender, EventArgs e)
        {

        }
    }
}
