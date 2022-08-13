using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    class AnalizSinif : KuralSinif
    {
        public static string analizEdilenMetin = "";
        int metinDiziLength = 0;

        public void AnalizEt()
        {
            metinDiziLength = metinDizi.Length;
            for (int i = 0; i < metinDizi.Length; i++)
            {
                if (metinDiziIsaretliMi[i])
                {
                    continue;
                }
                else
                {
                    KuralKontrolEt(metinDizi[i], i);
                }

            }
            foreach (string str in metinDizi)
                analizEdilenMetin += str + " ";
        }
    }
}
