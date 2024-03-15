using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGUI.Classes
{
    enum TransactionTypes { Utalas, Hozzaadas, Levonas, Start }

    internal class Transaction
    {
        int value;
        Player playerFrom;
        Player playerTo;
        TransactionTypes type;

        public int Value { get { return value; } set { this.value = value; } }
        public Player PlayerFrom { get { return playerFrom; } set { playerFrom = value; } }
        public Player PlayerTo { get {  return playerTo; } set { playerTo = value; } }
        public TransactionTypes Type { get { return type; } set { type = value; } }

        public Transaction(int value, Player playerFrom, Player playerTo, TransactionTypes type)
        {
            this.value = value;
            this.playerFrom = playerFrom;
            this.playerTo = playerTo;
            this.type = type;
        }

        public override string ToString()
        {
            if (type == TransactionTypes.Utalas)
            {
                return $"[U] {playerFrom.Name} -> {playerTo.Name} {value}";
            }
            else if (type == TransactionTypes.Hozzaadas)
            {
                return $"[H] {playerTo.Name} + {value}";
            }
            else if (type == TransactionTypes.Levonas)
            {
                return $"[L] {playerFrom.Name} - {value}";
            }
            else if (type == TransactionTypes.Start)
            {
                return $"[S] {playerTo.Name} + {value}";
            }
            return string.Empty;
        }
    }
}
