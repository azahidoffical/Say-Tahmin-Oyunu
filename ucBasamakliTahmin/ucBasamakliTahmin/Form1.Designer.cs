namespace ucBasamakliTahmin
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.bsltButton = new System.Windows.Forms.Button();
            this.lblHak = new System.Windows.Forms.Label();
            this.txtTahmin = new System.Windows.Forms.TextBox();
            this.thmnButton = new System.Windows.Forms.Button();
            this.thmnListBox = new System.Windows.Forms.ListBox();
            this.lblDeneme = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Alternates ExtraBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(206, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "3 Haneli Sayı Tahmin Oyunu";
            // 
            // bsltButton
            // 
            this.bsltButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsltButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.bsltButton.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bsltButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bsltButton.Location = new System.Drawing.Point(275, 95);
            this.bsltButton.Name = "bsltButton";
            this.bsltButton.Size = new System.Drawing.Size(255, 54);
            this.bsltButton.TabIndex = 1;
            this.bsltButton.Text = "Başlat / Yeniden Başlat";
            this.bsltButton.UseVisualStyleBackColor = false;
            this.bsltButton.Click += new System.EventHandler(this.bsltButton_Click);
            // 
            // lblHak
            // 
            this.lblHak.AutoSize = true;
            this.lblHak.Font = new System.Drawing.Font("Montserrat Alternates ExtraBold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHak.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblHak.Location = new System.Drawing.Point(322, 158);
            this.lblHak.Name = "lblHak";
            this.lblHak.Size = new System.Drawing.Size(157, 26);
            this.lblHak.TabIndex = 2;
            this.lblHak.Text = "Kalan Hak : 10";
            // 
            // txtTahmin
            // 
            this.txtTahmin.Location = new System.Drawing.Point(275, 204);
            this.txtTahmin.Multiline = true;
            this.txtTahmin.Name = "txtTahmin";
            this.txtTahmin.Size = new System.Drawing.Size(141, 33);
            this.txtTahmin.TabIndex = 3;
            // 
            // thmnButton
            // 
            this.thmnButton.Font = new System.Drawing.Font("Montserrat Alternates ExtraBold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.thmnButton.Location = new System.Drawing.Point(422, 204);
            this.thmnButton.Name = "thmnButton";
            this.thmnButton.Size = new System.Drawing.Size(108, 33);
            this.thmnButton.TabIndex = 4;
            this.thmnButton.Text = "Tahmin Et";
            this.thmnButton.UseVisualStyleBackColor = true;
            this.thmnButton.Click += new System.EventHandler(this.thmnButton_Click);
            // 
            // thmnListBox
            // 
            this.thmnListBox.FormattingEnabled = true;
            this.thmnListBox.ItemHeight = 16;
            this.thmnListBox.Location = new System.Drawing.Point(189, 274);
            this.thmnListBox.Name = "thmnListBox";
            this.thmnListBox.Size = new System.Drawing.Size(410, 164);
            this.thmnListBox.TabIndex = 5;
            // 
            // lblDeneme
            // 
            this.lblDeneme.AutoSize = true;
            this.lblDeneme.Location = new System.Drawing.Point(390, 255);
            this.lblDeneme.Name = "lblDeneme";
            this.lblDeneme.Size = new System.Drawing.Size(0, 16);
            this.lblDeneme.TabIndex = 6;
            // 
            // Form1
            // 
            this.AcceptButton = this.thmnButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDeneme);
            this.Controls.Add(this.thmnListBox);
            this.Controls.Add(this.thmnButton);
            this.Controls.Add(this.txtTahmin);
            this.Controls.Add(this.lblHak);
            this.Controls.Add(this.bsltButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 3 Basamaklı Sayı Tahmin Oyunu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bsltButton;
        private System.Windows.Forms.Label lblHak;
        private System.Windows.Forms.TextBox txtTahmin;
        private System.Windows.Forms.Button thmnButton;
        private System.Windows.Forms.ListBox thmnListBox;
        private System.Windows.Forms.Label lblDeneme;
    }
}

