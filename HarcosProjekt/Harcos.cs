using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosProjekt
{
    class Harcos
    {
        private String nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSebzes;

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }
        public int AlapEletero { get => alapEletero; set => alapEletero = value; }
        public int AlapSebzes { get => alapSebzes; set => alapSebzes = value; }

        public int Sebzes { get => alapSebzes + szint; }

        public int MaxEletero { get => alapEletero + szint * 3; }

        public int SzintLepeshez { get => 10 + szint * 5; }
        public Harcos(String nev, int statuszSablon) 
        {

            this.nev = nev;
            szint = 1;
            tapasztalat = 0;

            switch (statuszSablon) 
            {
                case 1:
                    alapEletero = 15;
                    alapSebzes = 3;
                    break;
                case 2:
                    alapEletero = 12;
                    alapSebzes = 4;
                    break;
                case 3:
                    alapEletero = 8;
                    alapSebzes = 5;
                    break;
            }

            eletero = MaxEletero;

        }

        public override string ToString()
        {
            String s = nev + " - LVL: " + szint + " - EXP:" + tapasztalat + "/" + SzintLepeshez + " - HP: " + eletero + "/" + MaxEletero + " - DMG: " + Sebzes;
            return s;
        }
    }
    
}
