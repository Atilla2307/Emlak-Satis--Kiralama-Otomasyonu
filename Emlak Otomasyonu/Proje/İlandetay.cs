using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class İlandetay : Form
    {
        private SqlConnection baglanti;

        public İlandetay(int konutId, SqlConnection connection)
        {
            InitializeComponent(); 
            this.konutId = konutId; 
            baglanti = connection;
            LoadIlanDetails(konutId);
        }
        private void LoadIlanDetails(int konutId)
        {
            try
            {
                string sorgu = "SELECT * FROM konut_bilgi WHERE ilan_id = @ilan_id";
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@ilan_id", konutId);

                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblUstyazi.Text = dr["konut_tipi"].ToString() + "/" + dr["satis_turu"].ToString();
                            lblMetrekare.Text = "Metrekare: " + dr["metrekare"].ToString();
                            lblOdaSayisi.Text = "Oda Sayısı: " + dr["oda_sayisi"].ToString();
                            lblBanyoSayisi.Text = "Banyo Sayısı: " + dr["banyo_sayisi"].ToString();
                            lblKat.Text = "Kat: " + dr["kat"].ToString();
                            lblBinaYasi.Text = "Bina Yaşı: " + dr["bina_yas"].ToString();
                            lblKonum.Text = "Konum: " + dr["il"].ToString() + "/" + dr["ilce"].ToString();
                            lblFiyat.Text = "Fiyat: " + dr["fiyat"].ToString() + "₺";
                        }
                    }
                }
                LoadImageToPictureBox(konutId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti != null && baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        private void LoadImageToPictureBox(int konutId)
        {
            string sorgu = "SELECT resim FROM resim_tablosu WHERE konut_id = @konut_id";

            using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
            {
                cmd.Parameters.AddWithValue("@konut_id", konutId);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] imageBytes = reader["resim"] as byte[];
                        if (imageBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pictureBoxIlan.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
        }


        private void İlandetay_Load(object sender, EventArgs e)
        {

        }
        private int konutId;

       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = @"SELECT k.telefon  FROM kullanici_bilgi k INNER JOIN konut_bilgi c ON k.Tc = c.kullanici_id WHERE c.ilan_id = @ilan_id";

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@ilan_id", konutId);


                    object telefon = komut.ExecuteScalar();
                    if (telefon != null)
                    {
                       DialogResult= MessageBox.Show("İlanı verenin telefon numarası: " + telefon.ToString(), "Telefon Numarası", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        
                        if (DialogResult == DialogResult.OK) 
                        {
                            Clipboard.SetText(telefon.ToString());
                            MessageBox.Show("Satıcının İletişim Numarası Panoya Kopyalandı","Bilgilendirme",MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Telefon numarası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }


        private List<Image> resimler = new List<Image>();
        private int currentImageIndex = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            LoadImages(konutId);

            if (resimler.Count > 0)
            {
                pictureBoxIlan.Image = resimler[currentImageIndex];

               
                    currentImageIndex++;
                    if (currentImageIndex >= resimler.Count)
                    {
                        currentImageIndex = 0; 
                    }

                    pictureBoxIlan.Image = resimler[currentImageIndex];
                
            }
            else
            {
                MessageBox.Show("Hiç resim bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (resimler.Count > 0)
            {
                pictureBoxIlan.Image = resimler[currentImageIndex];

                currentImageIndex--;

                if (currentImageIndex < 0)
                {
                    currentImageIndex = resimler.Count - 1; 
                }

                pictureBoxIlan.Image = resimler[currentImageIndex];
            }
            else
            {
                MessageBox.Show("Hiç resim bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImages(int konutId)
        {
            string sorgu = "SELECT resim FROM resim_tablosu WHERE konut_id = @konut_id";

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@konut_id", konutId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] imageBytes = reader["resim"] as byte[];
                            if (imageBytes != null)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    resimler.Add(Image.FromStream(ms));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yükleme hatası: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        private void İlandetay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.listele();
        }
    }
}
