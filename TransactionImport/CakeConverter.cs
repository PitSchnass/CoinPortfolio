using System;
using System.Collections.Generic;
using System.IO;
using Common;
using Common.Enums;

namespace TransactionImport
{
    public class CakeConverter : IConverter
    {
        public List<CoinTransaction> Convert(FileStream fileStream)
        {
            var reader = new StreamReader(fileStream);
            List<CoinTransaction> transactionList = new List<CoinTransaction>();

            bool firstLine = true;
            
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();

                if (line == null)
                    break;
                
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
                transaction.Operation = (int)convertOperation(values[1]);
                
                transaction.BuyAmount = 0.00000035;
                transaction.BuyCurrency = Enum.GetName(typeof(Currency), Currency.BTC);
                transaction.BuyFiatValue = 100000;
                transaction.BuyFiatCurrency = Enum.GetName(typeof(FiatCurrency), FiatCurrency.USD);
                
                transactionList.Add(transaction);

                if (transaction.Operation == (int) TransactionOperation.Invalid)
                    Console.WriteLine("Invalid operation: " + values[1]);
            }
            
            return transactionList;
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

        
        private TransactionOperation convertOperation(string operation)
        {
            operation = operation.Replace("\"",String.Empty);
            
            switch (operation)
            {
                case "Deposit":
                    return TransactionOperation.Deposit;
                case "Withdrawal":
                    return TransactionOperation.Withdrawal;
                case "Staking reward":
                    return TransactionOperation.Staking;
                case "Lapis reward":
                    return TransactionOperation.Interest;
                case "Referral signup bonus":
                case "Liquidity mining reward BTC-DFI":
                    return TransactionOperation.Reward;
                case "Withdrawal fee":
                case "Unstake fee":
                case "Remove liquidity fee BTC-DFI":
                    return TransactionOperation.Spend;
                case "Remove liquidity BTC-DFI":
                    return TransactionOperation.UnknownIgnore;
                default:
                    return TransactionOperation.Invalid;
                    
            }
        }
    }
}