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

        public String getNev() 
        {
            return this.nev;
        }

        public void setNev(String ujNev) 
        {
            this.nev = ujNev;
        }

        public int getSzint() 
        {
            return this.szint;
        }

        public void setSzint(int ujSzint) 
        {
            this.szint = ujSzint;
        }

        public int getTapasztalat() 
        {
            return this.tapasztalat;
        }

        public void setTapasztalat(int ertek) 
        {
            this.tapasztalat += ertek;
            if (this.tapasztalat == SzintLepeshez || this.tapasztalat > SzintLepeshez) 
            {
                setSzint(getSzint()+1);
                setEletero(MaxEletero);
                this.tapasztalat = 0;
            }
        }

        public int getAlapEletero() 
        {
            return this.alapEletero;   
        }

        public int getAlapSebzes() 
        {
            return this.alapSebzes;
        }

        public int getEletero() 
        {
            return this.eletero;
        }

        public void setEletero(int ertek) 
        {
            this.eletero = ertek;
            if (this.eletero < 1) 
            {
                setTapasztalat(0);
            }
        }
            
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
