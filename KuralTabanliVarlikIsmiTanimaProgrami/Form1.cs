using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }

        public string metin;
        public bool panelDurum = false;

        DosyaSinif DosyaFormAna = new DosyaSinif();
        SozlukSinif sozlukFormAna = new SozlukSinif();
        TemelSinif temelFormAna = new TemelSinif();
        AnalizSinif analizFormAna = new AnalizSinif();


        private void FormAna_Load(object sender, EventArgs e)
        {
            sozlukFormAna.SozlukleriAl();
            kontrolEtToolStripMenuItem.Enabled = false;
        }

        private void FormAna_Resize(object sender, EventArgs e)
        {
            if (panelKontrolEt.Visible)
            {
                textBoxAnalizEdilen.Size = new System.Drawing.Size(textBoxAnalizEdilen.Size.Width, (panelKontrolEt.Size.Height / 2) - 1);
                textBoxDosyadanOkunan.Location = new System.Drawing.Point(textBoxDosyadanOkunan.Location.X, (panelKontrolEt.Size.Height / 2) + 1);
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaFormAna.Kaydet(richTextBoxAna.Text);
        }

        private void analizEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temelFormAna.MetinParcala(richTextBoxAna.Text.ToString());
            analizFormAna.AnalizEt();
            richTextBoxAna.Text = AnalizSinif.analizEdilenMetin;
            kontrolEtToolStripMenuItem.Enabled = true;
        }

        private void acToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaFormAna.Ac();
            richTextBoxAna.Text = DosyaFormAna.DosyadanOkunanMetin();
        }

        private void kontrolEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] dosyadanOkunanDizi;
            bool[] dosyadanOkunanDiziIsaretliMi;

            float truePositive = 0;
            float falsePositive = 0;
            float trueNegative = 0;
            float falseNegative = 0;
            int dosyadanOkunanDiziIsimSayisi = 0;
            float tahminiDogrulukOrani = 0;

            PanelAcKapat();
            textBoxAnalizEdilen.Text = AnalizSinif.analizEdilenMetin;
            DialogResult dialog = MessageBox.Show("Kontrol için işaretlenmiş metini seçin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                DosyaFormAna.Ac();
                textBoxDosyadanOkunan.Text = DosyaFormAna.DosyadanOkunanMetin();
            }

            //Daha önce işaretleyip karşılaştırmak için aldığımız dosyanın parçalanmasını, işaretli mi kontrolu için bool diziye false değer set etmek için 
            dosyadanOkunanDizi = textBoxDosyadanOkunan.Text.Split(' ');
            dosyadanOkunanDiziIsaretliMi = new bool[dosyadanOkunanDizi.Length];
            for (int i = 0; i < dosyadanOkunanDiziIsaretliMi.Length; i++)
                dosyadanOkunanDiziIsaretliMi[i] = false;

            //Daha önce işaretleyip karşılaştırmak için aldığımız dosyanın işaretli olduğu indexleri haritalamak için. Yani işaretli kısım hangi index veya indexlerde olduğunun tespiti.
            for (int i = 0; i < dosyadanOkunanDizi.Length; i++)
            {
                if (dosyadanOkunanDizi[i].Contains(temelFormAna.ilkIsaret) && dosyadanOkunanDizi[i].Contains(temelFormAna.sonIsaret))
                    dosyadanOkunanDiziIsaretliMi[i] = true;
                else if (dosyadanOkunanDizi[i].Contains(temelFormAna.ilkIsaret))
                {
                    do
                    {
                        dosyadanOkunanDiziIsaretliMi[i++] = true;
                    }
                    while (!dosyadanOkunanDizi[i].Contains(temelFormAna.sonIsaret));
                    dosyadanOkunanDiziIsaretliMi[i] = true;
                }
                else continue;
            }

            //Önceden el ile işaretlenmiş dosyadaki işaretli isim sayısının tespiti için
            for (int i = 0; i < dosyadanOkunanDiziIsaretliMi.Length; i++)
                if (dosyadanOkunanDiziIsaretliMi[i])
                    dosyadanOkunanDiziIsimSayisi++;
            try
            {
                //El ile işaretli isim ile analiz sonucu işaretlenen isimler aynı mı kontrolunü, yani her iki işaretlimi bool dizilerindeki indexlerini karşılaştırarak doğru olanları sayıyoruz
                for (int i = 0; i < dosyadanOkunanDiziIsaretliMi.Length; i++)
                {
                    if (TemelSinif.metinDiziIsaretliMi[i] == true && dosyadanOkunanDiziIsaretliMi[i] == true)
                        truePositive++;
                    else if (TemelSinif.metinDiziIsaretliMi[i] == false && dosyadanOkunanDiziIsaretliMi[i] == false)
                        falsePositive++;
                    else if (TemelSinif.metinDiziIsaretliMi[i] == true && dosyadanOkunanDiziIsaretliMi[i] == false)
                        trueNegative++;
                    else if (TemelSinif.metinDiziIsaretliMi[i] == false && dosyadanOkunanDiziIsaretliMi[i] == true)
                        falseNegative++;
                }

                //Burada ise analiz sonucu doğru olarak işaretlenen yani metinDiziIsimSayisi na denk gelen sayiyi, önceden el ile işaretlenmiş isim sayısı yani dosyadanOkunanDiziIsimSayisi na bölüp 100 ile çarpımı bize yüzdelik doğruluk oranını verecektir.
                tahminiDogrulukOrani = ((truePositive + falsePositive) / (truePositive + falsePositive + trueNegative + falseNegative)) * 100;
                MessageBox.Show(String.Format("Tahmini Doğruluk Oranı = %{0:0.00}", tahminiDogrulukOrani), "Doğruluk Oranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Doğruluk Hesaplanırken Hata Oluştu.\n" + hata, "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------------------------------
        public void PanelAcKapat()
        {
            if (!panelDurum)
            {
                panelKontrolEt.Visible = true;
                analizEtToolStripMenuItem.Enabled = false;
                dosyaToolStripMenuItem.Enabled = false;
                //kontrolEtToolStripMenuItem.Enabled = false;
                panelDurum = true;
            }
            else
            {
                panelKontrolEt.Visible = false;
                analizEtToolStripMenuItem.Enabled = true;
                dosyaToolStripMenuItem.Enabled = true;
                kontrolEtToolStripMenuItem.Enabled = true;
                panelDurum = false;
            }
        }

        public string TextBoxDeger()
        {
            return richTextBoxAna.Text.ToString();
        }
    }
}