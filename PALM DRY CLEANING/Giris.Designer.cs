
namespace PALM_DRY_CLEANING
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPersonelGiris = new System.Windows.Forms.Button();
            this.btnMusteriGirisi = new System.Windows.Forms.Button();
            this.btnYoneticiGirisi = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnPersonelGiris);
            this.panel1.Controls.Add(this.btnMusteriGirisi);
            this.panel1.Controls.Add(this.btnYoneticiGirisi);
            this.panel1.Location = new System.Drawing.Point(25, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 432);
            this.panel1.TabIndex = 1;
            // 
            // btnPersonelGiris
            // 
            this.btnPersonelGiris.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPersonelGiris.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonelGiris.ForeColor = System.Drawing.Color.White;
            this.btnPersonelGiris.Location = new System.Drawing.Point(69, 287);
            this.btnPersonelGiris.Name = "btnPersonelGiris";
            this.btnPersonelGiris.Size = new System.Drawing.Size(200, 43);
            this.btnPersonelGiris.TabIndex = 4;
            this.btnPersonelGiris.Text = "PERSONEL GİRİŞİ";
            this.btnPersonelGiris.UseVisualStyleBackColor = false;
            this.btnPersonelGiris.Click += new System.EventHandler(this.btnPersonelGiris_Click);
            // 
            // btnMusteriGirisi
            // 
            this.btnMusteriGirisi.BackColor = System.Drawing.Color.ForestGreen;
            this.btnMusteriGirisi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusteriGirisi.ForeColor = System.Drawing.Color.White;
            this.btnMusteriGirisi.Location = new System.Drawing.Point(69, 336);
            this.btnMusteriGirisi.Name = "btnMusteriGirisi";
            this.btnMusteriGirisi.Size = new System.Drawing.Size(200, 43);
            this.btnMusteriGirisi.TabIndex = 3;
            this.btnMusteriGirisi.Text = "MÜŞTERİ GİRİŞİ";
            this.btnMusteriGirisi.UseVisualStyleBackColor = false;
            this.btnMusteriGirisi.Click += new System.EventHandler(this.btnMusteriGirisi_Click);
            // 
            // btnYoneticiGirisi
            // 
            this.btnYoneticiGirisi.BackColor = System.Drawing.Color.ForestGreen;
            this.btnYoneticiGirisi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYoneticiGirisi.ForeColor = System.Drawing.Color.White;
            this.btnYoneticiGirisi.Location = new System.Drawing.Point(69, 238);
            this.btnYoneticiGirisi.Name = "btnYoneticiGirisi";
            this.btnYoneticiGirisi.Size = new System.Drawing.Size(200, 43);
            this.btnYoneticiGirisi.TabIndex = 2;
            this.btnYoneticiGirisi.Text = "YÖNETİCİ GİRİŞİ";
            this.btnYoneticiGirisi.UseVisualStyleBackColor = false;
            this.btnYoneticiGirisi.Click += new System.EventHandler(this.btnYoneticiGirisi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(89, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(379, 473);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Giris";
            this.Text = "Palm Dry Cleaning";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnYoneticiGirisi;
        private System.Windows.Forms.Button btnPersonelGiris;
        private System.Windows.Forms.Button btnMusteriGirisi;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}