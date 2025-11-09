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
        public Form1()
        {
            InitializeComponent();
        }

        private void bsltButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            rastgeleSayi = rnd.Next(100, 1000); // 3 basamaklı sayı üret
            kalanHak = 10;
            oyunBasladi = true;

            lblHak.Text = "Kalan Hak : " + kalanHak;
            txtTahmin.Enabled = true;
            thmnButton.Enabled = true;
            txtTahmin.Text = "";
            thmnListBox.Items.Clear(); // geçmiş temizlenir

            MessageBox.Show("Oyun başladı! 3 basamaklı sayıyı tahmin et.", "Bilgi");
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

            kalanHak--;
            lblHak.Text = "Kalan Hak : " + kalanHak;

            string durum = "";

            if (tahmin == rastgeleSayi)
            {
                durum = "Doğru! 🎯";
                thmnListBox.Items.Add($"Tahmin: {tahmin} → {durum}");
                MessageBox.Show("Tebrikler! Sayıyı doğru tahmin ettin.", "Kazandın");
                oyunBasladi = false;
                txtTahmin.Enabled = false;
                thmnButton.Enabled = false;
            }
            else if (tahmin < rastgeleSayi)
            {
                durum = "Daha büyük dene ↑";
                thmnListBox.Items.Add($"Tahmin: {tahmin} → {durum}");
            }
            else
            {
                durum = "Daha küçük dene ↓";
                thmnListBox.Items.Add($"Tahmin: {tahmin} → {durum}");
            }

            if (kalanHak == 0 && oyunBasladi)
            {
                MessageBox.Show($"Hakkın bitti! Doğru sayı: {rastgeleSayi}", "Oyun Bitti");
                oyunBasladi = false;
                txtTahmin.Enabled = false;
                thmnButton.Enabled = false;
                thmnListBox.Items.Add($"Oyun Bitti! Doğru sayı: {rastgeleSayi}");
            }

            txtTahmin.Clear();
            txtTahmin.Focus();
        }
    }
}
