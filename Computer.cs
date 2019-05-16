using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoterKaasEieren
{
    class Computer
    {
        private string GetVrijVeld (int[] data, Spelbord spelbord)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int index = data[i];
                if (spelbord.VeldIsVrij(spelbord.GetRaster()[index].ToString())) return (index + 1).ToString();
            }
            return "";
        }
        public string DoeZet(Spelbord spelbord, char symboolSpeler, char symboolComputer)
        {
            //check twee-in-een rij van computer zelf
            string zet = spelbord.CheckTweeInEenRij(symboolComputer);
            if (zet.Length > 0) return zet;
            
            //check twee-in-een rij van speler 
            zet = spelbord.CheckTweeInEenRij(symboolSpeler);
            if (zet.Length > 0) return zet;
        
            //voorkom dat speler drie op een rij krijgt
            if (spelbord.GetRaster()[4]=='5') return "5";

                // indien eerste zet pak hoekpunt
            if (!spelbord.BevatSymbool(symboolComputer))
            {
                int[] data = new int[] { 0, 2, 6, 8 };
                string result = GetVrijVeld(data, spelbord);
                if (result.Length > 0) return result;
            }

            // volgende zetten pak niet-hoekpunt
            else
            {
                int[] data = new int[] { 1, 3, 5, 7 };
                string result = GetVrijVeld(data, spelbord);
                if (result.Length > 0) return result;
            }
            // alle andere gevallen doe een willekeurige zet
            return spelbord.EersteVrijeVeld();
        }

    }
}
