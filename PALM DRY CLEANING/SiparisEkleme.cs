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
    public partial class SiparisEkleme : Form
    {
        public SiparisEkleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");
        bool tadilat;
        static DateTime SiparişTarihi = DateTime.Today;
        static string SiparişTarihiString = SiparişTarihi.ToString("yyyy-MM-dd");
        int fiyat = 0;
        int urunfiyati = 0;
        int kumasfiyati = 0;
        int gunfiyati = 0;
        int tadilatfiyati = 0;
        static DateTime TarihSaat = DateTime.Now;
        static string strTarihSaat = TarihSaat.ToString("yyyy-MM-dd HH:mm:ss");

        Regex rgxAd = new Regex(@"([a-zA-Z]{2,}(\s)?)+");
        Regex rgxSoyad = new Regex(@"^[a-zA-Z]{2,}");
        Regex rgxMail = new Regex(@"([a-zA-Z0-9\.\-_])+\@([a-zA-Z]+)(\.[a-zA-Z]+)(\.[a-zA-Z]+)?");
        Regex rgxTelNo = new Regex(@"\(\d{3}\)\s\d{3}-\d{4}");


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (rdoEvet.Checked == true)
            {
                tadilat = true;
            }
            else
            {
                tadilat = false;
            }

            if (rgxAd.IsMatch(txtAd.Text))
            {
                if (rgxSoyad.IsMatch(txtSoyad.Text))
                {
                    if (rgxTelNo.IsMatch(mtxtTel.Text))
                    {
                        if (rgxMail.IsMatch(txtMail.Text))
                        {
                            baglanti.Open();
                            SqlCommand cmdSiparisKayit = new SqlCommand("insert into SiparisKayit (Ad,Soyad,TelNo,Mail,Adres,UrunTipi,Kumastipi,Tadilat,Note,SiparisTarihi,TeslimTarihi,Fiyat,Durum,Personel) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtMail.Text + "','" + txtAdres.Text + "','" + coboÜrüntipi.SelectedItem + "','" + coboKumaştipi.SelectedItem + "','" + tadilat + "','" + txtNot.Text + "','" + SiparişTarihiString + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + fiyat + "','" + false + "','" + "müsteri" + "')", baglanti);
                            cmdSiparisKayit.ExecuteNonQuery();
                            SqlCommand cmdSiparisData = new SqlCommand("insert into SiparisData (Ad,Soyad,TelNo,Mail,Adres,UrunTipi,Kumastipi,Tadilat,Note,SiparisTarihi,TeslimTarihi,Fiyat,Durum,Personel,IslemSaati,Islem) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtMail.Text + "','" + txtAdres.Text + "','" + coboÜrüntipi.SelectedItem + "','" + coboKumaştipi.SelectedItem + "','" + tadilat + "','" + txtNot.Text + "','" + SiparişTarihiString + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + fiyat + "','" + false + "','" + "müsteri" + "','" + strTarihSaat + "','" + btnKaydet.Text + "')", baglanti);
                            cmdSiparisData.ExecuteNonQuery();
                            baglanti.Close();
                            MessageBox.Show("Sipariş Kaydı Tamamlandı");
                            this.Hide();
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

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnBilgi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Teslim tarihine göre fiyatta değişiklik olmaktadır.\nAynı gün teslim: 50 ₺\n1 gün içinde teslim: 35 ₺\n2-3 gün arası teslim: 15 ₺\nekstra ücrete tabiidir.");
        }

        private void coboÜrüntipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (coboÜrüntipi.Text == "Mont/Kaban" || coboÜrüntipi.Text == "Elbise" || coboÜrüntipi.Text == "Takım Elbise")
            {
                urunfiyati = 100;
            }
            else
            {
                urunfiyati = 25;
            }
            fiyat = urunfiyati + kumasfiyati + tadilatfiyati + gunfiyati;
            txtTutar.Text = fiyat.ToString();
        }

        private void coboKumaştipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coboKumaştipi.Text == "Pamuklu" || coboKumaştipi.Text == "Polyester" || coboKumaştipi.Text == "Kot")
            {
                kumasfiyati = 25;
            }
            else if (coboKumaştipi.Text == "İpek" || coboKumaştipi.Text == "Yünlü" || coboKumaştipi.Text == "Polar")
            {
                kumasfiyati = 50;
            }
            else if (coboKumaştipi.Text == "Keten")
            {
                kumasfiyati = 75;
            }
            else
            {
                kumasfiyati = 100;
            }
            fiyat = urunfiyati + kumasfiyati + tadilatfiyati + gunfiyati;
            txtTutar.Text = fiyat.ToString();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            DateTime tarih2 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime tarih1 = Convert.ToDateTime(SiparişTarihi);
            TimeSpan tarihfarki = tarih2 - tarih1;

            gunaraligi.Text = tarihfarki.TotalDays.ToString();

            int gunaraligisayisi = Convert.ToInt32(gunaraligi.Text);

            

            if (gunaraligisayisi == 0)
            {
                gunfiyati = 50;
            }
            else if (gunaraligisayisi == 1)
            {
                gunfiyati = 35;
            }
            else if(gunaraligisayisi<=3 && gunaraligisayisi > 1)
            {
                gunfiyati = 15;
            }
            else
            {
                gunfiyati = 0;
            }

            fiyat = urunfiyati + kumasfiyati + tadilatfiyati + gunfiyati;
            txtTutar.Text = fiyat.ToString();


        }

        

        private void rdoEvet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEvet.Checked == true)
            {
                tadilatfiyati = 15;

            }
            else
            {
                tadilatfiyati = 0;
            }

            fiyat = urunfiyati + kumasfiyati + tadilatfiyati + gunfiyati;
            txtTutar.Text = fiyat.ToString();
        }
    }
}
