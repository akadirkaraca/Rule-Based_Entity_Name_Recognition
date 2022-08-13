using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    class DosyaSinif
    {
        string dosyadanOkunanMetin;

        public string DosyadanOkunanMetin()
        {
            return dosyadanOkunanMetin;
        }

        public void Kaydet(string textBoxText)
        {
            if (textBoxText == "")
                MessageBox.Show("Metin Alanını Boş Bırakmamalısınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                save.Filter = "Metin Dosyası|*.txt";

                //Aşağıdaki kod satırları daha önce kayıtlı dosya var mı ve üzerine yazılsın mı soruları için. Ama koda eklemedim.
                //save.OverwritePrompt = true;
                //save.CreatePrompt = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(save.FileName);
                    sw.WriteLine(textBoxText);
                    sw.Close();
                }
            }
        }

        public void Ac()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            open.Filter = "Metin Dosyası |*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(open.FileName, Encoding.UTF8,true);
                dosyadanOkunanMetin = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
