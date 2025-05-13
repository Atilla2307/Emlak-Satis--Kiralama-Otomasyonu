using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class ilanlarım : Form
    {
        private string kullaniciTc;
        private string kullaniciSifre;
        private SqlConnection baglanti;
        public ilanlarım(string tc, string sifre)
        {
            InitializeComponent();
            kullaniciTc = tc;
            kullaniciSifre = sifre;
        }

            SqlCommand komut;
            String komutsatiri;

        private void LoadImageToPictureBox(int ilanId, PictureBox pictureBox)
        {
            string sorgu = "SELECT resim FROM resim_tablosu WHERE konut_id = @konut_id";

            using (SqlConnection yeniBaglanti = new SqlConnection(baglanti.ConnectionString))
            {
                yeniBaglanti.Open();

                using (SqlCommand cmd = new SqlCommand(sorgu, yeniBaglanti))
                {
                    cmd.Parameters.AddWithValue("@konut_id", ilanId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] imageBytes = reader["resim"] as byte[];
                            if (imageBytes != null)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    pictureBox.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private PictureBox dynamicPictureBox;

        Kullanici_bilgi kullanici_Bilgi = new Kullanici_bilgi();
        sqlbaglanti sqlbaglanti=new sqlbaglanti();
        private List<PictureBox> resimler = new List<PictureBox>();
        private int resimIndex = 0;
        int konutId;


        private void ilanlarım_Load(object sender, EventArgs e)
        {
            kullaniciTc = Kullanici_bilgi.Tc;
            kullaniciSifre = Kullanici_bilgi.Sifre;
            baglanti = sqlbaglanti.connect;

            try
            {
                sqlbaglanti.SqlOpen();
                string sorgu = "SELECT k.ilan_id, k.satis_turu, k.konut_tipi, k.metrekare, k.oda_sayisi, k.kat, k.banyo_sayisi, k.bina_yas, k.il, k.ilce, k.fiyat FROM konut_bilgi k " +
                               "INNER JOIN kullanici_bilgi u ON k.kullanici_id = u.Tc WHERE u.Tc = @Tc";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@Tc", kullaniciTc);

                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        if (!dr.HasRows)
                        {
                            MessageBox.Show("Veri bulunamadı.");
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                Font font = new Font("Roboto", 11, FontStyle.Bold);

                                GroupBox groupBox = new GroupBox
                                {
                                    Text = dr["konut_tipi"].ToString() + "/" + dr["satis_turu"].ToString(),
                                    Width = 300,
                                    Height = 400,
                                    BackColor = Color.AntiqueWhite
                                };

                                flowLayoutPanel1.Controls.Add(groupBox);


                                PictureBox pictureBox = new PictureBox
                                {
                                    Width = 280,
                                    Height = 200,
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    BackColor = Color.DarkBlue,
                                    Location = new Point(10, 20)
                                };

                                groupBox.Controls.Add(pictureBox);


                                int konutId = Convert.ToInt32(dr["ilan_id"]);
                                LoadImageToPictureBox(konutId, pictureBox);

                                groupBox.Click += (s, ev) =>
                                {
                                    İlandetay detayForm = new İlandetay(konutId, baglanti);
                                    detayForm.Show();
                                }; 

                                pictureBox.Click += (s, ev) =>
                                {
                                    İlandetay detayForm = new İlandetay(konutId, baglanti);
                                    detayForm.Show();
                                };

                                int yCoordinate = 230;

                                Label lblMetrekare = new Label
                                {
                                    Font = font,
                                    AutoSize = true,
                                    Text = "Metrekare: " + dr["metrekare"].ToString() + "m2",
                                    Location = new Point(10, yCoordinate)
                                };
                                groupBox.Controls.Add(lblMetrekare);

                                yCoordinate += 20;

                                Label lblOdaSayisi = new Label
                                {
                                    AutoSize = true,
                                    Font = font,
                                    Text = "Oda Sayısı: " + dr["oda_sayisi"].ToString(),
                                    Location = new Point(10, yCoordinate)
                                };
                                groupBox.Controls.Add(lblOdaSayisi);

                                yCoordinate += 20;

                                Label lblBanyo = new Label
                                {
                                    AutoSize = true,
                                    Font = font,
                                    Text = "Banyo Sayısı: " + dr["banyo_sayisi"].ToString(),
                                    Location = new Point(10, yCoordinate)
                                };
                                groupBox.Controls.Add(lblBanyo);

                                yCoordinate += 20;

                                Label lblKat = new Label
                                {
                                    AutoSize = true,
                                    Font = font,
                                    Text = "Kat: " + dr["kat"].ToString(),
                                    Location = new Point(10, yCoordinate)
                                };
                                groupBox.Controls.Add(lblKat);

                                yCoordinate += 20;

                                Label lblBinaYas = new Label
                                {
                                    AutoSize = true,
                                    Font = font,
                                    Text = "Binanın Yaşı: " + dr["bina_yas"].ToString(),
                                    Location = new Point(10, yCoordinate)
                                };
                                groupBox.Controls.Add(lblBinaYas);

                                yCoordinate += 20;

                                Label lblKonum = new Label
                                {
                                    AutoSize = true,
                                    Font = font,
                                    Text = "Konum: " + dr["il"].ToString() + "/" + dr["ilce"].ToString(),
                                    Location = new Point(10, yCoordinate)
                                };
                                groupBox.Controls.Add(lblKonum);

                                yCoordinate += 35;

                                Label lblFiyat = new Label
                                {
                                    ForeColor = Color.Red,
                                    Font = new Font("Verdana", 13, FontStyle.Bold),
                                    AutoSize = true,
                                    Text = "Fiyat: " + dr["fiyat"].ToString() + "₺",
                                    Location = new Point(100, yCoordinate)
                                };
                                groupBox.Controls.Add(lblFiyat);

                                Button btnKaldir = new Button
                                {
                                    Text = "Kaldır",
                                    ForeColor = Color.White,
                                    BackColor = Color.Red,
                                    Width = 60,
                                    Height = 30,
                                    Location = new Point(210, 230) 
                                }; 
                                
                                groupBox.Controls.Add(btnKaldir);

                                btnKaldir.Click += (s, ev) =>
                                {
                                    DialogResult dialogResult = MessageBox.Show("Bu ilanı silmek istediğinizden emin misiniz?", "İlanı Kaldır", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            string resimSilSorgu = "DELETE FROM resim_tablosu WHERE konut_id = @ilanId";
                                            using (SqlCommand resimSilKomut = new SqlCommand(resimSilSorgu, baglanti))
                                            {
                                                if (baglanti.State == ConnectionState.Closed)
                                                {
                                                    baglanti.Open();
                                                }

                                                resimSilKomut.Parameters.AddWithValue("@ilanId", konutId);
                                                resimSilKomut.ExecuteNonQuery();
                                            }

                                            string konutSilSorgu = "DELETE FROM konut_bilgi WHERE ilan_id = @ilanId";
                                            using (SqlCommand konutSilKomut = new SqlCommand(konutSilSorgu, baglanti))
                                            {
                                                konutSilKomut.Parameters.AddWithValue("@ilanId", konutId);
                                                konutSilKomut.ExecuteNonQuery();
                                            }

                                            flowLayoutPanel1.Controls.Remove(groupBox);
                                            MessageBox.Show("İlan ve resimler başarıyla kaldırıldı.");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            if (baglanti.State == ConnectionState.Open)
                                            {
                                                baglanti.Close();
                                            }
                                        }

                                    }
                                };



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti != null && baglanti.State == ConnectionState.Open)
                {
                    sqlbaglanti.SqlClose();
                }
            }

        }


        private void groupBox_click(object sender, EventArgs e)
        {
            İlandetay detayForm = new İlandetay(konutId, baglanti);
            detayForm.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

