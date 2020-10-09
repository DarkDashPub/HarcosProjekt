using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HarcosProjekt
{
    class Harcosok
    {

        public List<Harcos> harcosok = new List<Harcos>();

        public Harcosok(String fajlnev) 
        {
            StreamReader sr = new StreamReader(fajlnev);
            try
            {

                while (!sr.EndOfStream) 
                {
                    String[] adatok = sr.ReadLine().Split(';');
                    Harcos h = new Harcos(adatok[0], Convert.ToInt32(adatok[1]));
                    harcosok.Add(h);
                }
                sr.Close();

            }
            catch (Exception x)
            {

                Console.WriteLine(x);
            }
        }
        public void Megkuzd(Harcos kihivo, Harcos kihivott)
        {
            Boolean l = false;
            while(l != true)
            {
                if (kihivo.Equals(kihivott))
                {
                    Console.WriteLine("A harcos nem támadhatja meg saját magát!");
                    l = true;
                }
                else if (kihivo.getEletero() <= 0 || kihivott.getEletero() <= 0)
                {
                    Console.WriteLine("A harc nem lehetséges,ugyanis az egyik harcos halott.");
                    l = true;
                }
                else 
                {
                    Console.WriteLine(kihivo.getNev() + " Megtámadta " + kihivott.getNev() + "-t és " + kihivo.Sebzes + "-val/vel sebezte!");
                    kihivott.setEletero(kihivott.getEletero() - kihivo.Sebzes);

                    if (kihivott.getEletero() > 0)
                    {
                        Console.WriteLine(kihivott.getNev() + " Megtámadta " + kihivo.getNev() + "-t és " + kihivott.Sebzes + "-val/vel sebezte!");
                        kihivo.setEletero(kihivo.getEletero() - kihivott.Sebzes);
                    }

                    else if (kihivott.getEletero() < 1)
                    {
                        Console.WriteLine(kihivo.getNev() + " Megölte " + kihivott.getNev() + "-t!");
                        Console.WriteLine(kihivo.getNev() + " 15 Tapasztalai pontott szerzett.");
                        kihivo.setTapasztalat(kihivo.getTapasztalat() + 15);
                        kihivo.setSzint(1);
                        kihivo.setTapasztalat(0);
                    }
                    else if (kihivo.getEletero() < 1)
                    {
                        Console.WriteLine(kihivott.getNev() + " Megölte " + kihivo.getNev() + "-t!");
                        Console.WriteLine(kihivott.getNev() + " 15 Tapasztalai pontott szerzett.");
                        kihivott.setTapasztalat(kihivott.getTapasztalat() + 15);
                        kihivo.setSzint(1);
                        kihivo.setTapasztalat(0);
                    }
                    else if (kihivo.getEletero() > 0 && kihivott.getEletero() > 0)
                    {
                        Console.WriteLine(kihivo.getNev() + " 5 Tapasztalai pontott szerzett.");
                        Console.WriteLine(kihivott.getNev() + " 5 Tapasztalai pontott szerzett.");
                        kihivo.setTapasztalat(kihivo.getTapasztalat() + 5);
                        kihivott.setTapasztalat(kihivott.getTapasztalat() + 5);
                    }
                }

                
            }
            //Console.WriteLine(kihivo + "\n" + kihivott);
        }

        public void Gyogyul(Harcos gyogyitandoHarcos)
        {
            if (gyogyitandoHarcos.getEletero() < 1)
            {
                gyogyitandoHarcos.setEletero(gyogyitandoHarcos.MaxEletero);
            }
            else
            {
                gyogyitandoHarcos.setEletero(gyogyitandoHarcos.getEletero() + (3 + gyogyitandoHarcos.getSzint()));
            }

            if (gyogyitandoHarcos.getEletero() > gyogyitandoHarcos.MaxEletero)
            {
                gyogyitandoHarcos.setEletero(gyogyitandoHarcos.MaxEletero);
            }
        }

        public void harcosLetrehozas() 
        {
            Console.WriteLine("Adja meg a harcosa nevét!: ");
            String nev = Console.ReadLine();
            Console.WriteLine("Adja meg a harcosa státuszSablonját!\n 1: Alap életerő: 15 Alap sebzés: 3\n2: Alap életerő: 12 Alap sebzés: 4 \n3: Alap Életerő: 8 Alap sebzés: 5\n:");
            int statusz = Convert.ToInt32(Console.ReadLine());
            Boolean l = false;
            while( l != true) 
            {
                if (statusz > 0 && statusz < 4) 
                {
                    harcosok.Add(new Harcos(nev, statusz));
                    l = true;
                }
                else 
                {
                    Console.WriteLine("Nem megfelelő státuszSablon, adja meg újra!: ");
                    statusz = Convert.ToInt32(Console.ReadLine());
                }
            }
            

        }

        public override string ToString()
        {
            String s = "";
            for (int i = 0; i < harcosok.Count; i++)
            {
                s += i + ". " + harcosok[i].ToString() + "\n";
            }
            return s;
        }
    }
}
