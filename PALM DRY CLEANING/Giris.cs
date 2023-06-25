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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
       
        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void btnYoneticiGirisi_Click(object sender, EventArgs e)
        {
            YoneticiGiris Yonetici_Giris = new YoneticiGiris();
            Yonetici_Giris.Show();
            this.Hide();
        }

        private void btnPersonelGiris_Click(object sender, EventArgs e)
        {
            PersonelGirisi personel_girisi = new PersonelGirisi();
            personel_girisi.Show();
            this.Hide();
        }

        private void btnMusteriGirisi_Click(object sender, EventArgs e)
        {
            /*SiparisEkleme sipariş_ekle = new SiparisEkleme();
            sipariş_ekle.Show();
            this.Hide();*/
            MüsteriGirisi musteri_giris = new MüsteriGirisi();
            musteri_giris.Show();
            this.Hide();
        }
    }

}
