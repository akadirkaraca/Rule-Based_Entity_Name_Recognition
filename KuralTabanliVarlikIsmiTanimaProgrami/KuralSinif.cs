using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    class KuralSinif : TemelSinif
    {
        //SozlukSinif sozlukKural = new SozlukSinif();

        public int KuralKontrolEt(string s, int index)
        {
            int isaretlenecekSozcukSayisi = 0;
            int i = 0, j = 0;

            //AnahtarBagimsizKurallar(s, index);
            //-------------------------------------------------------------------------------------------------(OK)
            try
            {
                foreach (string sozluk in SozlukSinif.sozluk_Organizasyon_IsimdenSonra)
                {
                    if (s.Contains(sozluk))
                    {
                        for (j = 1; j <= 4 && index - j >= 0; j++)
                        {
                            //Aşağıda anahtar kelimeden önceki ismin büyük harfle başladığı ve virgülle ayrılmadığı kontrol edilir.
                            if (metinDiziIsaretliMi[index - j])
                            {
                                IsaretKaldir(index - j);

                                if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDizi[index - j].EndsWith(",") && !metinDizi[index - j].EndsWith("."))
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                //Kurum isimleri "ve" bağlacıyla bağlanıyorsa işaretlemeye dahil olur."Bilgi ve Teknoloji Kurumu" gibi vb.
                                //(Kurum İsimleri 6.Kural)
                                else if (metinDizi[index - j] == "ve" && BasHarfKontrolEt(metinDizi[index - (j + 1)]))
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                else if (metinDizi[index - j].EndsWith(","))
                                    break;
                            }
                            else
                            {
                                if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDizi[index - j].EndsWith(",") && !metinDizi[index - j].EndsWith("."))
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                //Kurum isimleri "ve" bağlacıyla bağlanıyorsa işaretlemeye dahil olur."Bilgi ve Teknoloji Kurumu" gibi vb.
                                //(Kurum İsimleri 6.Kural)
                                else if (metinDizi[index - j] == "ve" && BasHarfKontrolEt(metinDizi[index - (j + 1)]))
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                else if (metinDizi[index - j].EndsWith(","))
                                    break;
                            }
                        }
                        BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                        return 0;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Organizasyondan sonraki anahtar kelimeler taranırken hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //---------------------------------------------------------------------(OK)
            //(Kurum İsimleri 2.Kural)
            try
            {
                foreach (string sozluk in SozlukSinif.sozluk_Organizasyon_IsminIcinde)
                {
                    if (s.Contains(sozluk) && BasHarfKontrolEt(s))
                    {
                        Isaretle(index);
                        return 0;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Organizasyonun içindeki anahtar kelimeler taranırken hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //------------------------------------------------------------------------------------------------------------------(OK)
            /*foreach (string sozluk in SozlukSinif.sozluk_Unvan_IsimdenOnce)
            {
                if (s.Contains(sozluk))
                {
                    for (j = 1; j <= 4 && index + j < metinDizi.Length; j++)
                    {
                        //dizideki bir sonraki string degeri kontrol ederken noktalama işaretlerini kontrol et.(Kişi İsmi 5.Kural)
                        if (BasHarfKontrolEt(metinDizi[index + j]) && !metinDizi[index + j - 1].EndsWith(",") && !metinDizi[index + j - 1].EndsWith("."))
                        {
                            Isaretle(index + j);
                            continue;
                        }
                        //İsimden sonra ismi virgülle bağlanan ismi işaretlemek için.(Kişi İsmi 8.Kural)
                        else if (BasHarfKontrolEt(metinDizi[index + j]) && BasHarfKontrolEt(metinDizi[index + j - 1]) && metinDizi[index + j - 1].EndsWith(","))
                        {
                            Isaretle(index + j);
                            continue;
                        }
                        //Aşağıdaki else if kontrolu ünvandan sonra gelen isim "ve" bağlacı ile başka bir isme bağlanıyorsa bütün
                        //döngüden bağımsız bir şekilde isim olarak işaretlenir.(Kişi ismi 7.Kural)
                        else if (metinDizi[index + j] == "ve" && BasHarfKontrolEt(metinDizi[index + j + 1]))
                        {
                            Isaretle(index + j + 1);
                            continue;
                        }
                        else if (!BasHarfKontrolEt(metinDizi[index + j]) && metinDizi[index + j] != "ve")
                            break;
                        else if (BasHarfKontrolEt(metinDizi[index + j]))
                        {
                            Isaretle(index + j);
                            continue;
                        }
                    }
                    return 0;
                }
            }*/
            //--------------------------------------------------------------------------------------------------------------------(OK)
            /*Üstteki foreach döngüsü ile aynı işi yani isimden önceki unvan anahtar kelimelerini arayıp işaretleme yapıyor. 
            Fakat bu for döngüsü ile yazılan blokta mesela "Teknik Direktör Fatih Terim" gibi bir anahtar bulunan kelimenin 
            kontrolü yapılarak "Teknik <isim>Direktör</isim> <isim>Fatih</isim> <isim>Terim</isim>" şeklinde işaretlenmesinin
            önüne geçilerek "Teknik Direktör <isim>Fatih</isim> <isim>Terim</isim>" olarak doğru bir şekilde işaretlenmesi sağlanıyor.*/
            try
            {
                for (i = 0; i < SozlukSinif.sozluk_Unvan_IsimdenOnce.Count; i++)
                {
                    if (metinDizi[index].Contains(SozlukSinif.sozluk_Unvan_IsimdenOnce[i].ToString()))
                    {
                        //Bu if bloğu "Teknik Direktör" gibi bir anahtar kelime ile karşılaşılırsa "Direktör" anahtarından sonraki sözcükleri kontrol eder. 
                        if (metinDizi[index + 1].Contains(SozlukSinif.sozluk_Unvan_IsimdenOnce[i + 1].ToString()))
                        {
                            KuralKontrolEt(metinDizi[index + 1], index + 1);
                        }
                        else
                        {
                            for (j = 1; j <= 4 && index + j < metinDizi.Length; j++)
                            {
                                //dizideki bir sonraki string degeri kontrol ederken noktalama işaretlerini kontrol et.(Kişi İsmi 5.Kural)
                                if (BasHarfKontrolEt(metinDizi[index + j]) && !metinDizi[index + j - 1].EndsWith(",") && !metinDizi[index + j - 1].EndsWith("."))
                                {
                                    Isaretle(index + j);
                                    continue;
                                }
                                //İsimden sonra ismi virgülle bağlanan ismi işaretlemek için.(Kişi İsmi 8.Kural)
                                else if (BasHarfKontrolEt(metinDizi[index + j]) && BasHarfKontrolEt(metinDizi[index + j - 1]) && metinDizi[index + j - 1].EndsWith(","))
                                {
                                    Isaretle(index + j);
                                    continue;
                                }
                                //Aşağıdaki else if kontrolu ünvandan sonra gelen isim "ve" bağlacı ile başka bir isme bağlanıyorsa 
                                //isim olarak işaretlenir.(Kişi ismi 7.Kural)
                                else if (metinDizi[index + j] == "ve" && BasHarfKontrolEt(metinDizi[index + j + 1]))
                                {
                                    Isaretle(index + j + 1);
                                    continue;
                                }
                                else if (!BasHarfKontrolEt(metinDizi[index + j]) && metinDizi[index + j] != "ve")
                                    break;
                                else if (BasHarfKontrolEt(metinDizi[index + j]))
                                {
                                    Isaretle(index + j);
                                    continue;
                                }
                            }
                        }
                        return 0;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İsimden önceki anahtar kelimeler taranırken hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //-------------------------------------------------------------------(OK)
            try
            {
                foreach (string sozluk in SozlukSinif.sozluk_Unvan_IsimdenSonra)
                {
                    int veIndex = 0;//Eğer "ve" ile ilgili kural ile karşılaşırsak bizim ilgilendiğimiz "ve" nin orijinal indexsini tutmak için.
                    if (s.Contains(sozluk))
                    {
                        for (j = 1; j <= 4 && index - j >= 0; j++)
                        {
                            if (metinDiziIsaretliMi[index - j])
                            {
                                IsaretKaldir(index - j);
                                if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDiziIsaretliMi[index - j])
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                else if (metinDiziIsaretliMi[index - j] && BasHarfKontrolEt(metinDizi[index - j]))
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                else if (!BasHarfKontrolEt(metinDizi[index - j]) && metinDizi[index - j] == "ve" && BasHarfKontrolEt(metinDizi[index - (j + 1)]))
                                {
                                    veIndex = index - j;
                                    if (index - j == veIndex)//Burda "Ali ve Mehmet ve Veli Paşa" gibi bir durumda "Veli"den önceki ve ile ilgilendiğimiz için kontrol ediyoruz. 
                                    {
                                        BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                                        isaretlenecekSozcukSayisi = 0;
                                        index -= (j + 1);
                                        j = 0;
                                        continue;
                                    }
                                    else
                                    {
                                        isaretlenecekSozcukSayisi++;
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDiziIsaretliMi[index - j])
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                else if (metinDiziIsaretliMi[index - j] && BasHarfKontrolEt(metinDizi[index - j]))
                                {
                                    isaretlenecekSozcukSayisi++;
                                    continue;
                                }
                                else if (!BasHarfKontrolEt(metinDizi[index - j]) && metinDizi[index - j] == "ve" && BasHarfKontrolEt(metinDizi[index - (j + 1)]))
                                {
                                    veIndex = index - j;
                                    if (index - j == veIndex)//Burda "Ali ve Mehmet ve Veli Paşa" gibi bir durumda "Veli"den önceki ve ile ilgilendiğimiz için kontrol ediyoruz. 
                                    {
                                        BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                                        isaretlenecekSozcukSayisi = 0;
                                        index -= (j + 1);
                                        j = 0;
                                        continue;
                                    }
                                    else
                                    {
                                        isaretlenecekSozcukSayisi++;
                                        continue;
                                    }
                                }
                            }
                        }
                        BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                        return 0;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İsimden sonraki anahtar kelimeler taranırken hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //----------------------------------------------------------------------------------------------
            //(Yer İsimleri İsimden Önce Olan Kurallar)
            try
            {
                foreach (string sozluk in SozlukSinif.sozluk_Yer_IsimdenOnce)
                {
                    if (s.Contains(sozluk))
                    {
                        for (j = 1; j <= 4 && index + j < metinDizi.Length; j++)
                        {
                            if (BasHarfKontrolEt(metinDizi[index + j]) && !metinDiziIsaretliMi[index + j] && index + j < metinDizi.Length && !metinDizi[index + j].EndsWith(","))
                            {
                                isaretlenecekSozcukSayisi++;
                                continue;
                            }
                            else if (BasHarfKontrolEt(metinDizi[index + j]) && metinDizi[index + j].EndsWith(",") && BasHarfKontrolEt(metinDizi[index + (j + 1)]))
                            {
                                isaretlenecekSozcukSayisi++;
                                continue;
                            }
                            else if (metinDizi[index + j] == "ve" && BasHarfKontrolEt(metinDizi[index + (j + 1)]) && index + (j + 1) < metinDizi.Length)
                            {
                                isaretlenecekSozcukSayisi++;
                                continue;
                            }
                            else if (BasHarfKontrolEt(metinDizi[index + j]) && metinDizi[index + j].EndsWith(","))
                            {
                                isaretlenecekSozcukSayisi++;
                                break;
                            }
                        }

                        if (BasHarfKontrolEt(s))
                            BirlestirIsaretle(index, isaretlenecekSozcukSayisi);
                        else if (!BasHarfKontrolEt(s))
                            BirlestirIsaretle(index + 1, isaretlenecekSozcukSayisi - 1);
                        return 0;
                    }
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Yer anahtarı isimden önce olan kelimeler taranırken hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //-------------------------------------------------------------------
            //Sozluk yer ismin içinde olan kurallar
            try
            {
                foreach (string sozluk in SozlukSinif.sozluk_Yer_IsminIcinde)
                {
                    if (s.Contains(sozluk) && BasHarfKontrolEt(s))
                    {
                        Isaretle(index);
                        return 0;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Yer anahtar sözlüğü ismin içindeki kelimeler taranırken hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //-------------------------------------------------------------------
            bool ciftAnahtar = false;
            for (i = 0; i < SozlukSinif.sozluk_Yer_IsimdenSonra.Count; i++)
            {
                if (metinDizi[index].Contains(SozlukSinif.sozluk_Yer_IsimdenSonra[i].ToString()))
                {
                    //Bu if bloğu "Kültür Merkezi" gibi bir anahtar kelime ile karşılaşılırsa "Merkezi" anahtarından sonraki sözcükleri kontrol eder. 
                    //if (index + 1 < metinDizi.Length && metinDizi[index + 1].Contains(SozlukSinif.sozluk_Yer_IsimdenSonra[i + 1].ToString()))
                    //{
                    //    ciftAnahtar = true;
                    //}

                    if (metinDizi[index].Contains(SozlukSinif.sozluk_Yer_IsimdenSonra[i].ToString()))
                    {
                        for (j = 1; j <= 4 && index - j >= 0; j++)
                        {
                            if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDiziIsaretliMi[index])
                            {
                                isaretlenecekSozcukSayisi++;
                                continue;
                            }
                            else if (BasHarfKontrolEt(metinDizi[index - j]) && metinDiziIsaretliMi[index])
                            {
                                IsaretKaldir(index);
                                isaretlenecekSozcukSayisi++;
                            }
                        }

                        if (ciftAnahtar)
                        {
                            BirlestirIsaretle(index -isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi+1);
                        }
                        else BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                    }
                    return 0;
                }
            }
            //----------------------------------------------------------------------------------------------
            AnahtarBagimsizKurallar(metinDizi[index], index);

            return 0;
        }
        //------------------------------------------------------------------------------------------

        public int AnahtarBagimsizKurallar(string s, int index)
        {
            int isaretlenecekSozcukSayisi = 0;
            //Hepsi büyük harf olan sözcükler kısaltma kabul edilir ve isim olarak etiketlenir.(Kurum İsimleri 3.Kural)
            try
            {
                if (BasHarfKontrolEt(metinDizi[index]))
                {
                    string[] tempSozcukDizi;
                    string tempSozcuk;
                    if (s.Contains("'"))
                    {
                        tempSozcukDizi = s.Split('\'');
                        tempSozcuk = tempSozcukDizi[0];

                        if (string.Compare(tempSozcuk, tempSozcuk.ToUpper(), false) == 0)
                        {
                            Isaretle(index);
                            metinDiziIsaretliMi[index] = true;
                            return 0;
                        }
                    }
                    else
                    {
                        if (string.Compare(s, s.ToUpper(), false) == 0 && metinDizi[index].Length > 1)
                        {
                            Isaretle(index);
                            metinDiziIsaretliMi[index] = true;
                            return 0;
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kısaltma kontrolünde bir hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Tırnak ile alakalı kurallar.
            try
            {
                if (BasHarfKontrolEt(s) && s.Contains("'"))
                {
                    for (int i = 1; i <= 3 && index - i >= 0; i++)
                    {
                        if (BasHarfKontrolEt(metinDizi[index - i]) && !metinDizi[index - i].EndsWith(".") && !metinDizi[index - i].EndsWith(","))
                        {
                            isaretlenecekSozcukSayisi++;
                        }
                        else if (BasHarfKontrolEt(metinDizi[index - i]) && !metinDizi[index - i].EndsWith(".") && !metinDizi[index - i].EndsWith(","))
                        {
                            isaretlenecekSozcukSayisi++;
                        }
                        else if (BasHarfKontrolEt(metinDizi[index]) && !BasHarfKontrolEt(metinDizi[index - 1]))
                        {
                            Isaretle(index);
                            return 0;
                        }
                    }
                    BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Tırnak ile ilgili kuralda bir hata oluştu." + hata.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //--------------------------------------------------------------------------------------------------------------------
            //Herhangi bir sözcük kelimenin ortasında büyük harfle başlıyor ve öncesi ve sonrası küçük harfliyse isim denebilir.
            try
            {
                if (BasHarfKontrolEt(metinDizi[index]) && index - 1 >= 0 && !metinDizi[index - 1].EndsWith(".") && !BasHarfKontrolEt(metinDizi[index - 1])
                    && index + 1 < metinDizi.Length && !BasHarfKontrolEt(metinDizi[index + 1]))
                {
                    Isaretle(index);
                    return 0;
                }
            }
            catch
            {
            }

            try
            {
                if (BasHarfKontrolEt(s) && s.Contains("-"))
                {
                    Isaretle(index);
                    return 0;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Tire ile ilgili kuralda bir hata oluştu." + hata.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0;
        }
        //---------------------------------------------------------------------------------------------------
        //char[] noktalama = { Convert.ToChar(' '), Convert.ToChar('+'), Convert.ToChar('-'), Convert.ToChar('%'), Convert.ToChar('&'),Convert.ToChar('?'),
        //                           Convert.ToChar('!')};
        public bool BasHarfKontrolEt(string s)
        {

            string temiz_s = Regex.Replace(s, @"[^\w\s]", "");
            if (Char.IsUpper(temiz_s[0]))
                return true;
            else return false;
        }
        //----------------------------------------------------------------------------------------------------
        public void BirlestirIsaretle(int index, int isaretlenecekSozcukSayisi)
        {
            //burayada işaretle kısmındaki kısıtlamaları ekle
            metinDizi[index] = ilkIsaret + metinDizi[index].ToString();
            metinDizi[index + (isaretlenecekSozcukSayisi)] = metinDizi[index + (isaretlenecekSozcukSayisi)].ToString() + sonIsaret;

            for (int i = 0; i <= isaretlenecekSozcukSayisi; i++)
                metinDiziIsaretliMi[index + i] = true;
        }

        //public void BirlestirIsaretle(int index, int isaretlenecekSozcukSayisi, int indexOf)
        //{
        //    metinDizi[index] = ilkIsaret + metinDizi[index].ToString();
        //    metinDizi[index + (isaretlenecekSozcukSayisi)] = metinDizi[index + (isaretlenecekSozcukSayisi)].Substring(0, indexOf) + sonIsaret + metinDizi[index + (isaretlenecekSozcukSayisi)].Substring(indexOf, metinDizi[index + (isaretlenecekSozcukSayisi)].Length - indexOf);

        //    for (int i = 0; i <= isaretlenecekSozcukSayisi; i++)
        //        metinDiziIsaretliMi[index + i] = true;
        //}

        public void Isaretle(int index)
        {
            try
            {
                if (!(metinDizi[index].Contains('(') || metinDizi[index].Contains('-') || metinDizi[index].Contains("'") || metinDizi[index].Contains(')')))
                {
                    metinDizi[index] = ilkIsaret + metinDizi[index] + sonIsaret;
                }
                else
                {
                    string[] metinDiziSplit = new string[metinDizi[index].Length];
                    string isaretlenecekIsim = "";
                    bool tire = false;
                    bool tirnak = false;
                    int i = 0;
                    //
                    foreach (char chr in metinDizi[index])
                    {
                        switch (chr)
                        {
                            case '(':
                                metinDiziSplit[i++] = "(";
                                break;
                            case '\'':
                                metinDiziSplit[++i] = "'";
                                i++;
                                tirnak = true;
                                break;
                            case ')':
                                metinDiziSplit[++i] = ")";
                                i++;
                                break;
                            case '-':
                                metinDiziSplit[++i] = "-";
                                i++;
                                tire = true;
                                break;
                            default:
                                metinDiziSplit[i] += chr;
                                break;
                        }
                    }
                    //
                    isaretlenecekIsim = Regex.Replace(metinDizi[index], @"[^\w\s]", "");
                    if (tirnak)
                    {
                        string[] isaretlenecekIsimDizi = metinDizi[index].Split('\'');
                        isaretlenecekIsim = Regex.Replace(isaretlenecekIsimDizi[0], @"[^\w\s]", "");
                    }
                    else if (tire)
                    {
                        string[] isaretlenecekIsimDizi = metinDizi[index].Split('-');
                        isaretlenecekIsim = Regex.Replace(isaretlenecekIsimDizi[0], @"[^\w\s]", "");
                    }
                    //
                    metinDizi[index] = "";
                    for (int k = 0; k < metinDiziSplit.Length; k++)
                    {
                        if (metinDiziSplit[k] != null && isaretlenecekIsim.Contains(metinDiziSplit[k]))
                            metinDizi[index] += ilkIsaret + metinDiziSplit[k];
                        else if (metinDiziSplit[k] != null && metinDiziSplit[k].Contains("-"))
                            metinDizi[index] += "-" + metinDiziSplit[++k] + sonIsaret;
                        else
                            metinDizi[index] += metinDiziSplit[k];
                    }
                }
                metinDiziIsaretliMi[index] = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşaretleme Fonksiyonunda bir hata oluştu./n" + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void Isaretle(int index, int indexOf)
        //{
        //    metinDizi[index] = ilkIsaret + metinDizi[index].Substring(0, indexOf) + sonIsaret + metinDizi[index].Substring(indexOf, metinDizi[index].Length - indexOf);
        //    metinDiziIsaretliMi[index] = true;
        //}

        public void IsaretKaldir(int index)
        {
            if (metinDiziIsaretliMi[index] || metinDizi[index].Contains(ilkIsaret) || metinDizi[index].Contains(sonIsaret))
            {
                metinDizi[index] = metinDiziOrijinal[index];
                metinDiziIsaretliMi[index] = false;
            }
        }
    }
}