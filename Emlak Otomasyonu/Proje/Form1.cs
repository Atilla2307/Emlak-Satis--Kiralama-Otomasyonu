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
    public partial class Form1 : Form
    {
        private string kullaniciTc;
        private string kullaniciSifre;
        public Form1()
        {
            InitializeComponent();
        }


        sqlbaglanti sqlbaglanti = new sqlbaglanti();
        private SqlConnection baglanti;

        private Timer imageChangeTimer;
        private List<Image> resimler = new List<Image>();  
        private int currentImageIndex = 0;

        public void listele()
        {
            panel3.Left = this.Width;
            kayanyazi.Interval = 20;
            kayanyazi.Enabled = true;
            panel4.Visible = false;

            kullaniciTc = Kullanici_bilgi.Tc;
            kullaniciSifre = Kullanici_bilgi.Sifre;
            SqlConnection baglanti = sqlbaglanti.connect;
            baglanti = sqlbaglanti.connect;
            try
            {
                sqlbaglanti.SqlOpen();
                string sorgu = "SELECT k.ilan_id, k.satis_turu, k.konut_tipi, k.metrekare, k.oda_sayisi, k.kat, k.banyo_sayisi, k.bina_yas, k.il, k.ilce, k.fiyat FROM konut_bilgi k";
                SqlCommand komut = new SqlCommand(sorgu, sqlbaglanti.connect);
                SqlDataReader dr = komut.ExecuteReader();

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

                        PictureBox pictureBox = new PictureBox
                        {
                            Width = 280,
                            Height = 200,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.DarkBlue,
                            Location = new Point(10, 20)
                        };

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
                        using (SqlConnection resimBaglanti = new SqlConnection(sqlbaglanti.connect.ConnectionString))
                        {
                            resimBaglanti.Open();
                            string resimSorgu = "SELECT resim FROM resim_tablosu WHERE konut_id = @id";
                            SqlCommand resimKomut = new SqlCommand(resimSorgu, resimBaglanti);
                            resimKomut.Parameters.AddWithValue("@id", dr["ilan_id"]);

                            SqlDataReader resimReader = resimKomut.ExecuteReader();
                            if (resimReader.Read())
                            {
                                byte[] resimBytes = resimReader["resim"] as byte[];
                                if (resimBytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(resimBytes))
                                    {
                                        pictureBox.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                            resimReader.Close();
                        }

                        groupBox.Controls.Add(pictureBox);

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

                        Label lblbanyo = new Label
                        {
                            AutoSize = true,
                            Font = font,
                            Text = "Banyo Sayısı: " + dr["banyo_sayisi"].ToString(),
                            Location = new Point(10, yCoordinate)
                        };
                        groupBox.Controls.Add(lblbanyo);

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

                        Label lblBinayas = new Label
                        {
                            AutoSize = true,
                            Font = font,
                            Text = "Binanın Yaşı: " + dr["bina_yas"].ToString(),
                            Location = new Point(10, yCoordinate)
                        };
                        groupBox.Controls.Add(lblBinayas);

                        yCoordinate += 20;

                        Label lblkonum = new Label
                        {
                            AutoSize = true,
                            Font = font,
                            Text = "Konum: " + dr["il"].ToString() + "/" + dr["ilce"].ToString(),
                            Location = new Point(10, yCoordinate)
                        };
                        groupBox.Controls.Add(lblkonum);

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

                        flowLayoutPanel1.Controls.Add(groupBox);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlbaglanti.connect.State == ConnectionState.Open)
                {
                    sqlbaglanti.SqlClose();
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            gizli_btn.AutoSize = true;

            button3.Enabled = false;
        }


        private void LoadImageToPictureBox(int ilanId, PictureBox pictureBox)
        {
            baglanti = sqlbaglanti.connect;

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

        private void kayanyazi_Tick(object sender, EventArgs e)
        {
            panel3.Left -= 5;
            if (panel3.Right < 0)
            {
                panel3.Left = this.Width;
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ilan_ver ilan_Ver = new ilan_ver();
            ilan_Ver.ShowDialog();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            
        }

        int sayac = 0;
        private void gizli_btn_Click(object sender, EventArgs e)
        {
            panel4.Visible=true; 

            sayac++;

            if (sayac % 1 == 0)
            {
                panel4.Visible = true;
            }

            if (sayac % 2 == 0)
            {
                panel4.Visible = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

            Giris_yap giris_Yap = new Giris_yap();
            giris_Yap.ShowDialog();


            if (!string.IsNullOrEmpty(Giris_yap.buton_text)) 
            { 
                button2.Visible = false;
                gizli_btn.Text = "   " + Giris_yap.buton_text; 
                button3.Enabled = true; 
                gizli_btn.ImageIndex = 1; }

            else
            {

                button2.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ilan_ver ilan_Ver = new ilan_ver();
            ilan_Ver.ShowDialog();
            panel4.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkmak İstediğinize Eminmisiniz?","Duyuru",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (cevap==DialogResult.OK)
            {
                button2.Visible = true;
                gizli_btn.Visible = false;
                button3.Enabled = false;
                panel4.Visible = false; 
            }
                button2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Giris_yap giris = new Giris_yap();

            string kullaniciTc = giris.GetTc();    
            string kullaniciSifre = giris.GetSifre();  

            ilanlarım ilanlarimFormu = new ilanlarım(kullaniciTc, kullaniciSifre);
            ilanlarimFormu.Show();

            panel4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            kisiselVeri kisiselVeri = new kisiselVeri();
            kisiselVeri.ShowDialog();
            panel4.Visible = false;
        }
 

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = txtArama.Text.Trim();

            SqlConnection baglanti = sqlbaglanti.connect;
            try
            {
                sqlbaglanti.SqlOpen();

                string query = @"SELECT k.ilan_id, k.satis_turu, k.konut_tipi, k.metrekare, k.oda_sayisi, k.kat, k.banyo_sayisi, k.bina_yas, k.il, k.ilce, k.fiyat 
                         FROM konut_bilgi k  WHERE k.il LIKE @arama OR k.ilce LIKE @arama";

                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@arama", "%" + aramaMetni + "%");

                SqlDataReader dr = cmd.ExecuteReader();

                flowLayoutPanel1.Controls.Clear();

                if (!dr.HasRows)
                {
                    MessageBox.Show("Arama kriterine uygun sonuç bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    while (dr.Read())
                    {

                        GroupBox groupBox = new GroupBox
                        {
                            Text = dr["konut_tipi"].ToString() + " / " + dr["satis_turu"].ToString(),
                            Width = 300,
                            Height = 400,
                            BackColor = Color.AntiqueWhite
                        };
                        PictureBox pictureBox = new PictureBox
                        {
                            Width = 280,
                            Height = 200,
                            Location = new Point(10, 150),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.Gray
                        };

                        using (SqlConnection resimBaglanti = new SqlConnection(sqlbaglanti.connect.ConnectionString))
                        {
                            resimBaglanti.Open();
                            string resimQuery = "SELECT resim FROM resim_tablosu WHERE konut_id = @id";
                            SqlCommand resimCmd = new SqlCommand(resimQuery, resimBaglanti);
                            resimCmd.Parameters.AddWithValue("@id", dr["ilan_id"]);

                            SqlDataReader resimReader = resimCmd.ExecuteReader();
                            if (resimReader.Read())
                            {
                                byte[] imageBytes = resimReader["resim"] as byte[];
                                if (imageBytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pictureBox.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                            resimReader.Close();
                        }

                        groupBox.Controls.Add(pictureBox);


                        Label lblMetrekare = new Label
                        {
                            Text = "Metrekare: " + dr["metrekare"].ToString() + " m2",
                            AutoSize = true,
                            Location = new Point(10, 20)
                        };
                        groupBox.Controls.Add(lblMetrekare);

                        Label lblOdaSayisi = new Label
                        {
                            Text = "Oda Sayısı: " + dr["oda_sayisi"].ToString(),
                            AutoSize = true,
                            Location = new Point(10, 50)
                        };
                        groupBox.Controls.Add(lblOdaSayisi);

                        Label lblIl = new Label
                        {
                            Text = "Konum: " + dr["il"].ToString() + " / " + dr["ilce"].ToString(),
                            AutoSize = true,
                            Location = new Point(10, 80)
                        };
                        groupBox.Controls.Add(lblIl);

                        Label lblFiyat = new Label
                        {
                            Text = "Fiyat: " + dr["fiyat"].ToString() + " ₺",
                            AutoSize = true,
                            Location = new Point(10, 110),
                            ForeColor = Color.Red,
                            Font = new Font("Arial", 10, FontStyle.Bold)
                        };
                        groupBox.Controls.Add(lblFiyat);

                       
                        flowLayoutPanel1.Controls.Add(groupBox);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlbaglanti.SqlClose();
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void txtArama_Click(object sender, EventArgs e)
        {

            panel4.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
