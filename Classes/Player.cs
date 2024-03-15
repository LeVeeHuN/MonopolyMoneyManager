using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGUI.Classes
{
    internal class Player
    {
        string name;
        int balance;
        bool isReal;

        public string Name {  get { return name; } set { name = value; } }
        public int Balance { get { return balance; } set { balance = value; } }
        public bool IsReal {  get { return isReal; } set { isReal = value; } }

        public Player(string name, int balance)
        {
            this.name = name;
            this.balance = balance;
            isReal = true;
        }

        public Player()
        {
            name = "bank";
            balance = int.MaxValue / 2;
            isReal = false;
        }

        bool ValidateTransaction(Transaction transaction)
        {
            if (transaction.Type == TransactionTypes.Utalas || transaction.Type == TransactionTypes.Levonas)
            {
                if (transaction.PlayerFrom == this)
                {
                    if (transaction.Value > balance)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ProcessTransaction(Transaction transaction)
        {
            if (!ValidateTransaction(transaction))
            {
                return false;
            }

            switch (transaction.Type)
            {
                case TransactionTypes.Utalas:
                    if (transaction.PlayerFrom == this)
                    {
                        balance -= transaction.Value;
                    }
                    else if (transaction.PlayerTo == this)
                    {
                        balance += transaction.Value;
                    }
                    break;
                case TransactionTypes.Levonas:
                    balance -= transaction.Value;
                    break;
                case TransactionTypes.Hozzaadas:
                    balance += transaction.Value;
                    break;
                case TransactionTypes.Start:
                    balance += transaction.Value;
                    break;
            }

            return true;
        }
    }
}
