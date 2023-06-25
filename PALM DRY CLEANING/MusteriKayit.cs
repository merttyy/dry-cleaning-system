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
using System.Text.RegularExpressions;

namespace PALM_DRY_CLEANING
{
    public partial class MusteriKayit : Form
    {
        public MusteriKayit()
        {
            InitializeComponent();
        }
        static DateTime TarihSaat = DateTime.Now;
        static string strTarihSaat = TarihSaat.ToString("yyyy-MM-dd HH:mm:ss");
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");
        SqlConnection baglantiara = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");
        bool mailkontrol = false;

        Regex rgxAd = new Regex(@"([a-zA-Z]{2,}(\s)?)+");
        Regex rgxSoyad = new Regex(@"^[a-zA-Z]{2,}");
        Regex rgxMail = new Regex(@"([a-zA-Z0-9\.\-_])+\@([a-zA-Z]+)(\.[a-zA-Z]+)(\.[a-zA-Z]+)?");
        Regex rgxTelNo = new Regex(@"\(\d{3}\)\s\d{3}-\d{4}");


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            
            baglantiara.Open();
            SqlCommand cmdAra = new SqlCommand("select * from MusteriBilgileri where MusteriMail like '%" + txtMail.Text + "%'", baglantiara);
            SqlDataReader dr = cmdAra.ExecuteReader();
            while (dr.Read())
            {
                if (dr["MusteriMail"].ToString() == txtMail.Text)
                {
                    mailkontrol = true;
                    MessageBox.Show("Bu mail adresiyle oluşturulmuş başka bir hesap bulunmaktadır");
                    Application.Exit();
                }
                else
                {
                    mailkontrol = false;
                }
            }
            baglantiara.Close();
            dr.Close();

            if (mailkontrol==false)
            {
                if (rgxAd.IsMatch(txtAd.Text))
                {
                    if (rgxSoyad.IsMatch(txtSoyad.Text))
                    {
                        if (rgxTelNo.IsMatch(mtxtTel.Text))
                        {
                            if (rgxMail.IsMatch(txtMail.Text))
                            {
                                if (txtSifre.Text == txtSifreTekrar.Text)
                                {
                                    baglanti.Open();
                                    SqlCommand cmdKayitOl = new SqlCommand("insert into MusteriBilgileri (MusteriMail,MusteriSifre,MusteriAdi,MusteriSoyadi,MusteriTel,MusteriAdres) values ('" + txtMail.Text + "','" + txtSifre.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtAdres.Text + "')", baglanti);
                                    cmdKayitOl.ExecuteNonQuery();
                                    SqlCommand cmdSiparisData = new SqlCommand("insert into SiparisData (Ad,Soyad,TelNo,Mail,Adres,UrunTipi,Kumastipi,Tadilat,Note,SiparisTarihi,TeslimTarihi,Fiyat,Durum,Personel,IslemSaati,Islem) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtMail.Text + "','" + txtAdres.Text + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + false + "','" + txtAd.Text+" "+txtSoyad.Text + "','" + strTarihSaat + "','" + "YENI UYELIK" + "')", baglanti);
                                    cmdSiparisData.ExecuteNonQuery();
                                    baglanti.Close();
                                    MessageBox.Show("Müşteri Kaydı Tamamlandı");
                                    Application.Exit();
                                }
                                else
                                {
                                    MessageBox.Show("Şifreler uyuşmamaktadır");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Geçerli bir mail adresi giriniz");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Geçerli bir telefon numarası giriniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçerli bir soyad giriniz");
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir ad giriniz");
                }
                
            }
            else
            {
                MessageBox.Show("Bu mail adresiyle oluşturulmuş başka bir hesap bulunmaktadır");
            }
            
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            
            
            if (rgxMail.IsMatch(txtMail.Text))
            {
                
                lblKontrol.Text = "✓";
                
            }
            else
            {
                
                lblKontrol.Text = "✗";
                
            }
        }
    }
}
