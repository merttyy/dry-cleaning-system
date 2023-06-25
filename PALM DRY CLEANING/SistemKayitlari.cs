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
    public partial class SistemKayitlari : Form
    {
        public SistemKayitlari()
        {
            InitializeComponent();
        }
        SqlConnection baglanti2 = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");

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
            SqlCommand komut2 = new SqlCommand("select * from SiparisData", baglanti2);
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
                ekle.SubItems.Add(dr2["Personel"].ToString());
                ekle.SubItems.Add(dr2["IslemSaati"].ToString());
                ekle.SubItems.Add(dr2["Islem"].ToString());


                listView1.Items.Add(ekle);

            }
            baglanti2.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
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
            SqlCommand komut3 = new SqlCommand("delete from SiparisData where MusteriID=(" + id + ")", baglanti2);
            komut3.ExecuteNonQuery();
            baglanti2.Close();
            MessageBox.Show("Kayıt başarıyla silindi");
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti2.Open();
            SqlCommand komut2 = new SqlCommand("select * from SiparisData where Ad like '%" + txtAranacakKelime.Text + "%' or Soyad like '%" + txtAranacakKelime.Text + "%' or Islem like '%" + txtAranacakKelime.Text + "%'", baglanti2);
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
                ekle.SubItems.Add(dr2["Personel"].ToString());
                ekle.SubItems.Add(dr2["IslemSaati"].ToString());
                ekle.SubItems.Add(dr2["Islem"].ToString());


                listView1.Items.Add(ekle);

            }
            baglanti2.Close();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            YoneticiArayuz geri_don = new YoneticiArayuz();
            geri_don.Show();
            this.Hide();
        }
    }
}
