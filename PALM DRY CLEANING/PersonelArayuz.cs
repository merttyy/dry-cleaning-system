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
    public partial class PersonelArayuz : Form
    {
        public PersonelArayuz()
        {
            InitializeComponent();
            lblPersonelAdi.Text = PersonelGirisi.KullaniciAdi;
        }
        SqlConnection baglanti2 = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");
        bool tadilat;
        bool siparisdurumu;
        static DateTime SiparişTarihi = DateTime.Today;
        static string SiparişTarihiString = SiparişTarihi.ToString("yyyy-MM-dd");
        int fiyat = 0;
        int urunfiyati = 0;
        int kumasfiyati = 0;
        int gunfiyati = 0;
        int tadilatfiyati = 0;
        static DateTime TarihSaat = DateTime.Now;
        static string strTarihSaat=TarihSaat.ToString("yyyy-MM-dd HH:mm:ss");

        Regex rgxAd = new Regex(@"([a-zA-Z]{2,}(\s)?)+");
        Regex rgxSoyad = new Regex(@"^[a-zA-Z]{2,}");
        Regex rgxMail = new Regex(@"([a-zA-Z0-9\.\-_])+\@([a-zA-Z]+)(\.[a-zA-Z]+)(\.[a-zA-Z]+)?");
        Regex rgxTelNo = new Regex(@"\(\d{3}\)\s\d{3}-\d{4}");

        private void siparistemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mtxtTel.Clear();
            txtMail.Clear();
            txtAdres.Clear();
            coboÜrüntipi.Text = "";
            coboKumaştipi.Text = "";
            txtNot.Clear();
            mtxtSiparisTarihi.Clear();
            dtpTeslimTarihi.Text = "";
            txtTutar.Clear();
            rdoEvet.Checked = false;
            rdoHayır.Checked = false;
            chkHazir.Checked = false;

        }
        
        private void siparislistele()
        {
            listView1.Items.Clear();
            baglanti2.Open();
            SqlCommand komut2 = new SqlCommand("select * from SiparisKayit", baglanti2);
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                ListViewItem ekle = new ListViewItem();
                
                    ekle.Text = dr2["MusteriID"].ToString();
                    ekle.SubItems.Add(dr2["Ad"].ToString());
                    ekle.SubItems.Add(dr2["Soyad"].ToString());
                    ekle.SubItems.Add(dr2["TelNo"].ToString());
                    ekle.SubItems.Add(dr2["Mail"].ToString());
                    ekle.SubItems.Add(dr2["Adres"].ToString());
                    ekle.SubItems.Add(dr2["UrunTipi"].ToString());
                    ekle.SubItems.Add(dr2["KumasTipi"].ToString());
                    ekle.SubItems.Add(dr2["Tadilat"].ToString());
                    ekle.SubItems.Add(dr2["Note"].ToString());
                    ekle.SubItems.Add(dr2["SiparisTarihi"].ToString());
                    ekle.SubItems.Add(dr2["TeslimTarihi"].ToString());
                    ekle.SubItems.Add(dr2["Fiyat"].ToString());
                    ekle.SubItems.Add(dr2["Durum"].ToString());

                    listView1.Items.Add(ekle);
                

            }
            baglanti2.Close();
        }
        private void button1_Click(object sender, EventArgs e)//kaydet
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
                            baglanti2.Open();
                            SqlCommand cmdSiparisKayit = new SqlCommand("insert into SiparisKayit (Ad,Soyad,TelNo,Mail,Adres,UrunTipi,Kumastipi,Tadilat,Note,SiparisTarihi,TeslimTarihi,Fiyat,Durum,Personel) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtMail.Text + "','" + txtAdres.Text + "','" + coboÜrüntipi.SelectedItem + "','" + coboKumaştipi.SelectedItem + "','" + tadilat + "','" + txtNot.Text + "','" + SiparişTarihiString + "','" + dtpTeslimTarihi.Value.ToString("yyyy-MM-dd") + "','" + fiyat + "','" + siparisdurumu + "','" + PersonelGirisi.KullaniciAdi + "')", baglanti2);
                            cmdSiparisKayit.ExecuteNonQuery();
                            SqlCommand cmdSiparisData = new SqlCommand("insert into SiparisData (Ad,Soyad,TelNo,Mail,Adres,UrunTipi,Kumastipi,Tadilat,Note,SiparisTarihi,TeslimTarihi,Fiyat,Durum,Personel,IslemSaati,Islem) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtMail.Text + "','" + txtAdres.Text + "','" + coboÜrüntipi.SelectedItem + "','" + coboKumaştipi.SelectedItem + "','" + tadilat + "','" + txtNot.Text + "','" + SiparişTarihiString + "','" + dtpTeslimTarihi.Value.ToString("yyyy-MM-dd") + "','" + fiyat + "','" + siparisdurumu + "','" + PersonelGirisi.KullaniciAdi + "','" + strTarihSaat + "','" + btnKAYDET.Text + "')", baglanti2);
                            cmdSiparisData.ExecuteNonQuery();
                            baglanti2.Close();
                            MessageBox.Show("Sipariş Kaydı Tamamlandı");
                            siparistemizle();
                            siparislistele();
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

        private void btnSiparisListele_Click(object sender, EventArgs e)
        {
            siparislistele();
        }
        int id = 0;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txtAd.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtSoyad.Text = listView1.SelectedItems[0].SubItems[2].Text;
            mtxtTel.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtMail.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtAdres.Text = listView1.SelectedItems[0].SubItems[5].Text;
            coboÜrüntipi.Text = listView1.SelectedItems[0].SubItems[6].Text;
            coboKumaştipi.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtNot.Text = listView1.SelectedItems[0].SubItems[9].Text;
            mtxtSiparisTarihi.Text = listView1.SelectedItems[0].SubItems[10].Text;
            dtpTeslimTarihi.Text = listView1.SelectedItems[0].SubItems[11].Text;
            txtTutar.Text = listView1.SelectedItems[0].SubItems[12].Text;
            
            if (listView1.SelectedItems[0].SubItems[8].Text == "True")
            {
                rdoEvet.Checked = true;
            }
            else
            {
                rdoHayır.Checked = true;
            }
            
            if (listView1.SelectedItems[0].SubItems[13].Text == "True")
            {
                chkHazir.Checked = true;
            }
            else
            {
                chkHazir.Checked = false;
            }
            


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti2.Open();
            SqlCommand komut3 = new SqlCommand("delete from SiparisKayit where MusteriID=(" + id + ")",baglanti2);
            komut3.ExecuteNonQuery();
            SqlCommand cmdSiparisData = new SqlCommand("insert into SiparisData (Ad,Soyad,TelNo,Mail,Adres,UrunTipi,Kumastipi,Tadilat,Note,SiparisTarihi,TeslimTarihi,Fiyat,Durum,Personel,IslemSaati,Islem) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtMail.Text + "','" + txtAdres.Text + "','" + coboÜrüntipi.SelectedItem + "','" + coboKumaştipi.SelectedItem + "','" + tadilat + "','" + txtNot.Text + "','" + SiparişTarihiString + "','" + dtpTeslimTarihi.Value.ToString("yyyy-MM-dd") + "','" + fiyat + "','" + siparisdurumu + "','" + PersonelGirisi.KullaniciAdi + "','" + strTarihSaat + "','" + btnSil.Text + "')", baglanti2);
            cmdSiparisData.ExecuteNonQuery();
            baglanti2.Close();
            MessageBox.Show("Sipariş başarıyla silindi");
            siparistemizle();
            siparislistele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mtxtTel.Clear();
            txtMail.Clear();
            txtAdres.Clear();
            coboÜrüntipi.Text = "";
            coboKumaştipi.Text = "";
            txtNot.Clear();
            mtxtSiparisTarihi.Clear();
            dtpTeslimTarihi.Text = "";
            txtTutar.Clear();
            rdoEvet.Checked = false;
            rdoHayır.Checked = false;
            chkHazir.Checked = false;
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

        private void dtpTeslimTarihi_ValueChanged(object sender, EventArgs e)
        {
            DateTime tarih2 = Convert.ToDateTime(dtpTeslimTarihi.Text);
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
            else if (gunaraligisayisi <= 3 && gunaraligisayisi > 1)
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

        private void radHazir_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti2.Open();
            SqlCommand updtkomutu = new SqlCommand("update SiparisKayit set Ad='" + txtAd.Text + "', Soyad='" + txtSoyad.Text + "', TelNo='" + mtxtTel.Text + "', Adres='" + txtAdres.Text + "', UrunTipi='" + coboÜrüntipi.Text + "', KumasTipi='" + coboKumaştipi.Text + "', Tadilat='" + tadilat + "', Note='" + txtNot.Text + "', TeslimTarihi='" + dtpTeslimTarihi.Value.ToString("yyyy-MM-dd") + "', Fiyat='" + fiyat + "', Durum='" + siparisdurumu + "', Personel='" + PersonelGirisi.KullaniciAdi + "' where MusteriID=" + id + "",baglanti2);
            updtkomutu.ExecuteNonQuery();
            SqlCommand cmdSiparisData = new SqlCommand("insert into SiparisData (Ad,Soyad,TelNo,Mail,Adres,UrunTipi,Kumastipi,Tadilat,Note,SiparisTarihi,TeslimTarihi,Fiyat,Durum,Personel,IslemSaati,Islem) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mtxtTel.Text + "','" + txtMail.Text + "','" + txtAdres.Text + "','" + coboÜrüntipi.SelectedItem + "','" + coboKumaştipi.SelectedItem + "','" + tadilat + "','" + txtNot.Text + "','" + SiparişTarihiString + "','" + dtpTeslimTarihi.Value.ToString("yyyy-MM-dd") + "','" + fiyat + "','" + siparisdurumu + "','" + PersonelGirisi.KullaniciAdi + "','" + strTarihSaat + "','" + btnGuncelle.Text + "')", baglanti2);
            cmdSiparisData.ExecuteNonQuery();
            baglanti2.Close();
            MessageBox.Show("Sipariş başarıyla güncellendi");
            siparislistele();
            

        }

        private void chkHazir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHazir.Checked==true)
            {
                siparisdurumu = true;
            }
            else
            {
                siparisdurumu = false;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti2.Open();
            SqlCommand komut2 = new SqlCommand("select * from SiparisKayit where Ad like '%"+ txtAranacakKelime.Text+ "%' or Soyad like '%" + txtAranacakKelime.Text + "%' or TelNo like '%" + txtAranacakKelime.Text + "%'", baglanti2);
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                ListViewItem ekle = new ListViewItem();
                if (dr2["Personel"].ToString() == PersonelGirisi.KullaniciAdi || dr2["Personel"].ToString() == "" || dr2["Personel"].ToString() == " ")
                {
                    ekle.Text = dr2["MusteriID"].ToString();
                    ekle.SubItems.Add(dr2["Ad"].ToString());
                    ekle.SubItems.Add(dr2["Soyad"].ToString());
                    ekle.SubItems.Add(dr2["TelNo"].ToString());
                    ekle.SubItems.Add(dr2["Mail"].ToString());
                    ekle.SubItems.Add(dr2["Adres"].ToString());
                    ekle.SubItems.Add(dr2["UrunTipi"].ToString());
                    ekle.SubItems.Add(dr2["KumasTipi"].ToString());
                    ekle.SubItems.Add(dr2["Tadilat"].ToString());
                    ekle.SubItems.Add(dr2["Note"].ToString());
                    ekle.SubItems.Add(dr2["SiparisTarihi"].ToString());
                    ekle.SubItems.Add(dr2["TeslimTarihi"].ToString());
                    ekle.SubItems.Add(dr2["Fiyat"].ToString());
                    ekle.SubItems.Add(dr2["Durum"].ToString());

                    listView1.Items.Add(ekle);
                }
                

            }
            baglanti2.Close();
        }
    }
}
