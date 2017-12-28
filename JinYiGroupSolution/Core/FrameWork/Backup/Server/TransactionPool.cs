using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Neusoft.FrameWork.Server
{
    public static class TransactionPool
    {
        private static Dictionary<string, System.Data.IDbTransaction> transactions = new Dictionary<string, System.Data.IDbTransaction>();

        public static System.Data.IDbTransaction GetTransaction(string id)
        {
            if (transactions.ContainsKey(id))
            {
                return transactions[id];
            }
            else
            {
                return null;
            }
        }

        public static void SetTransaction(string id, IDbTransaction transaction)
        {
            transactions[id] = transaction;

        }

        public static void RemoveTransaction(string id)
        {
            if (transactions.ContainsKey(id))
            {
                try
                {
                    transactions[id].Dispose();
                }
                catch { }
                transactions.Remove(id);
            }
        }
    }
}
