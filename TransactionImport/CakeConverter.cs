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

                var line = reader.ReadLine();
                
                // -- Skip first line
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                var values = line.Split(',');
                
                var transaction = new CoinTransaction();

                transaction.TransactionId = -1;
                transaction.TransactionDate = convertDateTimeString(values[0]);
                
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

        private DateTime convertDateTimeString(string dateTime)
        {
            dateTime = dateTime.Replace("\"",String.Empty);
            var realDate = dateTime.Substring(0, 19);
            var offsetHours = dateTime.Substring(20,2);
            var offsetMinutes = dateTime.Substring(23, 2);

            var ret = DateTime.Parse(realDate);
            ret = ret.AddHours(Int32.Parse(offsetHours));
            ret = ret.AddMinutes(Int32.Parse(offsetMinutes));

            return ret;
        }
    }
}