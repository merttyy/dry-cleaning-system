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
    public partial class PersonelBilgi : Form
    {
        public PersonelBilgi()
        {
            InitializeComponent();
            lblPersonelAdi.Text = "admin";
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3IL28VP\\SQLEXPRESS;Initial Catalog=PalmDryCleaning;Integrated Security=True");
        
        private void listele()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from PersonelBilgileri", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = dr["KullaniciID"].ToString();
                ekle.SubItems.Add(dr["KullaniciAdi"].ToString());
                ekle.SubItems.Add(dr["KullaniciSifre"].ToString());
                

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
