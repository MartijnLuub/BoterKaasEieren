using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoterKaasEieren
{
    class Spelbord
    {
        private char[] raster;
        private int[,] WinnendeCombinaties = new int[,]
           {
                { 0,1,2},
                { 3,4,5},
                { 6,7,8},
                { 0,3,6},
                { 1,4,7},
                { 2,5,8},
                { 0,4,8},
                { 2,4,6}
           };

        //constructor
        public Spelbord()
        {
            raster = "123456789".ToArray();
        }

        public char[] GetRaster()
        {
            return raster;
        }

        public bool SpaceRaster()
        {
            for (int i = 0; i < raster.Length; i++)
            {
                if (raster[i] >= '1' && raster[i] <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        public void ShowRaster()
        {
            string s = new string(raster);
            Console.WriteLine(s.Substring(0, 3));
            Console.WriteLine(s.Substring(3, 3));
            Console.WriteLine(s.Substring(6, 3));
            // Console.WriteLine(r);
            // Console.WriteLine(r);
        }

        public void VerwerkZet(string zet, char symbool)
        {
            raster[Int32.Parse(zet) - 1] = symbool;
        }

        private bool DrieOpEenRij(int een, int twee, int drie, char symbool)
        {
            return (raster[een] == symbool && raster[twee] == symbool && raster[drie] == symbool);
        }

        private string TweeInEenRij(int een, int twee, int drie, char symbool)
        {
            if (raster[een] == symbool && raster[twee] == symbool && raster[drie] != symbool) return raster[drie].ToString();
            if (raster[twee] == symbool && raster[drie] == symbool && raster[een] != symbool) return raster[een].ToString();
            if (raster[een] == symbool && raster[drie] == symbool && raster[twee] != symbool) return raster[twee].ToString();
            return "";
        }

        public bool Score(char symbool)
        {
            for (int rij = 0; rij < WinnendeCombinaties.GetLength(0); rij++)
            {
                if (DrieOpEenRij(WinnendeCombinaties[rij, 0],
                    WinnendeCombinaties[rij, 1],
                    WinnendeCombinaties[rij, 2],
                    symbool)) return true;
            }
            return false;
        }

        public string DoeZet(string speleraandebeurt)
        {
            bool zetValid = false;
            string zet = "";
            while (!zetValid)
            {
                Console.WriteLine(speleraandebeurt + " jij bent aan de beurt, wat is je zet?");
                zet = Console.ReadLine();
                if (VeldIsVrij(zet))
                {
                    zetValid = true;
                }
            }
            return zet;
        }

        public string CheckTweeInEenRij(char symbool)
        {
            for (int rij = 0; rij < WinnendeCombinaties.GetLength(0); rij++)
            {
                string zet = TweeInEenRij(WinnendeCombinaties[rij, 0],
                    WinnendeCombinaties[rij, 1],
                    WinnendeCombinaties[rij, 2], symbool);
                if (zet.Length > 0 && VeldIsVrij(zet))
                {
                    return zet;
                }
            }
            return "";
        }

        public bool BevatSymbool(char symbool)
        {
            return raster.Contains(symbool);
        }

        public bool VeldIsVrij(String zet)
        {
            if (!Int32.TryParse(zet, out int result)) return false;
            else return (result >= 1 && result <= 9);
        }

        public string EersteVrijeVeld()
        {
            for (int i = 0; i < raster.Length; i++)
            {
                if (VeldIsVrij(raster[i].ToString())) return raster[i].ToString();
            }
            return "";
        }
    }
}


