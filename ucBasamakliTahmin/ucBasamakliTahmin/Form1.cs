using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucBasamakliTahmin
{
    public partial class Form1 : Form
    {
        int rastgeleSayi = 0;
        int kalanHak = 10;
        bool oyunBasladi = false;
        int exact = 0;
        int misplaced = 0;
        int puan = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void bsltButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // Benzersiz rakamlardan oluşan 3 basamaklı sayı üret
            while (true)
            {
                int aday = rnd.Next(100, 1000);
                string s = aday.ToString();
                if (s[0] != s[1] && s[0] != s[2] && s[1] != s[2])
                {
                    rastgeleSayi = aday;
                    break;
                }
            }

            kalanHak = 10;
            oyunBasladi = true;

            lblHak.Text = "Kalan Hak : " + kalanHak;
            txtTahmin.Enabled = true;
            thmnButton.Enabled = true;
            txtTahmin.Text = "";
            thmnListBox.Items.Clear(); // geçmiş temizlenir

            MessageBox.Show("Oyun başladı! 3 basamaklı (farklı rakamlı) sayıyı tahmin et.", "Bilgi");
        }

        private void thmnButton_Click(object sender, EventArgs e)
        {
            if (!oyunBasladi)
            {
                MessageBox.Show("Lütfen önce oyunu başlat.", "Uyarı");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTahmin.Text))
            {
                MessageBox.Show("Bir tahmin gir!", "Uyarı");
                return;
            }

            int tahmin;
            bool sayiMi = int.TryParse(txtTahmin.Text, out tahmin);

            if (!sayiMi || tahmin < 100 || tahmin > 999)
            {
                MessageBox.Show("3 basamaklı bir sayı gir!", "Uyarı");
                return;
            }

            string tahminStr = tahmin.ToString();
            if (!(tahminStr[0] != tahminStr[1] && tahminStr[0] != tahminStr[2] && tahminStr[1] != tahminStr[2]))
            {
                MessageBox.Show("Tahmin ettiğin sayının rakamları birbirinden farklı olmalı!", "Uyarı");
                return;
            }

            // Tahminden önce exact ve misplaced'i sıfırla
            exact = 0;
            misplaced = 0;

            string durum = "";
            string gizliStr = rastgeleSayi.ToString();

            bool[] matchedSecret = new bool[3];
            bool[] matchedGuess = new bool[3];

            // Exact hesapla
            for (int i = 0; i < 3; i++)
            {
                if (tahminStr[i] == gizliStr[i])
                {
                    exact++;
                    matchedSecret[i] = true;
                    matchedGuess[i] = true;
                }
            }

            // Misplaced hesapla
            for (int i = 0; i < 3; i++)
            {
                if (matchedGuess[i]) continue;
                for (int j = 0; j < 3; j++)
                {
                    if (matchedSecret[j]) continue;
                    if (tahminStr[i] == gizliStr[j])
                    {
                        misplaced++;
                        matchedSecret[j] = true;
                        matchedGuess[i] = true;
                        break;
                    }
                }
            }

            // Hak azaltma
            if (exact == 0)
            {
                kalanHak -= 2;
                puan -= 20;
            }
            else
            {
                kalanHak--;
                puan -= 10;
            }
            lblHak.Text = "Kalan Hak : " + kalanHak;

            // Doğru tahmin kontrolü
            if (exact == 3)
            {
                durum = "Doğru! 🎯";
                thmnListBox.Items.Add($"Tahmin: {tahmin} → +{exact} | -{misplaced} → {durum}");
                thmnListBox.Items.Add($"Puanın: {puan}");
                MessageBox.Show("Tebrikler! Sayıyı doğru tahmin ettin.", "Kazandın");
                oyunBasladi = false;
                txtTahmin.Enabled = false;
                thmnButton.Enabled = false;
            }
            else
            {
                durum = tahmin < rastgeleSayi ? "Daha büyük dene ↑" : "Daha küçük dene ↓";
                thmnListBox.Items.Add($"Tahmin: {tahmin} → +{exact} | -{misplaced} → {durum}");
            }

            if (kalanHak <= 0 && oyunBasladi)
            {
                MessageBox.Show($"Hakkın bitti! Doğru sayı: {rastgeleSayi}", "Oyun Bitti");
                oyunBasladi = false;
                txtTahmin.Enabled = false;
                thmnButton.Enabled = false;
                thmnListBox.Items.Add($"Oyun Bitti! Doğru sayı: {rastgeleSayi}");
                thmnListBox.Items.Add($"Puanın: {puan} Kaybettin!");
            }

            txtTahmin.Clear();
            txtTahmin.Focus();
        }
    }
}
