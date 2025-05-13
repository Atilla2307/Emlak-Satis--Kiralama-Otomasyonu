using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proje
{
    public partial class ilan_ver : Form
    {

        sqlbaglanti sqlbaglanti = new sqlbaglanti();
        SqlConnection baglanti;
        SqlCommand komut;
        String komutsatiri;
        public ilan_ver()
        {
            InitializeComponent();
        }

        string selectedNode;
        string parentNode;
        string grandParentNode;
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = sqlbaglanti.connect;
            SqlTransaction transaction = null;

            try
            {
                baglanti.Open();
                transaction = baglanti.BeginTransaction();

                string konutEkleSorgu = "INSERT INTO konut_bilgi (kullanici_id,satis_turu, konut_tipi, metrekare, oda_sayisi, kat, banyo_sayisi, bina_yas, il, ilce, fiyat) " +
                                        "VALUES (@Tc,@satis_turu, @konut_tipi, @metrekare, @oda_sayisi, @kat, @banyo_sayisi, @bina_yas, @il, @ilce, @fiyat);" +
                                        "SELECT SCOPE_IDENTITY();";

                SqlCommand konutKomut = new SqlCommand(konutEkleSorgu, baglanti, transaction);

                konutKomut.Parameters.AddWithValue("@Tc",Giris_yap.tc_kayit);
                konutKomut.Parameters.AddWithValue("@satis_turu", selectedNode);
                konutKomut.Parameters.AddWithValue("@konut_tipi", parentNode);
                konutKomut.Parameters.AddWithValue("@metrekare", Convert.ToInt32(txt_metrekare.Text));
                konutKomut.Parameters.AddWithValue("@oda_sayisi", combo_oda_say.Text);
                konutKomut.Parameters.AddWithValue("@kat", combo_kat.Text);
                konutKomut.Parameters.AddWithValue("@banyo_sayisi", combo_banyo.Text);
                konutKomut.Parameters.AddWithValue("@bina_yas", combo_yas.Text);
                konutKomut.Parameters.AddWithValue("@il", combo_il.Text);
                konutKomut.Parameters.AddWithValue("@ilce", combo_ilce.Text);
                konutKomut.Parameters.AddWithValue("@fiyat", Convert.ToInt64(txt_fiyat.Text));

                int ilanId = Convert.ToInt32(konutKomut.ExecuteScalar());

                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    if (item is PictureBox pb)
                    {
                        string resimYolu = pb.Tag?.ToString(); 

                        if (!string.IsNullOrEmpty(resimYolu) && File.Exists(resimYolu))
                        {
                            string resimEkleSorgu = "INSERT INTO resim_tablosu (konut_id, resim) VALUES (@konut_id, @resim)";
                            SqlCommand resimKomut = new SqlCommand(resimEkleSorgu, baglanti, transaction);

                            resimKomut.Parameters.AddWithValue("@konut_id", ilanId);

                            byte[] resimBytes = File.ReadAllBytes(resimYolu);
                            resimKomut.Parameters.AddWithValue("@resim", resimBytes);

                            resimKomut.ExecuteNonQuery();
                        }
                    }
                }


                transaction.Commit();
                DialogResult cevap= MessageBox.Show("Konut ve resimler başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cevap == DialogResult.OK) 
                { 
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti != null && baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }





        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
                if (e.Node.Parent==null && e.Node.Parent?.Parent==null)
                {
                    label1.Text = "Hiçbir düğüm seçilmedi!";
                    button1.Enabled = false;
                    return;
                }

                selectedNode = e.Node.Text;
                parentNode = e.Node.Parent != null ? e.Node.Parent.Text : "???"; 
                grandParentNode = e.Node.Parent?.Parent != null ? e.Node.Parent.Parent.Text : "???"; 

                label1.Text = $"Seçilen Öğe: {grandParentNode} / {parentNode} / {selectedNode}";
                label4.Text = $"{grandParentNode} / {parentNode} / {selectedNode}";
                
            
                button1.Enabled = true;
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void ilan_ver_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled=true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_ilce.Items.Clear();
            string secilen = combo_il.SelectedItem.ToString();

            switch (secilen)
            {
                case "İstanbul":
                    combo_ilce.Items.Add("Bağcılar");
                    combo_ilce.Items.Add("Bahçelievler");
                    combo_ilce.Items.Add("Bakırköy");
                    combo_ilce.Items.Add("Başakşehir");
                    combo_ilce.Items.Add("Bayrampaşa");
                    combo_ilce.Items.Add("Beşiktaş");
                    combo_ilce.Items.Add("Beylikdüzü");
                    combo_ilce.Items.Add("Beyoğlu");
                    combo_ilce.Items.Add("Esenler");
                    combo_ilce.Items.Add("Esenyurt");
                    combo_ilce.Items.Add("Fatih");
                    break;

                case "Ankara":
                    combo_ilce.Items.Add("Altındağ");
                    combo_ilce.Items.Add("Beypazarı");
                    combo_ilce.Items.Add("Çamlıdere");
                    combo_ilce.Items.Add("Çankaya");
                    combo_ilce.Items.Add("Etimesgut");
                    combo_ilce.Items.Add("Evren");
                    combo_ilce.Items.Add("Haymana");
                    combo_ilce.Items.Add("Kazan");
                    combo_ilce.Items.Add("Keçiören");
                    combo_ilce.Items.Add("Mamak");
                    combo_ilce.Items.Add("Nallıhan");
                    break;

                case "İzmir":
                    combo_ilce.Items.Add("Bayındır");
                    combo_ilce.Items.Add("Bornova");
                    combo_ilce.Items.Add("Buca");
                    combo_ilce.Items.Add("Çeşme");
                    combo_ilce.Items.Add("Dikili");
                    combo_ilce.Items.Add("Kınık");
                    combo_ilce.Items.Add("Konak");
                    combo_ilce.Items.Add("Menderes");
                    combo_ilce.Items.Add("Menemen");
                    break;

                case "Bursa":
                    combo_ilce.Items.Add("Osmangazi");
                    combo_ilce.Items.Add("Nilüfer");
                    combo_ilce.Items.Add("Yıldırım");
                    combo_ilce.Items.Add("Gemlik");
                    combo_ilce.Items.Add("İnegöl");
                    combo_ilce.Items.Add("Mudanya");
                    combo_ilce.Items.Add("Karacabey");
                    combo_ilce.Items.Add("Büyükorhan");
                    break;

                case "Kocaeli":
                    combo_ilce.Items.Add("İzmit");
                    combo_ilce.Items.Add("Gölcük");
                    combo_ilce.Items.Add("Derince");
                    combo_ilce.Items.Add("Körfez");
                    combo_ilce.Items.Add("Başiskele");
                    combo_ilce.Items.Add("Çayırova");
                    combo_ilce.Items.Add("Gebze");
                    break;

                case "Samsun":
                    combo_ilce.Items.Add("Atakum");
                    combo_ilce.Items.Add("Canik");
                    combo_ilce.Items.Add("İlkadım");
                    combo_ilce.Items.Add("Tekkeköy");
                    combo_ilce.Items.Add("Vezirköprü");
                    combo_ilce.Items.Add("Ayvacık");
                    combo_ilce.Items.Add("Bafra");
                    break;

                case "Giresun":
                    combo_ilce.Items.Add("Bulancak");
                    combo_ilce.Items.Add("Çamoluk");
                    combo_ilce.Items.Add("Dereli");
                    combo_ilce.Items.Add("Espiye");
                    combo_ilce.Items.Add("Eynesil");
                    combo_ilce.Items.Add("Görele");
                    combo_ilce.Items.Add("Keşap");
                    break;

                case "Bingöl":
                    combo_ilce.Items.Add("Adaklı");
                    combo_ilce.Items.Add("Genç");
                    combo_ilce.Items.Add("Karlıova");
                    combo_ilce.Items.Add("Kiğı");
                    combo_ilce.Items.Add("Solhan");
                    combo_ilce.Items.Add("Yedisu");
                    break;

            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                PictureBox clickedPictureBox = sender as PictureBox;

                if (clickedPictureBox != null)
                {
                    flowLayoutPanel1.Controls.Remove(clickedPictureBox);

                    clickedPictureBox.Dispose();

                    MessageBox.Show("Resim kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Resim Seçin";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int mevcutResimSayisi = flowLayoutPanel1.Controls.Count;
                    int secilenResimSayisi = openFileDialog.FileNames.Length;

                    if (mevcutResimSayisi + secilenResimSayisi > 8)
                    {
                        MessageBox.Show("Maksimum 8 resim ekleyebilirsiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(filePath);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Width = 100;
                        pictureBox.Height = 100;
                        pictureBox.Tag = filePath;
                        pictureBox.MouseClick += pictureBox_MouseClick;
                        flowLayoutPanel1.Controls.Add(pictureBox);
                    }

                    MessageBox.Show($"{secilenResimSayisi} adet resim eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ilan_ver_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
