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
    public partial class MüsteriGirisi : Form
    {
        public MüsteriGirisi()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand cmdMusteriGiris = new SqlCommand();
        public static string MusteriMaili;
        public static string MusteriSifresi;

        private void btnKullaniciGirisi_Click(object sender, EventArgs e)
        {

            con.Open();
            cmdMusteriGiris.Connection = con;
            cmdMusteriGiris.CommandText = "Select*From MusteriBilgileri where MusteriMail='" + txtMusteriMail.Text + "' And MusteriSifre='" + txtKullaniciŞifre.Text + "'";
            dr = cmdMusteriGiris.ExecuteReader();
            if (dr.Read())
            {
                MusteriMaili = txtMusteriMail.Text;
                MusteriSifresi = txtKullaniciŞifre.Text;
                MusteriArayuz musteri_arayuz = new MusteriArayuz();
                musteri_arayuz.Show();
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız\nKullanıcı Maili veya Şifre Hatalı");
            }
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SiparisEkleme siparis_ekleme = new SiparisEkleme();
            siparis_ekleme.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MusteriKayit musteri_kayit = new MusteriKayit();
            musteri_kayit.Show();
            this.Hide();
        }
    }
}
