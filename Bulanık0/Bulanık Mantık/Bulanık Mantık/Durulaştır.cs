using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BulanıkMantık
{
    public class Durulaştır
    {
        //Durulaştırma için maksimum noktaları tutar.
        private double dhızmax;
        private double smax;
        private double detmax;
        private double dönsonuc;
        //Durulaştırma sonuçlarını içeren listeler.
        private List<string> sonuclistdön;
        private List<string> sonuclistsüre;
        private List<string> sonuclistdet;
        public Durulaştır()
        {

        }

        public double Dhızmax { get => dhızmax; set => dhızmax = value; }
        public double Smax { get => smax; set => smax = value; }
        public double Detmax { get => detmax; set => detmax = value; }
        public double Dönsonuc { get => dönsonuc; set => dönsonuc = value; }
        public List<string> Sonuclistdön { get => sonuclistdön; set => sonuclistdön = value; }
        public List<string> Sonuclistsüre { get => sonuclistsüre; set => sonuclistsüre = value; }
        public List<string> Sonuclistdet { get => sonuclistdet; set => sonuclistdet = value; }
        public List<string> Xicinmax { get => xicinmax; set => xicinmax = value; }
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double Islem { get => islem; set => islem = value; }

        //x1, x2: Durulaştırma işlemlerinde kullanılan değişkenler.
        public double X1 { get => x1; set => x1 = value; }
        public double X2 { get => x2; set => x2 = value; }

        //basx, bitx: Durulaştırma aralığını belirleyen değişkenler.
        public double Basx { get => basx; set => basx = value; }
        public double Bitx { get => bitx; set => bitx = value; }
        public List<double> Basbıt { get => basbıt; set => basbıt = value; }//Durulaştırma aralıklarını tutan listeler.
        public List<string> Xlist { get => xlist; set => xlist = value; }//Durulaştırma işlemlerinin sonuçlarını tutan listeler.

        //gercek: Durulaştırma sonuçlarını temsil eden gerçek değerlerin listesi.
        public List<string> Gercek { get => gercek; set => gercek = value; }
       

        private double a;
        private double b;
        private double islem;
        //Bu metod, iki sayının arasındaki orta noktayı hesaplar. Bu değer, durulaştırma için maksimum noktaları belirlemek için kullanılır.
        public double maxbul(double a, double b)//Durulaştırma max noktalarını Hesaplama
        {
            A = a; //a ve b parametreleri, maksimum noktalar arasındaki iki sınır değeri temsil eder.
            B = b;

            Islem = (A + B) / 2;
            return Islem;
        }
        private double x1, x2;
        private double basx;
        private double bitx;
        private List<double> basbıt;
        private List<string> xlist;
        
        //Bu metod, üçgen ve yamuk şeklindeki bulanık kümelerin x değerlerini hesaplar ve bu değerleri bir listeye ekler.
        public void xbulucgen(double y,double ilk,double orta,double son,string sekil)
        {

            //Bu işlem, y değeri için üçgen üyelik fonksiyonunun X değerini ve y değerini içeren bir çift oluşturur.

            Basx = ilk;
            Bitx = son;
            Basbıt.Add(Basx);
            Basbıt.Add(Bitx);
            if(sekil == "yamuk")
            {
                X1 = (y - 1) * (orta - ilk) + orta;
                X2 = (1-y) * (orta - son) + son;
            }
            
            else if(sekil=="ucgen")
            {
                X1 = (y - 1) * (orta - ilk) + orta;
                X2 = (y - 1) * (orta - son) + orta;
            }
           
            Xlist.Add(X1.ToString() + " " + y);
            Xlist.Add(X2.ToString() + " " + y);
        }
        public void xbulyamuk(double y, double ilk, double orta, double son, string sekil)
        {

            Basx = ilk;
            Bitx = son;
            Basbıt.Add(Basx);
            Basbıt.Add(Bitx);


            //Eğer sekil "sol" ise:
            //X1, üyelik derecesinin y değeriyle(örneğin, 0.5) belirlenen bir eğiklikle hesaplanır
            //    ve Xlist listesine eklenir. Bu hesaplama, belirli bir y değeri için sol kenarın x değerini verir.
            if (sekil == "sol")
            {
                
                X1 = (y - 1) * (orta - ilk) + orta;
                Xlist.Add(X1.ToString() + " " + y);
            }

//            Eğer sekil "sag" ise:
//            Hesaplama işlemi sağdan sola yapılır, yani x değerleri sağ kenara doğru eğilir.
//X1 yine üyelik derecesinin y değeriyle(örneğin, 0.5) belirlenen bir eğiklikle hesaplanır ve Xlist listesine eklenir. Bu, sağ kenarın x değerini verir.

            else if (sekil == "sag")
            {
                
                X1 = (y-1)*(orta - son) +orta;
                Xlist.Add(X1.ToString() + " " + y);
            }
          
            

        }
        private List<string> gercek;
        public void Dönüshızıcentroid(List<string> list)
        {
            
            Xlist = new List<string>();
            Basbıt = new List<double>();
            Gercek = new List<string>();
            Xlist.Clear();
            Basbıt.Clear();
            Gercek.Clear();
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 0.514)
                {
                    xbulyamuk(Convert.ToDouble(list[i].ToString().Split(' ')[0]),0,0.5, 1.5, "sag");

                   // Eğer y değeri 0.514 ise, sağa doğru yamuk bir üyelik fonksiyonu oluşturulur.
                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 2.75)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]),0.5, 2.75, 5,"yamuk");
                    
                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 5)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 2.75, 5, 7.25,"ucgen");
                    
                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 7.25)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 5, 7.25, 9.5,"ucgen");
                    
                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 9.5)
                {

                    xbulyamuk(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 8.5, 9.5, 10, "sol");
                }
               
            }
            
            Gercek.Add(Basbıt[0].ToString()+" "+"0");
            for (int i = 0; i < Xlist.Count; i++)
            {
                Gercek.Add(Xlist[i]);
            }
            //Bu işlem sonunda, Gercek listesi, başlangıç, X değerleri ve bitiş değerlerini içeren bir üyelik fonksiyonunu temsil eder.
            Gercek.Add(Basbıt[Basbıt.Count-1].ToString() + " " + "0");
            
            
        }
        public void Sürecentroid(List<string> list)
        {

            Xlist = new List<string>();
            Basbıt = new List<double>();
            Gercek = new List<string>();
            Xlist.Clear();
            Basbıt.Clear();
            Gercek.Clear();
           
            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 22.3)
                {
                    xbulyamuk(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 0, 22.3, 39.9, "sag");


                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 39.9)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 22.3, 39.9, 57.5, "yamuk");

                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 57.5)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 39.9, 57.5, 75.1, "ucgen");

                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 75.1)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 57.5, 75.1, 92.7, "ucgen");

                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 92.7)
                {

                    xbulyamuk(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 75, 92.7, 100, "sol");
                }

            }

            Gercek.Add(Basbıt[0].ToString() + " " + "0");
            for (int i = 0; i < Xlist.Count; i++)
            {
                Gercek.Add(Xlist[i]);
            }
            Gercek.Add(Basbıt[Basbıt.Count - 1].ToString() + " " + "0");
            

        }
        public void Deterjancentroid(List<string> list)
        {

            Xlist = new List<string>();
            Basbıt = new List<double>();
            Gercek = new List<string>();
            Xlist.Clear();
            Basbıt.Clear();
            Gercek.Clear();
            
            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 20)
                {
                    xbulyamuk(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 0, 20, 85, "sag");


                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 85)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 20, 85, 150, "yamuk");

                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 150)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 85, 150, 215, "ucgen");

                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 215)
                {
                    xbulucgen(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 150, 215, 280, "ucgen");

                }
                else if (Convert.ToDouble(list[i].ToString().Split(' ')[1]) == 280)
                {

                    xbulyamuk(Convert.ToDouble(list[i].ToString().Split(' ')[0]), 215, 280, 300, "sol");
                }

            }

            Gercek.Add(Basbıt[0].ToString() + " " + "0");
            for (int i = 0; i < Xlist.Count; i++)
            {
                Gercek.Add(Xlist[i]);
            }
            Gercek.Add(Basbıt[Basbıt.Count - 1].ToString() + " " + "0");


        }
        public double centroidhesap(List<string> l)
        {
            double pay = 0;
            double payda = 0;
            
            for (int i = 0; i < l.Count; i++)
            {
               
              
                for (int j = i+1; j < l.Count; j++)
                {
                   // Eğer iki elemanın y değerleri(split edildikten sonra indeks 1) eşitse, bu durumda iki üyelik fonksiyonunun kesiştiği veya yamuk birleşme noktası olduğu anlaşılır. Bu durumda alan hesaplanır ve ağırlık merkezi bulunur.
                    double x1, x2;
                    if (l[i].Split(' ')[1]==l[j].Split(' ')[1])// Y değerleri eşitse
                    {
                        double y;
                        y = Convert.ToDouble(l[i].Split(' ')[1]);
                        x1= Convert.ToDouble(l[i].Split(' ')[0]);
                        x2 = Convert.ToDouble(l[j].Split(' ')[0]);
                        pay += (y * x2 * x2 / 2) - (y * x1 * x1 / 2);
                        payda += (y * x2) - (y * x1);
                        
                      
                        break;
                       
                    }
                    else//Bu durumda, iki üyelik fonksiyonunun yamuk birleşme ya da kesişme noktası vardır. Bu durumda, alan hesaplanır ve yine ağırlık merkezi pay paydasına bölünerek bulunur.
                    {
                        double y1, y2;
                        y1= Convert.ToDouble(l[i].Split(' ')[1]);
                        y2= Convert.ToDouble(l[j].Split(' ')[1]);
                        x1 = Convert.ToDouble(l[i].Split(' ')[0]);
                        x2 = Convert.ToDouble(l[j].Split(' ')[0]);
                        pay += ((((y1 - y2) / (x1 - x2)) * (((x2 * x2 * x2) / 3) -((x1 * x2 * x2) / 2)) + ((y1 * x2 * x2) / 2)) -
                              (((y1 - y2) / (x1 - x2)) * (((x1 * x1 * x1) / 3) -((x1 * x1 * x1) / 2)) + ((y1 * x1 * x1) / 2)));
                        payda+=((((y1 - y2) / (x1 - x2)) * (((x2 * x2) / 2) - (x1 * x2)) + (y1 * x2))-
                                (((y1 - y2) / (x1 - x2)) * (((x1 * x1) / 2) - (x1 * x1)) + (y1 * x1)));
                        
                       
                        break;
                    }
                    
                }


                
            }
            double centsonuc = pay/payda;
            
            return centsonuc;
        }
        public void Dönüshızı(string öge)//Dönüş Hızı Maksimum Nokta belirliyor 
        {
           
            if (öge == "Hassas")
            {
                Dhızmax = 0.514;
               
            }
            else if (öge == "Normal Hassas")
            {
                Dhızmax = maxbul(0.5, 5);
                
            }
            else if (öge == "Orta")
            {
                Dhızmax = maxbul(2.75, 7.25);
            }
            else if (öge == "Normal Güçlü")
            {
                Dhızmax = maxbul(5, 9.5);
            }
            else if (öge == "Güçlü")
            {
                Dhızmax = 9.5;
                
            }
        }
        public void Süre(string öge)//Süre Maksimum nokta belirliyor
        {

            if (öge == "Kısa")
            {
                Smax = 22.3;
            }
            else if (öge == "Normal Kısa")
            {
                Smax = maxbul(22.3, 57.5);
            }
            else if (öge == "Orta")
            {
                Smax = maxbul(39.9, 75.1);
            }
            else if (öge == "Normal Uzun")
            {
                Smax = maxbul(57.5, 92.7);
            }
            else if (öge == "Uzun")
            {
                Smax = 92.7;
            }
        }
        public void Deterjan(string öge)//Deterjan maksimum nokta belirliyor
        {

            if (öge == "Çok Az")
            {
                Detmax = 20;
            }
            else if (öge == "Az")
            {
                Detmax = maxbul(20, 150);
            }
            else if (öge == "Orta")
            {
                Detmax = maxbul(85, 215);
            }
            else if (öge == "Fazla")
            {
                Detmax = maxbul(150, 280);
            }
            else if (öge == "Çok Fazla")
            {
                Detmax = 280;
            }
        }
        private List<string> xicinmax;
        public double Hesapla(List<string> dizi)//Durulaştırmayı Hesaplıyor
        {
            Xicinmax = new List<string>();
            double pay = 0; ;
            double payda = 0;

            string[] arr = new string[dizi.Count];
            dizi.CopyTo(arr, 0);


            var arr2 = arr.Distinct();//Listedeki aynı olan değerleri atıyor

            dizi.Clear();
            foreach (string s in arr2)
            {

                dizi.Add(s);
            }

          
            for (int i = 0; i < dizi.Count; i++)//Listede kalanların içinden mandani değeri en büyük olan ve maksimum noktası aynı olanların içinden seçim yapıyor
            {
                for (int b = 0; b < dizi.Count; b++)
                {
                   
                    //Eğer aynı maksimum noktaya sahip başka bir eleman bulunursa, Mandani değeri büyük olan elemanı diziye eklemeye devam ediyor, diğerlerini kaldırıyor.

                    if (dizi[i].ToString().Split(' ')[1] == dizi[b].ToString().Split(' ')[1] &&
                    Convert.ToDouble(dizi[i].ToString().Split(' ')[0]) < Convert.ToDouble(dizi[b].ToString().Split(' ')[0]))
                    {

                        dizi.RemoveAt(i);


                    }
                    else if (dizi[i].ToString().Split(' ')[1] == dizi[b].ToString().Split(' ')[1] &&
                    Convert.ToDouble(dizi[i].ToString().Split(' ')[0]) > Convert.ToDouble(dizi[b].ToString().Split(' ')[0]))
                    {
                        dizi.RemoveAt(b);
                    }
                    else if (dizi[i].ToString().Split(' ')[1] != dizi[b].ToString().Split(' ')[1])
                    {
                        continue;
                    }
                }
            }
            for (int i = 0; i < dizi.Count; i++)//Sonuçları Hesaplama
            {

                pay += Convert.ToDouble(dizi[i].Split(' ')[0]) * Convert.ToDouble(dizi[i].Split(' ')[1]);// Her elemanın miktarı Mandani değeriyle çarpılıyor ve pay değişkenine ekleniyor
                payda += Convert.ToDouble(dizi[i].Split(' ')[0]);//Sadece miktarlar toplanıp payda değişkenine ekleniyor.
                Xicinmax.Add(dizi[i]);
            }
            
            Dönsonuc = pay / payda;
            return Dönsonuc;

        }
        
        public void durula(List<double> l1, List<string> l2, List<string> l3, List<string> l4)
        {
            Sonuclistdön = new List<string>();
            Sonuclistsüre = new List<string>();
            Sonuclistdet = new List<string>();
            for (int i = 0; i < l1.Count; i++)
            {
                string dön = l2[i];
                Dönüshızı(dön);
                Sonuclistdön.Add(l1[i].ToString() + " " + dhızmax.ToString());

                dön = l3[i];
                Süre(dön);
                Sonuclistsüre.Add(l1[i].ToString() + " " + smax.ToString());

                dön = l4[i];
                Deterjan(dön);
                Sonuclistdet.Add(l1[i].ToString() + " " + detmax.ToString());

            }
        }
    }
   
}
