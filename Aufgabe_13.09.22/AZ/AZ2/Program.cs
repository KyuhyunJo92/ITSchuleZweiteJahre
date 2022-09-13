using System;

namespace A1
{
    class Program
    {
        static void Main(string[] args)
        {
            //zweimalBisTousand();
            LeibnizSchleifer(1000);
        }
        static void zweimalBisTousand()
        {
            
            int ergebnis = 1;
            while(ergebnis < 1000)
            {
                ergebnis += ergebnis * 2;
                Console.WriteLine(ergebnis);
            }
        }
        static void LeibnizSchleifer(int wieVielMal)
        {
            double ergebnis = 0.0d;
            int nenner = 0;
            for (int n = 0; n<=wieVielMal; n++)
            {
                nenner = 1 + n * 2;
                if (n % 2 == 0)
                {
                    //+
                    ergebnis += 1/Convert.ToDouble(nenner);
                }
                else
                {
                    ergebnis -= 1/Convert.ToDouble(nenner);
                    //-
                }
            }
            ergebnis = ergebnis * 4;
            Console.WriteLine(ergebnis);
        }
    }
}
