using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    public class TemelSinif
    {
        //FormAna temelForm = new FormAna();
        public string ilkIsaret = "<isim>";
        public string sonIsaret = "</isim>";

        public static string[] metinDizi;
        public static string[] metinDiziOrijinal;
        public static bool[] metinDiziIsaretliMi;
        //public static bool[] anahtarHarita;

        public void MetinParcala(string metin)
        {
            //char[] noktalama = { Convert.ToChar(' '), Convert.ToChar('+'), Convert.ToChar('-'), Convert.ToChar('%'), Convert.ToChar('&'),Convert.ToChar('?'),
            //                       Convert.ToChar('!')};

            //string metinStr = temelForm.TextBoxDeger();


            metinDizi = metin.Split(' ');
            metinDiziOrijinal = metin.Split(' ');

            metinDiziIsaretliMi=new bool[metinDizi.Length];
            for (int i = 0; i < metinDizi.Length; i++)
                metinDiziIsaretliMi[i] = false;
        }
    }
}
