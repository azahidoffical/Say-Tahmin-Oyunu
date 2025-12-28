using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; 
using System.Linq;
using System.Windows.Forms;

namespace ucBasamakliTahmin
{
    public partial class Form1 : Form
    {
        public string aktifKullanici;

        // SENİN BİLGİSAYARININ ADRESİ (Bunu Giris ve Kayit formlarına da yapıştır)
        string connectionString = "Data Source=AZAHIDOFFICAL\\SQLEXPRESS;Initial Catalog=numberGame;Integrated Security=True";

        int rastgeleSayi = 0;
        int basamakSayisi = 0;
        int kalanHak = 10;
        int puan = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Oyuncu: " + aktifKullanici; // Pencerenin başlığına oyuncunun adını yazıyoruz

            // 1. Sanal Klavye Bağlantısı (Ekrandaki tuşlara basılınca ne olacağını ayarlıyoruz)
            foreach (Control c in this.Controls) // Formdaki bütün araçları tek tek geziyoruz
            {
                // Eğer bu araç bir Butonsa VE tek karakterse VE o karakter bir rakamsa
                if (c is Button && c.Text.Length == 1 && char.IsDigit(c.Text[0]))
                    c.Click += SanalKlavye_Click; // Bu butona tıklandığında "SanalKlavye_Click" çalışsın diyoruz
            }

