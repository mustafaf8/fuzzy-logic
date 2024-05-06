using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulanıkMantık
{
    public class Kural
    {
        private List<string> l;
        public List<string> L { get => l; set => l = value; }

        public void DosyadanOku()
        {
            L = new List<string>();
            StreamReader dosya = new StreamReader(@"kural.txt", Encoding.Default);

            string veri;

            int i;
            for(i = 0; (veri = dosya.ReadLine()) != null; i++)
            {
                 L.Add(veri);
            }
        }
    }
}
