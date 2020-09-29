using System;
using System.Collections.Generic;

namespace HarcosProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Harcosok h = new Harcosok("harcosok 1.csv");
            Boolean l = false;
            int valasztas;
            String s = "Mit szeretne csinálni?\n1: Új harcos létrehozása || 2: Harcosok kilistázása || 3: Párbaj || 4: Gyógyítás || 99: Kilépés \n:";
            Console.WriteLine(s);
            valasztas = Convert.ToInt32(Console.ReadLine());
            do
            {

                if(valasztas == 1 || valasztas == 2 || valasztas == 3 || valasztas == 4 || valasztas == 99) 
                {
                    switch (valasztas) 
                    {
                        case 1:
                            h.harcosLetrehozas();
                            Console.WriteLine(s);
                            valasztas = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine(h);
                            Console.WriteLine(s);
                            valasztas = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.Write("Adja meg az első harcos sorszámát!: ");
                            int elso = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Adja meg a második harcos sorszámát!: ");
                            int masodik = Convert.ToInt32(Console.ReadLine());
                            h.Megkuzd(h.harcosok[elso], h.harcosok[masodik]);
                            Console.WriteLine(s);
                            valasztas = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Melyik harcost kivánja gyógyítani?:");
                            h.Gyogyul(h.harcosok[Convert.ToInt32(Console.ReadLine())]);
                            Console.WriteLine(s);
                            valasztas = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 99:
                            l = true;
                            break;
                    }
                }

            } while (l != true && valasztas != 99);
            
            
            Console.WriteLine(h);

            Console.ReadKey();
        }
    }
}
