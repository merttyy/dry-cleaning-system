using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PALM_DRY_CLEANING
{
    public partial class YoneticiGiris : Form
    {
        public YoneticiGiris()
        {
            InitializeComponent();
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMusteriGirisi_Click(object sender, EventArgs e)
        {
            if (txtYöneticiAd.Text=="admin" & txtYöneticiŞifre.Text == "admin")
            {
                YoneticiArayuz Yonetici_Arayuz = new YoneticiArayuz();
                Yonetici_Arayuz.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız\nKullanıcı Adı veya Şifre Hatalı");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
