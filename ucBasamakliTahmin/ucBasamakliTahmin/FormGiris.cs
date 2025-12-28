using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ucBasamakliTahmin
{
    public partial class FormGiris : Form
    {
        string connectionString = "Data Source=AZAHIDOFFICAL\\SQLEXPRESS;Initial Catalog=numberGame;Integrated Security=True";

        public FormGiris()
        {
            InitializeComponent();
        }

        private void FormGiris_Load(object sender, EventArgs e)
        {
            // Kayıt ol yazısının üzerine gelince el işareti çıksın
            lblKayitOl.Cursor = Cursors.Hand;
            lblKayitOl.ForeColor = System.Drawing.Color.Blue; // Rengi mavi olsun
        }

      
        private void lblKayitOl_Click_1(object sender, EventArgs e)
        {
            FormKayit frm = new FormKayit(); // Kayıt formunu oluştur
            frm.Show(); // Kayıt formunu göster
            this.Hide(); // Bu giriş ekranını gizle
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {// Kutular boş mu diye kontrol et
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş bırakılamaz!"); // Uyarı ver
                return; // İşlemi durdur
            }

            // Veritabanı bağlantısını kur
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open(); // Bağlantıyı aç
                    // Kullanıcılar tablosunda bu isim ve şifreye sahip biri var mı diye soruyoruz
                    string sql = "SELECT * FROM Kullanicilar WHERE OyuncuAdi=@p1 AND Sifre=@p2";
                    SqlCommand komut = new SqlCommand(sql, baglanti); // Komutu hazırla

                    komut.Parameters.AddWithValue("@p1", txtName.Text); // Kullanıcı adını ekle

                    // ÖNEMLİ DEĞİŞİKLİK: Şifreleme yapmadan direkt kutudaki şifreyi yolluyoruz
                    komut.Parameters.AddWithValue("@p2", txtPassword.Text);

                    SqlDataReader dr = komut.ExecuteReader(); // Okuyucuyu çalıştır
                    if (dr.Read()) // Eğer bir kayıt okuyabildiyse (yani böyle biri varsa)
                    {
                        // --- GİRİŞ BAŞARILI ---
                        Form1 oyun = new Form1(); // Oyun formunu oluştur
                        oyun.aktifKullanici = txtName.Text; // Kullanıcı adını oyuna gönder
                        oyun.Show(); // Oyunu aç

                        this.Hide(); // Giriş ekranını gizle
                    }
                    else // Kayıt bulunamazsa
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!"); // Hata ver
                    }
                }
                catch (Exception ex) // Bağlantı hatası olursa
                {
                    MessageBox.Show("Bağlantı Hatası: " + ex.Message);
                }
            }
        }
    }
}