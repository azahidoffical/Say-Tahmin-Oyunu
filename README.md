# C# Üç Basamaklı Sayı Tahmin Oyunu

Bu proje, C# Windows Forms ve SQL Server kullanılarak geliştirilmiş, veritabanı bağlantılı bir sayı tahmin oyunudur. Kullanıcılar sisteme kayıt olup giriş yaptıktan sonra, seçtikleri zorluk seviyesine göre (3, 4 veya 5 basamaklı) gizli sayıyı bulmaya çalışırlar.

## 🎯 Projenin Amacı
* C# ve ADO.NET ile SQL Server veri tabanı işlemlerini (CRUD) uygulamak.
* Algoritma kurma ve mantıksal kıyaslama yeteneklerini geliştirmek.
* Kullanıcı dostu arayüz tasarımı yapmak.

## 🚀 Özellikler

* **Kullanıcı Sistemi:** Yeni üye kaydı (`FormKayit`) ve kullanıcı girişi (`FormGiris`).
* **Dinamik Zorluk Seviyesi:** 3, 4 veya 5 basamaklı oyun seçeneği.
* **Görsel İpuçları:** * 🟩 **Yeşil:** Rakam ve yeri doğru.
    * 🟧 **Turuncu:** Rakam var ama yeri yanlış.
    * 🟥 **Kırmızı:** Rakam sayıda yok.
* **Akıllı Yönlendirme:** Tahmin edilen sayının gizli sayıdan büyük veya küçük olduğuna dair ok işaretli (↑ ↓) ipuçları.
* **Skor Tablosu:** En yüksek puanı alan oyuncuların listelendiği `DataGridView` alanı.
* **Sanal Klavye:** Ekrana basarak sayı girişi yapabilme.

## 🛠️ Kullanılan Teknolojiler

* **Dil:** C# (.NET Framework)
* **Arayüz:** Windows Forms Application
* **Veritabanı:** Microsoft SQL Server (LocalDB veya SQLEXPRESS)
* **Kütüphaneler:** `System.Data.SqlClient`, `System.Drawing`, `System.Windows.Forms`

## ⚙️ Kurulum ve Çalıştırma

1.  Projeyi bilgisayarınıza indirin veya klonlayın.
2.  **Veritabanı Ayarı:**
    * SQL Server'ınızda `numberGame` adında bir veritabanı oluşturun.
    * Aşağıdaki tabloları oluşturun:
        * `Kullanicilar` (Ad, Soyad, Telefon, Eposta, OyuncuAdi, Sifre)
        * `Skorlar` (OyuncuAdi, Puan, BasamakSayisi, Tarih)
3.  **Connection String:**
    * Kod içerisindeki `connectionString` değişkenini kendi bilgisayarınızın SQL sunucu adına göre güncelleyin:
    * `Data Source=SENIN_BILGISAYAR_ADIN\SQLEXPRESS;Initial Catalog=numberGame;Integrated Security=True`
4.  Visual Studio ile projeyi açıp `Start` tuşuna basın.

## 📷 Ekran Görüntüleri
*(Buraya oyunun çalıştığına dair 1-2 ekran görüntüsü eklerseniz GitHub'da çok şık durur)*

---
**Geliştirici:** [Adın Soyadın]
