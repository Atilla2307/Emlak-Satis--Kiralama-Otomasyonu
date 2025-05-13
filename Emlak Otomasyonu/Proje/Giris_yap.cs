using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.ComponentModel.Design;
using System.Reflection.Emit;

namespace Proje
{
    public partial class Giris_yap : Form
    {
        sqlbaglanti sqlbaglanti = new sqlbaglanti();

        SqlConnection baglanti;
        SqlCommand komut;
        String komutsatiri;
        public Giris_yap()
        {
            InitializeComponent();
        }

        private void yeni_uye_kayit_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                baglanti = sqlbaglanti.connect;

                sqlbaglanti.SqlOpen();

                komutsatiri = "insert into kullanici_bilgi(Tc,ad_soyad,telefon,sifre) values (@Tc,@ad_soyad,@telefon,@sifre)";
                komut = new SqlCommand(komutsatiri, baglanti);


                komut.Parameters.AddWithValue("@Tc", txt_tc.Text);
                komut.Parameters.AddWithValue("@ad_soyad", txt_nsame.Text);
                komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
                komut.Parameters.AddWithValue("@sifre", txt_sifre.Text);

                komut.ExecuteNonQuery();
                Temizle();


                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                MessageBox.Show("İşlem Başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            finally
            {

                baglanti.Close();
                groupBox1.Visible = false;
                groupBox2.Visible = true;

                this.Height = 420;
                label8.Text = "Giriş yap";
            }
        }

        public static string buton_text;
        public static string tc_kayit;
        private void kayitli_giris_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source=ATILLA\\SQLEXPRESS01;Initial Catalog=emlak;Integrated Security=True;Encrypt=False");
                string sorgu = "SELECT Tc, sifre, ad_soyad FROM kullanici_bilgi WHERE Tc = @Tc AND sifre = @sifre";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Tc", txt_kayitli_tc.Text);
                komut.Parameters.AddWithValue("@sifre", txt_kayitli_sifre.Text);
                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    Giris_yap giris = new Giris_yap();


                    string adSoyad = dr["ad_soyad"].ToString();
                    buton_text = adSoyad;

                    Kullanici_bilgi.Tc = txt_kayitli_tc.Text;
                    Kullanici_bilgi.Sifre = txt_kayitli_sifre.Text;

                    tc_kayit = dr["Tc"].ToString();

                    


                    DialogResult cevap = MessageBox.Show("Giriş Başarılı!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (cevap==DialogResult.OK) 
                    {
                        this.Close();
                    }
                }
                else
                {
                    buton_text = string.Empty;
                    MessageBox.Show("Hatalı TC veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr.Close();
                baglanti.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        public string GetTc()
        {
            return txt_kayitli_tc.Text;
        }

        public string GetSifre()
        {
            return txt_kayitli_sifre.Text;
        }

        public void Temizle()
        {
            txt_kayitli_sifre.Clear();
            txt_kayitli_tc.Clear();
            txt_nsame.Clear();
            txt_sifre.Clear();
            txt_tc.Clear();
            txt_telefon.Clear();
        }

        
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            label8.Text = "Giriş Yap";
            this.Height = 420;
            this.AcceptButton = kayitli_giris;
            Temizle();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            groupBox1.Visible = true;
            groupBox2.Visible = false;
            label8.Text = "Kayıt Ol";
            this.Height = 580;
            this.AcceptButton = yeni_uye_kayit;
            Temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
        private void button2_Click(object sender, EventArgs e)
        {
            txt_sifre.UseSystemPasswordChar = true;
            button3.Visible = true;
            button2.Visible = false;

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_sifre.UseSystemPasswordChar = false;
            button3.Visible = false;
            button2.Visible = true;
        }

        private void Giris_yap_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            this.AcceptButton = kayitli_giris;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_kayitli_sifre.UseSystemPasswordChar = true;
            button4.Visible = true;
            button5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_kayitli_sifre.UseSystemPasswordChar = false;
            button4.Visible = false;
            button5.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
       

    }
}
