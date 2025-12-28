using System; // Temel sistem
using System.Data.SqlClient; // Veritabanı
using System.Windows.Forms; // Form araçları
// Şifreleme kütüphanesini sildim.

namespace ucBasamakliTahmin
{
    public partial class FormKayit : Form
    {
        string connectionString = "Data Source=AZAHIDOFFICAL\\SQLEXPRESS;Initial Catalog=numberGame;Integrated Security=True";

        public FormKayit()
        {
            InitializeComponent();
        }
        private void btnKayitOl_Click_1(object sender, EventArgs e)
        {
            // Önemli kutular boş mu diye kontrol et
            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text) ||
                string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Lütfen önemli alanları doldurunuz!"); // Uyarı ver
                return; // İşlemi durdur
            }

            // Veritabanı bağlantısı kur (using bloğu otomatik kapatır)
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open(); // Bağlantıyı aç
                    // Kayıt ekleme sorgusu (INSERT)
                    string sql = "INSERT INTO Kullanicilar (Ad, Soyad, Telefon, Eposta, OyuncuAdi, Sifre) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                    SqlCommand komut = new SqlCommand(sql, baglanti); // Komutu hazırla

                    // Kutulardaki verileri güvenli şekilde parametrelere ata
                    komut.Parameters.AddWithValue("@p1", txtAd.Text);
                    komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
                    komut.Parameters.AddWithValue("@p3", txtTel.Text);
                    komut.Parameters.AddWithValue("@p4", txtEposta.Text);
                    komut.Parameters.AddWithValue("@p5", txtName.Text);

                    // ÖNEMLİ DEĞİŞİKLİK: Şifreyi şifrelemeden direkt kaydediyoruz
                    komut.Parameters.AddWithValue("@p6", txtPassword.Text);

                    komut.ExecuteNonQuery(); // Komutu çalıştır (kaydet)

                    MessageBox.Show("Kayıt Başarılı! Giriş ekranına yönlendiriliyorsunuz.");

                    // Kayıt formunu kapat, yeni bir giriş formu aç
                    FormGiris giris = new FormGiris(); // Giriş formu oluştur
                    giris.Show(); // Giriş formunu göster
                    this.Close(); // Bu kayıt formunu kapat
                }
                catch (Exception ex)
                {
                    // Hata olursa (Mesela aynı kullanıcı adı varsa veritabanı hata verir)
                    MessageBox.Show("Hata (Kullanıcı adı alınmış olabilir): " + ex.Message);
                }
            }
        }
    }
}