using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class RSA
    {


    // Funkcja obliczająca NWD dla dwóch liczb
    //----------------------------------------
    int nwd(int a, int b)
    {
        int t;

        while (b != 0)
        {
            t = b;
            b = a % b;
            a = t;
        };
        return a;
    }

    // Funkcja obliczania odwrotności modulo n
    //----------------------------------------
    int odwr_mod(int a, int n)
    {
        int a0, n0, p0, p1, q, r, t;

        p0 = 0; p1 = 1; a0 = a; n0 = n;
        q = n0 / a0;
        r = n0 % a0;
        while (r > 0)
        {
            t = p0 - q * p1;
            if (t >= 0)
                t = t % n;
            else
                t = n - ((-t) % n);
            p0 = p1; p1 = t;
            n0 = a0; a0 = r;
            q = n0 / a0;
            r = n0 % a0;
        }
        return p1;
    }

    void klucze_RSA()
    {

        int p, q, phi, n, e, d;
            p = 11;
            q = 13;

        phi = (p - 1) * (q - 1);
        n = p * q;

        // wyznaczamy wykładniki e i d

        for (e = 3; nwd(e, phi) != 1; e += 2) ;
        d = odwr_mod(e, phi);

        // gotowe, wypisujemy klucze

        /*cout << "KLUCZ PUBLICZNY\n"
              "wykladnik e = " << e
       << "\n    modul n = " << n
       << "\n\nKLUCZ PRYWATNY\n"
              "wykladnik d = " << d << endl;
        czekaj();
        */
    }

    int pot_mod(int a, int w, int n)
    {
        int pot, wyn, q;

        // wykładnik w rozbieramy na sumę potęg 2
        // przy pomocy algorytmu Hornera. Dla reszt
        // niezerowych tworzymy iloczyn potęg a modulo n.

        pot = a; wyn = 1;
        for (q = w; q > 0; q /= 2)
        {
            if (q % 2) wyn = (wyn * pot) % n;
            pot = (pot * pot) % n; // kolejna potęga
        }
        return wyn;
    }







    }
}