            // 2. DataGridView'i Doldur (Skor Tablosunu veritabanından çekip göster)
            SkorTablosunuGetir(); // Aşağıdaki tablo getirme fonksiyonunu çağırıyoruz
        }
        private void SkorTablosunuGetir()
        {
            // Veritabanı bağlantısı oluşturuyoruz (using bloğu iş bitince bağlantıyı otomatik kapatır)
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try // Hata çıkma ihtimaline karşı deneme bloğu açıyoruz
                {
                    baglanti.Open(); // Veritabanı kapısını açıyoruz

                    // SQL Sorgusu: Skorlar tablosundan OyuncuAdi, Puan vb. seç, Puana göre çoktan aza sırala
                    string sorgu = "SELECT OyuncuAdi AS [Oyuncu], Puan, BasamakSayisi, Tarih FROM Skorlar ORDER BY Puan DESC";

                    // Verileri çekip getirecek olan aracı (DataAdapter) hazırlıyoruz
                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);

                    // Hafızada geçici bir tablo oluşturuyoruz
                    DataTable tablo = new DataTable();

                    // Çekilen verileri bu hafızadaki tabloya dolduruyoruz
                    da.Fill(tablo);

                    // Ekrandaki tablo aracına (DataGridView) bu verileri bağlıyoruz
                    dgvSkor.DataSource = tablo;
                }
                catch (Exception hata) // Eğer bir sorun olursa burası çalışır
                {
                    // Ekrana hatanın ne olduğunu yazan bir uyarı kutusu çıkarır
                    MessageBox.Show("Skorlar yüklenirken hata: " + hata.Message);
                }
            }
        }

        private void SanalKlavye_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Hangi butona basıldığını anlıyoruz
            if (txtTahmin.Enabled) txtTahmin.Text += btn.Text; // Eğer tahmin kutusu açıksa, basılan rakamı oraya ekliyoruz
        }

        // --- OYUN BAŞLATMA ---
        private void bsltButton_Click(object sender, EventArgs e)
        {
            // Basamak Seçimi Kontrolü: Hiçbir zorluk seviyesi seçilmemişse uyar
            if (!rb3.Checked && !rb4.Checked && !rb5.Checked)
            {
                MessageBox.Show("Lütfen önce kaç basamaklı oynayacağınızı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kodun çalışmasını burada durdur
            }

            Random rnd = new Random(); // Rastgele sayı üretici oluşturuyoruz

            // Seçilen radyo butonuna göre basamak sayısını belirliyoruz
            if (rb3.Checked) basamakSayisi = 3;
            else if (rb4.Checked) basamakSayisi = 4;
            else basamakSayisi = 5;

            // Rakamları birbirinden farklı bir sayı üretmek için döngü kuruyoruz
            while (true)
            {
                // Örneğin 3 basamaklı ise 100 ile 1000 arasında sayı tutar
                int min = (int)Math.Pow(10, basamakSayisi - 1);
                int max = (int)Math.Pow(10, basamakSayisi);
                int aday = rnd.Next(min, max); // Rastgele bir sayı seç

                string s = aday.ToString(); // Sayıyı yazıya çevir
                // Eğer sayının içindeki benzersiz rakam sayısı, basamak sayısına eşitse (yani tekrar eden yoksa)
                if (s.Distinct().Count() == basamakSayisi)
                {
                    rastgeleSayi = aday; // Bu sayıyı gizli sayı olarak kabul et
                    break; // Döngüden çık, sayıyı bulduk
                }
            }

            // Değişkenleri başlangıç durumuna (Sıfırla) getiriyoruz
            kalanHak = 10;
            puan = 100;
            lblHak.Text = "Kalan Hak: 10"; // Ekrana yaz

            txtTahmin.Text = ""; // Tahmin kutusunu temizle
            txtTahmin.Enabled = true; // Tahmin kutusunu veri girişine aç
            thmnButton.Enabled = true; // Tahmin butonunu aktif et
            thmnListBox.Items.Clear(); // Önceki tahmin listesini temizle

            // --- İSTEDİĞİN ÖZELLİK: Başlangıçta Mavi ve '0' yazan kutular çiz ---
            BaslangicKutulariniCiz();

            // Kullanıcıya oyunun başladığını haber ver
            MessageBox.Show(basamakSayisi + " basamaklı oyun başladı! Bol şans.");
        }
        private void BaslangicKutulariniCiz()
        {
            pnlKutular.Controls.Clear(); // Paneldeki eski kutuları temizle
            for (int i = 0; i < basamakSayisi; i++) // Basamak sayısı kadar döngü kur
            {
                Button kutu = new Button(); // Yeni bir buton (kutu) oluştur
                kutu.Size = new Size(40, 40); // Kutunun boyutunu ayarla
                kutu.Location = new Point(i * 45, 0); // Kutunun ekrandaki yerini ayarla (yan yana diz)
                kutu.Text = "0"; // İçine başlangıçta 0 yaz
                kutu.Font = new Font("Arial", 12, FontStyle.Bold); // Yazı tipini ayarla
                kutu.ForeColor = Color.White; // Yazı rengi beyaz olsun
                kutu.BackColor = Color.Blue; // Arka plan rengi MAVİ olsun
                kutu.FlatStyle = FlatStyle.Flat; // Kutunun kenarları düz olsun
                pnlKutular.Controls.Add(kutu); // Kutuyu panele ekle
            }
        }

        // --- TAHMİN ETME ---
        private void thmnButton_Click(object sender, EventArgs e)
        {
            string tahmin = txtTahmin.Text;

            // 1. GÜVENLİK: Oyun başlamış mı?
            if (basamakSayisi == 0)
            {
                MessageBox.Show("Lütfen önce zorluk seviyesi seçip BAŞLAT butonuna basın!");
                return;
            }

            // 2. GÜVENLİK: Kutu boş mu?
            if (string.IsNullOrEmpty(txtTahmin.Text))
            {
                MessageBox.Show("Lütfen bir sayı girin!");
                return;
            }

            // 3. GÜVENLİK: Eksik veya fazla sayı girildi mi? (HATA BURADA ÇÖZÜLÜYOR)
            if (tahmin.Length != basamakSayisi)
            {
                MessageBox.Show($"Lütfen {basamakSayisi} haneli bir sayı girin! Sen {tahmin.Length} hane girdin.");
                return;
            }

            pnlKutular.Controls.Clear(); // Eski kutuları temizle
            string gizli = rastgeleSayi.ToString();
            int dogruYer = 0;

            // --- RENK KODLARI BURADA (Geri Geldi) ---
            for (int i = 0; i < basamakSayisi; i++)
            {
                Button kutu = new Button();
                kutu.Size = new Size(40, 40);
                kutu.Location = new Point(i * 45, 0);
                kutu.Text = tahmin[i].ToString();
                kutu.Font = new Font("Arial", 12, FontStyle.Bold);
                kutu.ForeColor = Color.White;
                kutu.FlatStyle = FlatStyle.Flat;

                // RENKLENDİRME MANTIĞI
                if (tahmin[i] == gizli[i]) // Hem rakam doğru hem yeri doğru
                {
                    kutu.BackColor = Color.Green;
                    dogruYer++;
                }
                else if (gizli.Contains(tahmin[i])) // Rakam var ama yeri yanlış
                {
                    kutu.BackColor = Color.Orange;
                }
                else // Rakam hiç yok
                {
                    kutu.BackColor = Color.Red;
                }

                pnlKutular.Controls.Add(kutu);
            }

            // İPUCU (Aşağı/Yukarı)
            int tahminSayi = int.Parse(tahmin);
            string ipucu = "";
            if (tahminSayi < rastgeleSayi) ipucu = "↑ BÜYÜLT";
            else ipucu = "↓ KÜÇÜLT";

            thmnListBox.Items.Add($"{tahmin} -> {ipucu}");

            // KAZANMA KONTROLÜ
            if (dogruYer == basamakSayisi)
            {
                MessageBox.Show($"TEBRİKLER! Puanın: {puan}");
                SkorKaydet();
                SkorTablosunuGetir();
                OyunBitti();
                return;
            }

            // HAK DÜŞÜRME
            kalanHak--;
            puan -= 10;
            lblHak.Text = "Hak: " + kalanHak;

            if (kalanHak <= 0)
            {
                MessageBox.Show($"Kaybettin! Sayı: {rastgeleSayi}");
                OyunBitti();
            }

            txtTahmin.Text = "";
            txtTahmin.Focus();
        }

        private void OyunBitti()
        {
            txtTahmin.Enabled = false; // Yazı yazmayı kapat
            thmnButton.Enabled = false; // Butona basmayı kapat
        }

        private void SkorKaydet()
        {
            if (string.IsNullOrEmpty(aktifKullanici)) return; // Eğer kullanıcı adı yoksa işlem yapma

            using (SqlConnection baglanti = new SqlConnection(connectionString)) // Bağlantıyı kur
            {
                try
                {
                    baglanti.Open(); // Bağlantıyı aç
                    // Veri ekleme sorgusu (INSERT)
                    string sql = "INSERT INTO Skorlar (OyuncuAdi, Puan, BasamakSayisi, Tarih) VALUES (@p1, @p2, @p3, @p4)";
                    SqlCommand komut = new SqlCommand(sql, baglanti); // Komutu hazırla

                    // Parametreleri (değerleri) güvenli bir şekilde ekle
                    komut.Parameters.AddWithValue("@p1", aktifKullanici);
                    komut.Parameters.AddWithValue("@p2", puan);
                    komut.Parameters.AddWithValue("@p3", basamakSayisi);
                    komut.Parameters.AddWithValue("@p4", DateTime.Now); // Şu anki zamanı ekle

                    komut.ExecuteNonQuery(); // Komutu çalıştır (kaydet)
                }
                catch (Exception ex) { MessageBox.Show("Skor hatası: " + ex.Message); } // Hata varsa göster
            }
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

            string connectionString = "Data Source=AZAHIDOFFICAL\\SQLEXPRESS;Initial Catalog=numberGame;Integrated Security=True";

            // 2. Bağlantıyı kuruyoruz
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open(); // Kapıyı açtık

                    // 3. SQL Sorgusu (Hangi verileri istiyoruz?)
                    string sorgu = "SELECT OyuncuAdi, BasamakSayisi, Puan, Tarih FROM Skorlar";

                    // 4. Veriyi çeken araç (Kamyon)
                    SqlDataAdapter veriCekici = new SqlDataAdapter(sorgu, baglanti);

                    // 5. Veriyi hafızadaki tabloya boşaltma
                    System.Data.DataTable sanalTablo = new System.Data.DataTable();
                    veriCekici.Fill(sanalTablo);

                    // 6. Son olarak ekrandaki Grid'e yansıtma
                    dgvSkor.DataSource = sanalTablo;
                }
                catch (Exception hata)
                {
                    // Bir hata olursa (mesela SQL kapalıysa) mesaj versin
                    MessageBox.Show("Hata oluştu: " + hata.Message);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}