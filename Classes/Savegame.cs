using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonopolyGUI.Classes
{
    internal class Savegame
    {
        string saveName;
        public string SaveName { get { return saveName; } set { saveName = value; } }

        List<Player> players;
        List<Transaction> transactions;

        public List<Player> Players { get { return players; } set { players = value; } }
        public List<Transaction> Transactions { get {  return transactions; } set { transactions = value; } }

        public Savegame(string saveName, List<Player> players, List<Transaction> transactions)
        {
            this.players = players;
            this.transactions = transactions;
            this.saveName = saveName;
        }

        Player GetBankPlayer()
        {
            foreach (Player player in players)
            {
                if (player.Name == "bank" && !player.IsReal)
                {
                    return player;
                }
            }
            return null;
        }

        public Player GetPlayerFromName(string name)
        {
            foreach (Player player in players)
            {
                if (player.Name.Equals(name))
                {
                    return player;
                }
            }
            return null;
        }

        public void StartTile(Player player)
        {
            Transaction newTransaction = new Transaction(2_000_000, GetBankPlayer(), player, TransactionTypes.Start);
            player.ProcessTransaction(newTransaction);
            transactions.Add(newTransaction);
        }

        public void AddMoney(Player player, int amount)
        {
            Transaction newTransaction = new Transaction(amount, GetBankPlayer(), player, TransactionTypes.Hozzaadas);
            player.ProcessTransaction(newTransaction);
            transactions.Add(newTransaction);
        }

        public bool RemoveMoney(Player player, int amount)
        {
            Transaction newTransaction = new Transaction(amount, player, GetBankPlayer(), TransactionTypes.Levonas);
            if (player.ProcessTransaction(newTransaction))
            {
                transactions.Add(newTransaction);
                return true;
            }
            return false;
        }

        public bool TransferMoney(Player playerFrom, Player playerTo, int amount)
        {
            Transaction newTransaction = new Transaction(amount, playerFrom, playerTo, TransactionTypes.Utalas);
            if (playerFrom.ProcessTransaction(newTransaction))
            {
                playerTo.ProcessTransaction(newTransaction);
                transactions.Add(newTransaction);
                return true;
            }
            return false;
        }

    }
}
