using System;
using System.IO;

namespace Core
{
    /// <summary>
    /// Logs transactions to a text file
    /// </summary>
    public class TxtLogger
    {
        public TxtLogger(ILineSystem lineSystem, string path) : this(lineSystem)
        {
            Path = path;
        }

        public TxtLogger(ILineSystem lineSystem)
        {
            lineSystem.TransactionExecutedEvent += LogTransaction;
        }

        public string Path { get; set; } = "./transactions.txt";

        /// <summary>
        /// Logs transactions made from the connected Line system
        /// </summary>
        /// <param name="sender">the class that invoked the event</param>
        /// <param name="transaction">the transaction to log</param>
        public void LogTransaction(object sender, Transaction transaction)
        {
            StreamWriter logger = File.AppendText(Path);
            logger.WriteLine(transaction);
            logger.Close();
        }
    }
}