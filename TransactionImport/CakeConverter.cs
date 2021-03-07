using System;
using System.Collections.Generic;
using System.Globalization;
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
                transaction.BuyAmount = convertAmount(values[2]);
                transaction.BuyCurrency = convertCurrency(values[3]);
                transaction.BuyFiatValue = convertAmount(values[4]);
                transaction.BuyFiatCurrency = convertFiatCurrency(values[5]);
                
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
                case "Bonus/Airdrop":
                    return TransactionOperation.Airdrop;
                case "Staking reward":
                    return TransactionOperation.Staking;
                case "Lapis reward":
                case "Lapis DFI Bonus":
                    return TransactionOperation.Interest;
                case "Referral signup bonus":
                case "Liquidity mining reward BTC-DFI":
                    return TransactionOperation.Reward;
                case "Withdrawal fee":
                case "Unstake fee":
                case "Remove liquidity fee BTC-DFI":
                    return TransactionOperation.Spend;
                case "Add liquidity BTC-DFI":
                case "Remove liquidity BTC-DFI":
                    return TransactionOperation.UnknownIgnore;
                default:
                    return TransactionOperation.Invalid;
                    
            }
        }


        private Decimal convertAmount(string amount)
        {
            amount = amount.Replace("\"",String.Empty);

            Decimal amountConverted = Decimal.Parse(amount, CultureInfo.InvariantCulture);
            return amountConverted;

        }
        
        private int convertCurrency(string currency)
        {
            currency = currency.Replace("\"",String.Empty);

            switch (currency)
            {
                case "BTC":
                    return (int) Currency.BTC;
                case "DFI":
                    return (int) Currency.DFI;
                case "CRO":
                    return (int) Currency.CRO;
                default:
                    return (int) Currency.Invalid;
            }
        }
        
        private int convertFiatCurrency(string fiatCurrency)
        {
            fiatCurrency = fiatCurrency.Replace("\"",String.Empty);

            switch (fiatCurrency)
            {
                case "USD":
                    return (int) FiatCurrency.USD;
                case "EUR":
                    return (int) FiatCurrency.EUR;
                default:
                    return (int) FiatCurrency.Invalid;
            }
        }
    }
}