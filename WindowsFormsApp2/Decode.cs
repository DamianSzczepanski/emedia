using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{

    public class Decode
    {
        public int dlugosc, precyzja, wysokosc, szerokosc;


        public void Dekoduj_Wlasnosci(byte[] Obrazek)
        {
            for (int i = 0; i < Obrazek.Length; i++)
            {
                if (Obrazek[i] == 0xff && Obrazek[i + 1] == 0xc0)
                {
                    Console.WriteLine("Wykryto Znacznik S0F0");
                    dlugosc = (Obrazek[i + 2]) * 256 + Obrazek[i + 3];
                    precyzja = (Obrazek[i + 4]);
                    wysokosc = (Obrazek[i + 5] * 256 + Obrazek[i + 6]);
                    szerokosc = (Obrazek[i + 7] * 256 + Obrazek[i + 8]);
                }
                else if (Obrazek[i] == 0xff && Obrazek[i + 1] == 0xd8)
                {
                    Console.WriteLine("Wykryto Plik jpg, rozpoczynam dekodowanie");
                }
            }
        }

        public double[] Dekodujplik(byte[] Obrazek)
        {
            double[] obrazek1;
            obrazek1 = new double[Obrazek.Length];
            for (int i = 0; i < Obrazek.Length; i++)
            {
                obrazek1[i] = (double)Obrazek[i];
                //Console.WriteLine(obrazek1[i]);
            }
            return obrazek1;
        }




    }
}
