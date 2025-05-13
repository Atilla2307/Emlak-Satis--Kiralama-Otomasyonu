namespace Proje
{
    partial class ilan_ver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Daire");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Çiftlik Evi");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Dağ Evi");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Köy Evi");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Müstakil Ev");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Satılık", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Daire");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Çiftlik Evi");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Dağ Evi");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Köy Evi");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Müstakil Ev");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Kiralık", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Konut", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode12});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ilan_ver));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txt_fiyat = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.combo_ilce = new System.Windows.Forms.ComboBox();
            this.txt_metrekare = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.combo_yas = new System.Windows.Forms.ComboBox();
            this.combo_il = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.combo_banyo = new System.Windows.Forms.ComboBox();
            this.combo_kat = new System.Windows.Forms.ComboBox();
            this.combo_oda_say = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 501);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Konut";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(416, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Devam";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.treeView1.Location = new System.Drawing.Point(6, 25);
            this.treeView1.Name = "treeView1";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode1.Name = "daire";
            treeNode1.Text = "Daire";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode2.Name = "ciftlikevi";
            treeNode2.Text = "Çiftlik Evi";
            treeNode3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode3.Name = "dagevi";
            treeNode3.Text = "Dağ Evi";
            treeNode4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode4.Name = "koyevi";
            treeNode4.Text = "Köy Evi";
            treeNode5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode5.Name = "mustakil";
            treeNode5.Text = "Müstakil Ev";
            treeNode6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            treeNode6.Name = "satilik";
            treeNode6.NodeFont = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            treeNode6.Text = "Satılık";
            treeNode7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode7.Name = "daire_k";
            treeNode7.Text = "Daire";
            treeNode8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode8.Name = "ciftlikevi_k";
            treeNode8.Text = "Çiftlik Evi";
            treeNode9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode9.Name = " dagevi_k";
            treeNode9.Text = "Dağ Evi";
            treeNode10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode10.Name = "koyevi_k";
            treeNode10.Text = "Köy Evi";
            treeNode11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode11.Name = "mustakil_k";
            treeNode11.Text = "Müstakil Ev";
            treeNode12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            treeNode12.Name = "kiralik";
            treeNode12.NodeFont = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold);
            treeNode12.Text = "Kiralık";
            treeNode13.BackColor = System.Drawing.Color.White;
            treeNode13.Name = "Düğüm0";
            treeNode13.NodeFont = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold);
            treeNode13.Text = "Konut";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13});
            this.treeView1.Size = new System.Drawing.Size(404, 395);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.txt_fiyat);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.combo_ilce);
            this.groupBox2.Controls.Add(this.txt_metrekare);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.combo_yas);
            this.groupBox2.Controls.Add(this.combo_il);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.combo_banyo);
            this.groupBox2.Controls.Add(this.combo_kat);
            this.groupBox2.Controls.Add(this.combo_oda_say);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(583, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 781);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İlan Detayları";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 290);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(500, 280);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.ImageKey = "diskette (1).png";
            this.button3.ImageList = this.ımageList1;
            this.button3.Location = new System.Drawing.Point(28, 719);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 36);
            this.button3.TabIndex = 1;
            this.button3.Text = "Kaydet Ve Bitir";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "bin.png");
            this.ımageList1.Images.SetKeyName(1, "diskette (1).png");
            this.ımageList1.Images.SetKeyName(2, "add (1).png");
            // 
            // txt_fiyat
            // 
            this.txt_fiyat.Location = new System.Drawing.Point(407, 647);
            this.txt_fiyat.Name = "txt_fiyat";
            this.txt_fiyat.Size = new System.Drawing.Size(121, 24);
            this.txt_fiyat.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(444, 622);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 22);
            this.label15.TabIndex = 19;
            this.label15.Text = "Fiyat";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.ImageKey = "add (1).png";
            this.button2.ImageList = this.ımageList1;
            this.button2.Location = new System.Drawing.Point(390, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "Resim Ekle";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // combo_ilce
            // 
            this.combo_ilce.FormattingEnabled = true;
            this.combo_ilce.Location = new System.Drawing.Point(216, 645);
            this.combo_ilce.Name = "combo_ilce";
            this.combo_ilce.Size = new System.Drawing.Size(121, 26);
            this.combo_ilce.TabIndex = 9;
            this.combo_ilce.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // txt_metrekare
            // 
            this.txt_metrekare.Location = new System.Drawing.Point(134, 100);
            this.txt_metrekare.Name = "txt_metrekare";
            this.txt_metrekare.Size = new System.Drawing.Size(121, 24);
            this.txt_metrekare.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(260, 622);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 22);
            this.label14.TabIndex = 16;
            this.label14.Text = "İlçe";
            // 
            // combo_yas
            // 
            this.combo_yas.FormattingEnabled = true;
            this.combo_yas.Items.AddRange(new object[] {
            "0 (Yeni)",
            "1",
            "2",
            "3",
            "4",
            "5-10",
            "11-15",
            "16-20",
            "21 ve Üzeri"});
            this.combo_yas.Location = new System.Drawing.Point(404, 146);
            this.combo_yas.Name = "combo_yas";
            this.combo_yas.Size = new System.Drawing.Size(121, 26);
            this.combo_yas.TabIndex = 5;
            // 
            // combo_il
            // 
            this.combo_il.FormattingEnabled = true;
            this.combo_il.Items.AddRange(new object[] {
            "İstanbul",
            "Ankara",
            "İzmir",
            "Bursa",
            "Kocaeli",
            "Samsun",
            "Giresun",
            "Bingöl"});
            this.combo_il.Location = new System.Drawing.Point(30, 645);
            this.combo_il.Name = "combo_il";
            this.combo_il.Size = new System.Drawing.Size(121, 26);
            this.combo_il.TabIndex = 8;
            this.combo_il.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(76, 622);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 22);
            this.label13.TabIndex = 14;
            this.label13.Text = "İl";
            // 
            // combo_banyo
            // 
            this.combo_banyo.FormattingEnabled = true;
            this.combo_banyo.Items.AddRange(new object[] {
            "Yok",
            "1",
            "2",
            "3",
            "4",
            "5+"});
            this.combo_banyo.Location = new System.Drawing.Point(404, 102);
            this.combo_banyo.Name = "combo_banyo";
            this.combo_banyo.Size = new System.Drawing.Size(121, 26);
            this.combo_banyo.TabIndex = 4;
            // 
            // combo_kat
            // 
            this.combo_kat.FormattingEnabled = true;
            this.combo_kat.Items.AddRange(new object[] {
            "Bahçe Katı",
            "Zemin",
            "Çatı Katı",
            "Müstakil",
            "Bodrum Kat",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25+"});
            this.combo_kat.Location = new System.Drawing.Point(134, 184);
            this.combo_kat.Name = "combo_kat";
            this.combo_kat.Size = new System.Drawing.Size(121, 26);
            this.combo_kat.TabIndex = 3;
            // 
            // combo_oda_say
            // 
            this.combo_oda_say.FormattingEnabled = true;
            this.combo_oda_say.Items.AddRange(new object[] {
            "1",
            "1+1",
            "2+1",
            "2+2",
            "3+0",
            "3+1",
            "3+2",
            "4+0",
            "4+1",
            "4+2",
            "4+3",
            "4+4",
            "5+0",
            "5+1",
            "5+2",
            "5+3",
            "5+4",
            "6+1",
            "6+2",
            "6+3",
            "6+4",
            "7+1",
            "7+2",
            "7+3",
            "8+1",
            "8+2",
            "8+3",
            "8+4",
            "9+"});
            this.combo_oda_say.Location = new System.Drawing.Point(134, 142);
            this.combo_oda_say.Name = "combo_oda_say";
            this.combo_oda_say.Size = new System.Drawing.Size(121, 26);
            this.combo_oda_say.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(313, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 18);
            this.label12.TabIndex = 9;
            this.label12.Text = "Binanın Yaşı";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Banyo Sayısı";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Bulunduğu Kat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Oda Sayısı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Metrekare";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(25, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 14);
            this.label4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(28, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Katagori Değiştir";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 29);
            this.label2.TabIndex = 1;
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "bin.png");
            this.ımageList2.Images.SetKeyName(1, "diskette (1).png");
            this.ımageList2.Images.SetKeyName(2, "add (1).png");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // ilan_ver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 861);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ilan_ver";
            this.Text = "İlan Verme Sayfası";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ilan_ver_FormClosed);
            this.Load += new System.EventHandler(this.ilan_ver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_oda_say;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combo_yas;
        private System.Windows.Forms.ComboBox combo_banyo;
        private System.Windows.Forms.ComboBox combo_kat;
        private System.Windows.Forms.ComboBox combo_ilce;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox combo_il;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_metrekare;
        private System.Windows.Forms.TextBox txt_fiyat;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.ImageList ımageList1;
    }
}