using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulanıkMantık
{
    public class Bulanık
    {
        Kural k;
        public Bulanık()
        {
            k = new Kural();
        }
      
        //listeler tanımlanıyor
       private List<string> hbulanık;
       private List<string> mbulanık;
       private List<string> kbulanık;
        private List<string> mandani;
        private List<string> duruladhız;
        private List<string> durulasüre;
        private List<string> duruladet;
        //değişkenler tanımlanıyor
        private string hass;
        private string mikk;
        private string kirr;
        private double hassaslık;
        private double miktar;
        private double kirlilik;


        //Mandani değerler, durulma hızı, süresi ve deterjan miktarını içeren listeler için özellikler tanımlanıyor.
        public List<string> Hbulanık { get => hbulanık; set => hbulanık = value; }
        public List<string> Mbulanık { get => mbulanık; set => mbulanık = value; }
        public List<string> Kbulanık { get => kbulanık; set => kbulanık = value; }
        public List<string> Mandani { get => mandani; set => mandani = value; }
        public List<string> Duruladhız { get => duruladhız; set => duruladhız = value; }
        public List<string> Durulasüre { get => durulasüre; set => durulasüre = value; }
        public List<string> Duruladet { get => duruladet; set => duruladet = value; }
        //Hassaslık, miktar ve kirlilik değerleri için özellikler tanımlanıyor.
        public string Hass { get => hass; set => hass = value; }
        public string Mikk { get => mikk; set => mikk = value; }
        public string Kirr { get => kirr; set => kirr = value; }
        public double Hassaslık { get => hassaslık; set => hassaslık = value; }
        public double Miktar { get => miktar; set => miktar = value; }
        public double Kirlilik { get => kirlilik; set => kirlilik = value; }
        public double Hmandani { get => hmandani; set => hmandani = value; }
        public double Mmandani { get => mmandani; set => mmandani = value; }
        public double Kmandani { get => kmandani; set => kmandani = value; }
        //Mandani değerler listesi, temizlik sonuçları listesi ve renklendirme listesi için özellikler tanımlanıyor.
        public List<double> Listmandani { get => listmandani; set => listmandani = value; }
        public List<double> Listem { get => listem; set => listem = value; }
        public List<int> Renklendir { get => renklendir; set => renklendir = value; }
        //kurucu metot sınıfın başlatılması için çağrılır
        public Bulanık(double hassaslık, double miktar, double kirlilik)
        {
            this.hassaslık = hassaslık;
            this.miktar = miktar;
            this.kirlilik = kirlilik;
            
        }
        
        public void bulanık(double has, double mik, double kir)//Bulanık Aralığını Bulma
        {
        //Bu satırlarda, Hbulanık, Mbulanık ve Kbulanık adında yeni string listeleri oluşturuluyor.
        //Bu listeler, su hassaslık düzeyini, deterjan miktarını ve kirlilik derecesini belirleyen bulanık kategorileri tutacak

            Hbulanık = new List<string>();
            Mbulanık = new List<string>();
            Kbulanık = new List<string>();

            if ((has >= 0 && has <= 4))
            {
                //Bu örnek, su hassaslık seviyesinin "Sağlam" kategorisinde olduğu durumu kontrol eder.Eğer su hassaslık
                //seviyesi 0 ile 4 arasında ise, Hass isimli string değişkenine "Sağlam" kelimesini ekler ve aynı zamanda
                //Hbulanık listesine de "Sağlam"ı ekler.

               Hass += "Sağlam ";
               Hbulanık.Add("Sağlam");
            }
            if ((has >= 3 && has <= 7))
            {

                Hass += "Orta ";
                Hbulanık.Add("Orta");
            }
            if ((has >= 5.5 && has <= 10))
            {

                Hass += "Hassas ";
                Hbulanık.Add("Hassas");
            }
            if ((mik >= 0 && mik <= 4))
            {
                Mikk += "Küçük ";
                Mbulanık.Add("Küçük");
            }
            if ((mik >= 3 && mik <= 7))
            {

                Mikk += "Orta ";
                Mbulanık.Add("Orta");
            }
            if ((mik >= 5.5 && mik <= 10))
            {

                Mikk += "Büyük ";
                Mbulanık.Add("Büyük");
            }
            if ((kir >= 0 && kir <= 4.5))
            {
                Kirr+= "Küçük ";
                Kbulanık.Add("Küçük");
            }
            if ((kir >= 3 && kir <= 7))
            {

                Kirr += "Orta ";
                Kbulanık.Add("Orta");
            }
            if ((kir >= 5.5 && kir <= 10))
            {

                Kirr += "Büyük ";
                Kbulanık.Add("Büyük");
            }
           
        }
        private List<int> renklendir;
        public void datarenk(List<string> gelen, List<string> bulanık1, List<string> bulanık2, List<string> bulanık3)
        {
            //Bu kod parçası, metodun içinde kullanılan bazı listelerin oluşturulması ve temizlenmesini sağlar.Mandani, Duruladhız,
            //Durulasüre, Duruladet ve Renklendir isimli yeni boş listeler oluşturulur. Renklendir listesi temizlenir.

            Mandani = new List<string>();
            Duruladhız = new List<string>();
            Durulasüre = new List<string>();
            Duruladet = new List<string>();
            Renklendir = new List<int>();
            Renklendir.Clear();
            //Bu kısım, gelen listesindeki veriler üzerinde bir döngü başlatır. Daha sonra,
            //her bir bulanık küme listesi(bulanık1, bulanık2, bulanık3) içinde bir döngü başlatılır.
            //İç içe döngüler, her bir elemanın diğer listelerdeki tüm elemanlarla eşleştirilmesini sağlar.
            for (int i = 0; i < gelen.Count; i++)
            {
               
                for (int a = 0; a < bulanık1.Count; a++)
                {
                    for (int b = 0; b < bulanık2.Count; b++)
                    {
                        for (int c = 0; c < bulanık3.Count; c++)
                        {


                            //Bu koşul ifadesi, her bir bulanık küme elemanı(bulanık1[a], bulanık2[b], bulanık3[c]) ile
                            //    gelen listesinin her elemanını karşılaştırır.
                            //bulanık1[a].ToString() == gelen[i].ToString().Split('-')[1]: gelen[i] elemanının "-" karakterine göre bölünmüş parçalarından ikincisi([1]), bulanık1[a] elemanına eşit mi?
                            // bulanık2[b].ToString() == gelen[i].ToString().Split('-')[2]: gelen[i] elemanının "-" karakterine göre bölünmüş parçalarından üçüncüsü([2]), bulanık2[b] elemanına eşit mi?
                            //     bulanık3[c].ToString() == gelen[i].ToString().Split('-')[3]: gelen[i] elemanının "-" karakterine göre bölünmüş parçalarından dördüncüsü([3]), bulanık3[c] elemanına eşit mi ?
                            if (bulanık1[a].ToString() == gelen[i].ToString().Split('-')[1] && bulanık2[b].ToString() == gelen[i].ToString().Split('-')[2] && bulanık3[c].ToString() == gelen[i].ToString().Split('-')[3])
                            {
                                  //Mandani.Add(bulanık1[a] + " " + bulanık2[b] + " " + bulanık3[c]): Mandani listesine, uyumlu olan bulanık küme elemanlarının birleşimi eklenir.
                                  //Duruladhız.Add(gelen[i].ToString().Split('-')[4]): gelen[i] elemanının "-" karakterine göre bölünmüş parçalarından beşincisi([4]), Duruladhız listesine eklenir.
                                  //Durulasüre.Add(gelen[i].ToString().Split('-')[5]): gelen[i] elemanının "-" karakterine göre bölünmüş parçalarından altıncısı([5]), Durulasüre listesine eklenir.
                                  //Duruladet.Add(gelen[i].ToString().Split('-')[6]): gelen[i] elemanının "-" karakterine göre bölünmüş parçalarından yedincisi([6]), Duruladet listesine eklenir.
                                  //Renklendir.Add(i): Renklendir listesine, gelen listesindeki uyumlu olan elemanın indis numarası eklenir.
                                Mandani.Add(bulanık1[a] + " " + bulanık2[b] + " " + bulanık3[c]);
                                Duruladhız.Add(gelen[i].ToString().Split('-')[4]);
                                Durulasüre.Add(gelen[i].ToString().Split('-')[5]);
                                Duruladet.Add(gelen[i].ToString().Split('-')[6]);
                                Renklendir.Add(i);
                            }


                        }
                    }
                }
                
            }
        }

       private double hmandani;
       private double mmandani;
       private double kmandani;
        public void hamandani(string a)//Hassaslık Mandani Hesaplama

            //Bu fonksiyon, belirli bir hassaslık seviyesi için hassaslık mandani değerini hesaplar.
            //Parametre olarak gelen a değeri, hangi hassaslık seviyesinin hesaplanacağını belirtir.
        {
            if (a == "Sağlam")
            {
                if (Hassaslık >= 0 && Hassaslık <= 2)
                {
                    Hmandani = 1;
                }
                else if (Hassaslık > 2 && Hassaslık < 4)
                {
                    Hmandani = ((Hassaslık - 2) / (2 - 4)) + 1;
                }
                else if (Hassaslık == 4)
                {
                    Hmandani = 0;
                }

            }
            if (a == "Orta")
            {
                if (Hassaslık > 3 && Hassaslık < 5)
                {
                    Hmandani = ((hassaslık - 3) / (5 - 3));
                }
                else if (Hassaslık > 5 && Hassaslık < 7)
                {
                    Hmandani = ((Hassaslık - 5) / (5 - 7)) + 1;
                }
                else if (Hassaslık == 3 || Hassaslık == 7)
                {
                    Hmandani = 0;
                }
                else if (Hassaslık == 5)
                {
                    Hmandani = 1;
                }
            }
            if (a == "Hassas")
            {
                if (Hassaslık > 5.5 && Hassaslık < 8)
                {
                    Hmandani = ((Hassaslık - 5.5) / (8 - 5.5));

                }
                else if (Hassaslık >= 8 && Hassaslık <= 10)
                {
                    Hmandani = 1;
                }
                else if (Hassaslık == 5.5)
                {
                    Hmandani = 0;
                }
            }
        }
        public void mimandani(string a)//Miktar Mandani Hesaplma
        {
            if (a == "Küçük")
            {
                if (Miktar >= 0 && Miktar <= 2)
                {
                    Mmandani = 1;
                }
                else if (Miktar > 2 && Miktar < 4)
                {
                    Mmandani = ((Miktar - 2) / (2 - 4)) + 1;
                }
                else if (Miktar == 4)
                {
                    Mmandani = 0;
                }

            }
            if (a == "Orta")
            {
                if (Miktar > 3 && Miktar < 5)
                {
                    Mmandani = ((Miktar - 3) / (5 - 3));
                }
                else if (Miktar > 5 && Miktar < 7)
                {
                    Mmandani = ((Miktar - 5) / (5 - 7)) + 1;
                }
                else if (Miktar == 3 || Miktar == 7)
                {
                    Mmandani = 0;
                }
                else if (Miktar == 5)
                {
                    Mmandani = 1;
                }

            }
            if (a == "Büyük")
            {
                if (Miktar > 5.5 && Miktar < 8)
                {
                    Mmandani = ((Miktar - 5.5) / (8 - 5.5));

                }
                else if (Miktar >= 8 && Miktar <= 10)
                {
                    Mmandani = 1;
                }
                else if (Miktar == 5.5)
                {
                    Mmandani = 0;
                }
            }
        }
        public void kimandani(string a)//Kirlilik Mandani Hesaplama
        {
            if (a == "Küçük")
            {
                if (Kirlilik >= 0 && Kirlilik <= 2)
                {
                    Kmandani = 1;
                }
                else if (Kirlilik > 2 && Kirlilik < 4.5)
                {
                    Kmandani = ((Kirlilik - 2) / (2 - 4.5)) + 1;
                }
                else if (Kirlilik == 4.5)
                {
                    Mmandani = 0;
                }
            }
            if (a == "Orta")
            {
                if (Kirlilik > 3 && Kirlilik < 5)
                {
                    Kmandani = ((Kirlilik - 3) / (5 - 3));
                }
                else if (Kirlilik > 5 && Kirlilik < 7)
                {
                    Kmandani = ((Kirlilik - 5) / (5 - 7)) + 1;
                }
                else if (Kirlilik == 3 || Kirlilik == 7)
                {
                    Kmandani = 0;
                }
                else if (Kirlilik == 5)
                {
                    Kmandani = 1;
                }

            }
            if (a == "Büyük")
            {
                if (Kirlilik > 5.5 && Kirlilik < 8)
                {
                    Kmandani = ((Kirlilik - 5.5) / (8 - 5.5));

                }
                else if (Kirlilik >= 8 && Kirlilik <= 10)
                {
                    Kmandani = 1;
                }
                else if (Kirlilik == 5.5)
                {
                    Mmandani = 0;
                }

            }
        }
       private List<double> listmandani;
       private List<double> listem;
       public void mandanihesapla(List<string> gelen)
        {
            Listmandani = new List<double>();
            Listem = new List<double>();
            Listmandani.Clear();
            for (int i = 0; i < gelen.Count; i++)
            {
                //Her bir gelen veri için, hassaslık(hasmandani), miktar(mikmandani)
                //    ve kirlilik(kirmandani) üyelik dereceleri hesaplanır.

                string hasmandani = gelen[i].Split(' ')[0];
                string mikmandani = gelen[i].Split(' ')[1];
                string kirmandani = gelen[i].Split(' ')[2];

                //Bu satırlar, her bir veri seti için hassaslık(Hmandani), miktar(Mmandani)
                //ve kirlilik(Kmandani) üyelik derecelerini Listmandani listesine ekliyor.

                hamandani(hasmandani);
                mimandani(mikmandani);
                kimandani(kirmandani);

                Listmandani.Add(Hmandani);
                Listmandani.Add(Mmandani);
                Listmandani.Add(Kmandani);

                Listmandani.Sort();//Listmandani listesi sıralanır. Bu, en küçük üyelik derecesinin bulunmasına yardımcı olur.
                Listem.Add(Listmandani[0]);//En küçük üyelik derecesi (Listmandani[0]) Listem listesine eklenir.
                Listmandani.Clear();//Listmandani listesi temizlenir, böylece bir sonraki veri için üyelik dereceleri saklanır.
            }
        }

    }
}
