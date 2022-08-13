using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    class SozlukSinif : TemelSinif
    {
        public static int progRun = 1;
        StreamReader oku;

        string dosya_SozlukOrganizasyon_IsimdenSonra = @"C:\Users\ahmet\Desktop\KuralTabanliVarlikIsmiTanimaProgrami-v1.3.1\KuralTabanliVarlikIsmiTanimaProgrami\SozlukAnahtarKelime\SozlukOrganizasyon_IsimdenSonra.txt";
        string dosya_SozlukOrganizasyon_IsminIcinde = @"C:\Users\ahmet\Desktop\KuralTabanliVarlikIsmiTanimaProgrami-v1.3.1\KuralTabanliVarlikIsmiTanimaProgrami\SozlukAnahtarKelime\SozlukOrganizasyon_IsminIcinde.txt";
        string dosya_SozlukUnvan_IsimdenOnce = @"C:\Users\ahmet\Desktop\KuralTabanliVarlikIsmiTanimaProgrami-v1.3.1\KuralTabanliVarlikIsmiTanimaProgrami\SozlukAnahtarKelime\SozlukUnvan_IsimdenOnce.txt";
        string dosya_SozlukUnvan_IsimdenSonra = @"C:\Users\ahmet\Desktop\KuralTabanliVarlikIsmiTanimaProgrami-v1.3.1\KuralTabanliVarlikIsmiTanimaProgrami\SozlukAnahtarKelime\SozlukUnvan_IsimdenSonra.txt";
        string dosya_SozlukYer_IsimdenOnce = @"C:\Users\ahmet\Desktop\KuralTabanliVarlikIsmiTanimaProgrami-v1.3.1\KuralTabanliVarlikIsmiTanimaProgrami\SozlukAnahtarKelime\SozlukYer_IsimdenOnce.txt";
        string dosya_SozlukYer_IsminIcinde = @"C:\Users\ahmet\Desktop\KuralTabanliVarlikIsmiTanimaProgrami-v1.3.1\KuralTabanliVarlikIsmiTanimaProgrami\SozlukAnahtarKelime\SozlukYer_IsminIcinde.txt";
        string dosya_SozlukYer_IsimdenSonra = @"C:\Users\ahmet\Desktop\KuralTabanliVarlikIsmiTanimaProgrami-v1.3.1\KuralTabanliVarlikIsmiTanimaProgrami\SozlukAnahtarKelime\SozlukYer_IsimdenSonra.txt";

        public static ArrayList sozluk_Organizasyon_IsimdenSonra = new ArrayList();
        public static ArrayList sozluk_Organizasyon_IsminIcinde = new ArrayList();
        public static ArrayList sozluk_Unvan_IsimdenOnce = new ArrayList();
        public static ArrayList sozluk_Unvan_IsimdenSonra = new ArrayList();
        public static ArrayList sozluk_Yer_IsminIcinde = new ArrayList();
        public static ArrayList sozluk_Yer_IsimdenOnce = new ArrayList();
        public static ArrayList sozluk_Yer_IsimdenSonra = new ArrayList();

        public void SozlukleriAl()
        {
            string sozluk;

            int i = 0;
            try
            {
                if (progRun == 1)
                {
                    //----------------------------------------------------------
                    oku = new StreamReader(dosya_SozlukOrganizasyon_IsimdenSonra, false);
                    while ((sozluk = oku.ReadLine()) != null)
                    {
                        sozluk_Organizasyon_IsimdenSonra.Add(sozluk);
                    }
                    i = 0;
                    oku.Close();
                    //---------------------------------------------------------
                    oku = new StreamReader(dosya_SozlukOrganizasyon_IsminIcinde, false);
                    while ((sozluk = oku.ReadLine()) != null)
                    {
                        sozluk_Organizasyon_IsminIcinde.Add(sozluk);
                    }
                    i = 0;
                    oku.Close();
                    //---------------------------------------------------------
                    oku = new StreamReader(dosya_SozlukUnvan_IsimdenOnce, false);
                    while ((sozluk = oku.ReadLine()) != null)
                    {
                        sozluk_Unvan_IsimdenOnce.Add(sozluk);
                    }
                    i = 0;
                    oku.Close();
                    //---------------------------------------------------------
                    oku = new StreamReader(dosya_SozlukUnvan_IsimdenSonra, false);
                    while ((sozluk = oku.ReadLine()) != null)
                    {
                        sozluk_Unvan_IsimdenSonra.Add(sozluk);
                    }
                    i = 0;
                    oku.Close();
                    //----------------------------------------------------------
                    oku = new StreamReader(dosya_SozlukYer_IsimdenOnce, false);
                    while ((sozluk = oku.ReadLine()) != null)
                    {
                        sozluk_Yer_IsimdenOnce.Add(sozluk);
                    }
                    i = 0;
                    oku.Close();
                    //----------------------------------------------------------
                    oku = new StreamReader(dosya_SozlukYer_IsminIcinde, false);
                    while ((sozluk = oku.ReadLine()) != null)
                    {
                        sozluk_Yer_IsminIcinde.Add(sozluk);
                    }
                    i = 0;
                    oku.Close();
                    //----------------------------------------------------------
                    oku = new StreamReader(dosya_SozlukYer_IsimdenSonra, false);
                    while ((sozluk = oku.ReadLine()) != null)
                    {
                        sozluk_Yer_IsimdenSonra.Add(sozluk);
                    }
                    i = 0;
                    oku.Close();
                    //----------------------------------------------------------
                    progRun++;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Sözlükler alınırken hata oluştu.\n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
