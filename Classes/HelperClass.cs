using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonopolyGUI.Classes
{
    internal class HelperClass
    {
        static Savegame sg = null;
        public static Savegame Sg { get { return sg; } }

        public static int initmoney = 15_000_000;
        // a startmezo penze a savegameben van deklaralva
        //public static int startmoney = 2_000_000;

        public static void NewGame(List<string> playerNames)
        {
            List<Transaction> transactions = new List<Transaction>();
            List<Player> players = new List<Player>();
            foreach (string playerName in playerNames)
            {
                players.Add(new Player(playerName, initmoney));
            }
            players.Add(new Player());
            sg = new Savegame("Babaakok", players, transactions);
        }

        public static string[] GetTransactionStrings()
        {
            string[] transactionStrings = new string[sg.Transactions.Count];
            for (int i = 0; i < transactionStrings.Length; i++)
            {
                transactionStrings[i] = sg.Transactions[i].ToString();
            }
            return transactionStrings;
        }

        public static string[] GetPlayersNames()
        {
            int notRealCount = 0;
            string[] playersNames = new string[sg.Players.Count-1];
            for (int i = 0; i < playersNames.Length; i++)
            {
                if (!sg.Players[i].IsReal)
                {
                    notRealCount++;
                }
                else
                {
                    playersNames[i - notRealCount] = sg.Players[i].Name;
                }
            }
            return playersNames;
        }

        public static void Save()
        {
            string savepath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            savepath = savepath + "\\monopoly.json";
            string jsonSave = JsonSerializer.Serialize(sg);
            File.WriteAllText(savepath, jsonSave);
        }

        public static void Load()
        {
            string savepath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            savepath = savepath + "\\monopoly.json";
            sg = JsonSerializer.Deserialize<Savegame>(File.ReadAllText(savepath));
        }
    }
}
