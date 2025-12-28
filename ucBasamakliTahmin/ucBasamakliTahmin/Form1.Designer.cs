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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.bsltButton = new System.Windows.Forms.Button();
            this.lblHak = new System.Windows.Forms.Label();
            this.txtTahmin = new System.Windows.Forms.TextBox();
            this.thmnButton = new System.Windows.Forms.Button();
            this.thmnListBox = new System.Windows.Forms.ListBox();
            this.lblDeneme = new System.Windows.Forms.Label();
            this.dgvSkor = new System.Windows.Forms.DataGridView();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlKutular = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Alternates ExtraBold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(346, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Game";
            // 
            // bsltButton
            // 
            this.bsltButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsltButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.bsltButton.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bsltButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bsltButton.Location = new System.Drawing.Point(347, 72);
            this.bsltButton.Name = "bsltButton";
            this.bsltButton.Size = new System.Drawing.Size(303, 60);
            this.bsltButton.TabIndex = 1;
            this.bsltButton.Text = "Başlat / Yeniden Başlat";
            this.bsltButton.UseVisualStyleBackColor = false;
            this.bsltButton.Click += new System.EventHandler(this.bsltButton_Click);
            // 
            // lblHak
            // 
            this.lblHak.AutoSize = true;
            this.lblHak.Font = new System.Drawing.Font("Montserrat Alternates ExtraBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHak.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblHak.Location = new System.Drawing.Point(385, 135);
            this.lblHak.Name = "lblHak";
            this.lblHak.Size = new System.Drawing.Size(202, 34);
            this.lblHak.TabIndex = 2;
            this.lblHak.Text = "Kalan Hak : 10";
            // 
            // txtTahmin
            // 
            this.txtTahmin.Location = new System.Drawing.Point(299, 181);
            this.txtTahmin.Multiline = true;
            this.txtTahmin.Name = "txtTahmin";
            this.txtTahmin.Size = new System.Drawing.Size(187, 33);
            this.txtTahmin.TabIndex = 3;
            // 
            // thmnButton
            // 
            this.thmnButton.Font = new System.Drawing.Font("Montserrat Alternates ExtraBold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.thmnButton.Location = new System.Drawing.Point(511, 181);
            this.thmnButton.Name = "thmnButton";
            this.thmnButton.Size = new System.Drawing.Size(154, 33);
            this.thmnButton.TabIndex = 4;
            this.thmnButton.Text = "Tahmin Et";
            this.thmnButton.UseVisualStyleBackColor = true;
            this.thmnButton.Click += new System.EventHandler(this.thmnButton_Click);
            // 
            // thmnListBox
            // 
            this.thmnListBox.FormattingEnabled = true;
            this.thmnListBox.ItemHeight = 16;
            this.thmnListBox.Location = new System.Drawing.Point(274, 297);
            this.thmnListBox.Name = "thmnListBox";
            this.thmnListBox.Size = new System.Drawing.Size(410, 196);
            this.thmnListBox.TabIndex = 5;
            // 
            // lblDeneme
            // 
            this.lblDeneme.AutoSize = true;
            this.lblDeneme.Location = new System.Drawing.Point(465, 249);
            this.lblDeneme.Name = "lblDeneme";
            this.lblDeneme.Size = new System.Drawing.Size(0, 16);
            this.lblDeneme.TabIndex = 6;
            // 
            // dgvSkor
            // 
            this.dgvSkor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkor.Location = new System.Drawing.Point(21, 18);
            this.dgvSkor.Name = "dgvSkor";
            this.dgvSkor.RowHeadersWidth = 51;
            this.dgvSkor.RowTemplate.Height = 24;
            this.dgvSkor.Size = new System.Drawing.Size(227, 253);
            this.dgvSkor.TabIndex = 7;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(312, 237);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(102, 20);
            this.rb3.TabIndex = 8;
            this.rb3.TabStop = true;
            this.rb3.Text = "3 Basamaklı";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(428, 237);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(102, 20);
            this.rb4.TabIndex = 9;
            this.rb4.TabStop = true;
            this.rb4.Text = "4 Basamaklı";
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(540, 237);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(102, 20);
            this.rb5.TabIndex = 10;
            this.rb5.TabStop = true;
            this.rb5.Text = "5 Basamaklı";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // pnlKutular
            // 
            this.pnlKutular.Location = new System.Drawing.Point(671, 12);
            this.pnlKutular.Name = "pnlKutular";
            this.pnlKutular.Size = new System.Drawing.Size(308, 259);
            this.pnlKutular.TabIndex = 11;
            // 
            // Form1
            // 
            this.AcceptButton = this.thmnButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 565);
            this.Controls.Add(this.pnlKutular);
            this.Controls.Add(this.rb5);
            this.Controls.Add(this.rb4);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.dgvSkor);
            this.Controls.Add(this.lblDeneme);
            this.Controls.Add(this.thmnListBox);
            this.Controls.Add(this.thmnButton);
            this.Controls.Add(this.txtTahmin);
            this.Controls.Add(this.lblHak);
            this.Controls.Add(this.bsltButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 3 Basamaklı Sayı Tahmin Oyunu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkor)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvSkor;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlKutular;
    }
}

