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
                            Boolean b = false;
                            int elso = 0;
                            int masodik = 0;
                            while (b != true)
                            {
                                Console.Write("Adja meg az első harcos sorszámát!: ");
                                elso = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Adja meg a második harcos sorszámát!: ");
                                masodik = Convert.ToInt32(Console.ReadLine());
                                if (elso > h.harcosok.Count || elso < 1 || masodik > h.harcosok.Count || masodik < 1)
                                {
                                    Console.WriteLine("Nem megfelelően választott sorszámot,próbálja újra!");
                                }
                                else
                                {
                                    b = true;
                                }
                            }
                            h.Megkuzd(h.harcosok[elso - 1], h.harcosok[masodik - 1]);
                            Console.WriteLine(s);
                            valasztas = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Melyik harcost kivánja gyógyítani?:");
                            b = false;
                            int gyogyitId = 0;
                            while (b != true) 
                            {
                                gyogyitId = Convert.ToInt32(Console.ReadLine());
                                if (gyogyitId < 1 || gyogyitId > h.harcosok.Count)
                                {
                                    Console.Write("Nem megfelelő sorszámot adott meg,próbálja újra!: ");
                                    gyogyitId = Convert.ToInt32(Console.ReadLine());

                                }
                                else 
                                {
                                    h.harcosok[gyogyitId - 1].setEletero(h.harcosok[gyogyitId - 1].MaxEletero);
                                    b = true;
                                }
                            }
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
