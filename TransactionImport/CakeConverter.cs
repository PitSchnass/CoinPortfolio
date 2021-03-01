using System;
using System.Collections.Generic;
using System.IO;
using Common;
using Common.StaticClasses;

namespace TransactionImport
{
    public class CakeConverter : IConverter
    {
        public void Convert(FileStream fileStream)
        {
            var reader = new StreamReader(fileStream);
            List<CoinTransaction> transactionList = new List<CoinTransaction>();

            bool firstLine = true;
            
            while (!reader.EndOfStream)
            {
                // -- Skip first line
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                var line = reader.ReadLine();
                var values = line.Split(',');

                var transaction = new CoinTransaction();

                transaction.TransactionId = -1;
                transaction.TransactionDate = DateTime.Parse(values[0]);
                
                transaction.BuyAmount = 0.00000035;
                transaction.BuyCurrency = Currency.Bitcoin;
                transaction.BuyFiatValue = 100000;
                transaction.BuyFiatCurrency = FiatCurrency.UsDollar;
                
                transactionList.Add(transaction);
                
                Console.WriteLine(transaction.TransactionDate);
                Console.WriteLine(transaction.BuyCurrency);
                Console.WriteLine(transaction.BuyFiatCurrency);
                
                Console.WriteLine(values[0]);
            }
        }
    }
}