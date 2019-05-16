using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoterKaasEieren
{
    class Program
    {
        static void Intro()
        {
            Console.WriteLine("Hallo");
            Console.WriteLine("Welkom bij het spel Boter Kaas en Eieren");
            Console.WriteLine("Dit spel is bedoeld is om met 2 spelers te spelen. ");
            Console.WriteLine("Het spel bevat 9 vakjes.");
            Console.WriteLine("Speler 1 vult het symbool X in.");
            Console.WriteLine("Speler 2 vult het symbool O in.");
            Console.WriteLine("Wie als eerste 3 symbolen op een rij heeft, heeft gewonnen!");
        }

        static string SpelTypeKeuze()
        {
            string spelkeuze;
            Console.WriteLine("Je kunt spelen tegen een ander persoon of tegen de computer");
            Console.WriteLine("Wil je een tweespelerspelerspel starten toets '2'");
            Console.WriteLine("Wil je een spel tegen de computer starten toets '1'");
            Console.Write("Jouw keuze: ");
            return spelkeuze = Console.ReadLine();
        }

        static string StartspelerBepalen(string speler1, string speler2)
        {
            Random random = new Random();
            string startspeler;
            if (random.Next(0, 2) < 1)
            {
                 startspeler= speler1;
            }
            else
            {
                startspeler = speler2;
            }
            return startspeler;
        }

        static void Main(string[] args)
        {
            Spelbord spelbord = new Spelbord();
            Computer computer = new Computer();
            string speler1 = "";
            string speler2 = "";
            char symboolComputer = 'O';
            char symboolSpeler = 'X';

            Intro();
            string spelkeuze = SpelTypeKeuze();
            Console.WriteLine();
            Console.WriteLine("Speler 1, hoe heet je?");
            speler1 = Console.ReadLine();
            if (spelkeuze == "2")
            {
                Console.WriteLine("Speler 2, hoe heet je?");
                speler2 = Console.ReadLine();
            }
            else speler2 = "Computer";

            Console.WriteLine("{0} speelt tegen {1}!", speler1, speler2);
            spelbord.ShowRaster();
            Console.WriteLine();
            bool gewonnen = false;
            bool heeftRuimte = true;
            string speleraandebeurt = StartspelerBepalen(speler1, speler2);
            char symbool; 
            while (!gewonnen && heeftRuimte)
            {
                symbool = (speleraandebeurt == speler1) ? 'X' : 'O';

                string zet = "";
                heeftRuimte = spelbord.SpaceRaster();
                if (heeftRuimte)
                {
                    if (spelkeuze == "1")
                    {
                        if (speleraandebeurt == speler1)
                        {
                            zet = spelbord.DoeZet(speleraandebeurt);
                        }
                        else
                        {
                            zet = computer.DoeZet(spelbord, symboolSpeler, symboolComputer);
                            Console.WriteLine("computer kiest {0}", zet);
                        }
                    }
                    else
                    {
                        zet = spelbord.DoeZet(speleraandebeurt);
                    }
                    spelbord.VerwerkZet(zet, symbool);
                    spelbord.ShowRaster();
                    gewonnen = spelbord.Score(symbool);
                    if (gewonnen)
                    {
                        Console.WriteLine("\nGefeliciteerd {0}!", speleraandebeurt);
                    }
                    speleraandebeurt = (speleraandebeurt == speler1) ? speler2 : speler1;
                }
            }
            if (!gewonnen)
            {
                Console.WriteLine();
                Console.WriteLine("\nGelijkspel");
            }
            Console.WriteLine("Press <ENTER> to EXIT!");
            Console.ReadLine();
        }
    }
}
