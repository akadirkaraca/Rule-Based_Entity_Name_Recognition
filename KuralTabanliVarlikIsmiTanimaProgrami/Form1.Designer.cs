namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    partial class FormAna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripAna = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.analizEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontrolEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxAna = new System.Windows.Forms.RichTextBox();
            this.panelKontrolEt = new System.Windows.Forms.Panel();
            this.textBoxDosyadanOkunan = new System.Windows.Forms.RichTextBox();
            this.textBoxAnalizEdilen = new System.Windows.Forms.RichTextBox();
            this.menuStripAna.SuspendLayout();
            this.panelKontrolEt.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripAna
            // 
            this.menuStripAna.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.analizEtToolStripMenuItem,
            this.kontrolEtToolStripMenuItem});
            this.menuStripAna.Location = new System.Drawing.Point(0, 0);
            this.menuStripAna.Name = "menuStripAna";
            this.menuStripAna.Size = new System.Drawing.Size(858, 24);
            this.menuStripAna.TabIndex = 0;
            this.menuStripAna.Text = "menuStripAna";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acToolStripMenuItem,
            this.kaydetToolStripMenuItem1});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // acToolStripMenuItem
            // 
            this.acToolStripMenuItem.Name = "acToolStripMenuItem";
            this.acToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.acToolStripMenuItem.Text = "Aç";
            this.acToolStripMenuItem.Click += new System.EventHandler(this.acToolStripMenuItem_Click);
            // 
            // kaydetToolStripMenuItem1
            // 
            this.kaydetToolStripMenuItem1.Name = "kaydetToolStripMenuItem1";
            this.kaydetToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.kaydetToolStripMenuItem1.Text = "Kaydet";
            this.kaydetToolStripMenuItem1.Click += new System.EventHandler(this.kaydetToolStripMenuItem_Click);
            // 
            // analizEtToolStripMenuItem
            // 
            this.analizEtToolStripMenuItem.Name = "analizEtToolStripMenuItem";
            this.analizEtToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.analizEtToolStripMenuItem.Text = "Analiz Et";
            this.analizEtToolStripMenuItem.Click += new System.EventHandler(this.analizEtToolStripMenuItem_Click);
            // 
            // kontrolEtToolStripMenuItem
            // 
            this.kontrolEtToolStripMenuItem.Name = "kontrolEtToolStripMenuItem";
            this.kontrolEtToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.kontrolEtToolStripMenuItem.Text = "Kontrol Et";
            this.kontrolEtToolStripMenuItem.Click += new System.EventHandler(this.kontrolEtToolStripMenuItem_Click);
            // 
            // richTextBoxAna
            // 
            this.richTextBoxAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxAna.Location = new System.Drawing.Point(0, 24);
            this.richTextBoxAna.Name = "richTextBoxAna";
            this.richTextBoxAna.Size = new System.Drawing.Size(858, 378);
            this.richTextBoxAna.TabIndex = 1;
            this.richTextBoxAna.Text = "";
            // 
            // panelKontrolEt
            // 
            this.panelKontrolEt.Controls.Add(this.textBoxDosyadanOkunan);
            this.panelKontrolEt.Controls.Add(this.textBoxAnalizEdilen);
            this.panelKontrolEt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKontrolEt.Location = new System.Drawing.Point(0, 24);
            this.panelKontrolEt.Name = "panelKontrolEt";
            this.panelKontrolEt.Size = new System.Drawing.Size(858, 378);
            this.panelKontrolEt.TabIndex = 2;
            this.panelKontrolEt.Visible = false;
            // 
            // textBoxDosyadanOkunan
            // 
            this.textBoxDosyadanOkunan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDosyadanOkunan.Location = new System.Drawing.Point(3, 186);
            this.textBoxDosyadanOkunan.Name = "textBoxDosyadanOkunan";
            this.textBoxDosyadanOkunan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBoxDosyadanOkunan.Size = new System.Drawing.Size(852, 184);
            this.textBoxDosyadanOkunan.TabIndex = 0;
            this.textBoxDosyadanOkunan.Text = "";
            // 
            // textBoxAnalizEdilen
            // 
            this.textBoxAnalizEdilen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAnalizEdilen.Location = new System.Drawing.Point(3, 0);
            this.textBoxAnalizEdilen.Name = "textBoxAnalizEdilen";
            this.textBoxAnalizEdilen.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBoxAnalizEdilen.Size = new System.Drawing.Size(852, 184);
            this.textBoxAnalizEdilen.TabIndex = 0;
            this.textBoxAnalizEdilen.Text = "";
            // 
            // FormAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 402);
            this.Controls.Add(this.panelKontrolEt);
            this.Controls.Add(this.richTextBoxAna);
            this.Controls.Add(this.menuStripAna);
            this.MainMenuStrip = this.menuStripAna;
            this.Name = "FormAna";
            this.Text = "Kural Tabanlı Varlık İsmi Tanıma";
            this.Load += new System.EventHandler(this.FormAna_Load);
            this.Resize += new System.EventHandler(this.FormAna_Resize);
            this.menuStripAna.ResumeLayout(false);
            this.menuStripAna.PerformLayout();
            this.panelKontrolEt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAna;
        private System.Windows.Forms.ToolStripMenuItem analizEtToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxAna;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kontrolEtToolStripMenuItem;
        private System.Windows.Forms.Panel panelKontrolEt;
        private System.Windows.Forms.RichTextBox textBoxAnalizEdilen;
        private System.Windows.Forms.RichTextBox textBoxDosyadanOkunan;
    }
}

