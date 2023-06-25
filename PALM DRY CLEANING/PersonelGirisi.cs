using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PALM_DRY_CLEANING
{
    public partial class PersonelGirisi : Form
    {
        public PersonelGirisi()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand cmdPersonelGiris = new SqlCommand();
        public static string KullaniciAdi;
        
        private void btnYoneticiGirisi_Click(object sender, EventArgs e)
        {
            KullaniciAdi = txtKullaniciAd.Text;
            string KullaniciSifre = txtKullaniciŞifre.Text;

            con.Open();
            cmdPersonelGiris.Connection = con;
            cmdPersonelGiris.CommandText = "Select*From PersonelBilgileri where KullaniciAdi='" + txtKullaniciAd.Text + "' And KullaniciSifre='" + txtKullaniciŞifre.Text + "'";
            dr = cmdPersonelGiris.ExecuteReader();
            if (dr.Read())
            {
                PersonelArayuz personel_arayuzu = new PersonelArayuz();
                personel_arayuzu.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Giriş Başarısız\nKullanıcı Adı veya Şifre Hatalı");
            }
            con.Close();

        }
    }
}
