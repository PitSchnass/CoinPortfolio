using System;
using System.Data.SQLite;
using Common;

namespace DataLayer
{
    public class SqlLiteDataLayer
    {
        private const string _connectionString = @"Data Source=D:\Projekte\CoinPortfolio\DataLayer\coinportfolio.db";

        public void ClearCoinTransactionTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                string sql = "DELETE FROM TRANSACTIONS";

                using (SQLiteCommand command = new SQLiteCommand(sql))
                {
                    command.Connection=connection;
                    
                    connection.Open();

                    command.ExecuteNonQuery();
                    
                    connection.Close();
                }
            }
        }
        
        public void InsertCoinTransaction(CoinTransaction coinTransaction)
        {
            
            using ( SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                string sql =
                    @"INSERT INTO TRANSACTIONS (Operation, TransactionDate, BuyAmount, BuyCurrency, BuyFiatValue, BuyFiatCurrency,
                                                                SellAmount, SellCurrency, SellFiatValue, SellFiatCurrency, 
                                                                FeeAmount, FeeCurrency, FeeFiatValue, FeeFiatCurrency,
                                                                Exchange, Comments, ExternalId) 
                                        VALUES (@operation, @transaction_date, @buy_amount, @buy_currency, @buy_fiat_value, @buy_fiat_currency,
                                                @sell_amount, @sell_currency, @sell_fiat_value, @sell_fiat_currency, 
                                                @fee_amount, @fee_currency, @fee_fiat_value, @fee_fiat_currency,
                                                @exchange, @comments, @external_id)";

                using (SQLiteCommand command = new SQLiteCommand(sql))
                {
                    command.Connection=connection;
                    command.Parameters.AddWithValue("@operation", coinTransaction.Operation);
                    command.Parameters.AddWithValue("@transaction_date", coinTransaction.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    
                    if (coinTransaction.BuyAmount.HasValue)
                        command.Parameters.AddWithValue("@buy_amount", coinTransaction.BuyAmount.Value);
                    else
                        command.Parameters.AddWithValue("@buy_amount", null);
                    
                    if (coinTransaction.BuyCurrency.HasValue)
                        command.Parameters.AddWithValue("@buy_currency", coinTransaction.BuyCurrency.Value);
                    else
                        command.Parameters.AddWithValue("@buy_currency", null);
                    
                    
                    if (coinTransaction.BuyFiatValue.HasValue)
                        command.Parameters.AddWithValue("@buy_fiat_value", coinTransaction.BuyFiatValue.Value);
                    else
                        command.Parameters.AddWithValue("@buy_fiat_value", null);
                    
                    if (coinTransaction.BuyFiatCurrency.HasValue)
                        command.Parameters.AddWithValue("@buy_fiat_currency", coinTransaction.BuyFiatCurrency.Value);
                    else
                        command.Parameters.AddWithValue("@buy_fiat_currency", null);

                    if (coinTransaction.SellAmount.HasValue)
                        command.Parameters.AddWithValue("@sell_amount", coinTransaction.SellAmount.Value);
                    else
                        command.Parameters.AddWithValue("@sell_amount", null);
                    
                    if (coinTransaction.SellCurrency.HasValue)
                        command.Parameters.AddWithValue("@sell_currency", coinTransaction.SellCurrency.Value);
                    else
                        command.Parameters.AddWithValue("@sell_currency", null);
                    
                    if (coinTransaction.SellFiatValue.HasValue)
                        command.Parameters.AddWithValue("@sell_fiat_value", coinTransaction.SellFiatValue.Value);
                    else
                        command.Parameters.AddWithValue("@sell_fiat_value", null);
                    
                    if (coinTransaction.SellFiatCurrency.HasValue)
                        command.Parameters.AddWithValue("@sell_fiat_currency", coinTransaction.SellFiatCurrency.Value);
                    else
                        command.Parameters.AddWithValue("@sell_fiat_currency", null);
                    
                    if (coinTransaction.FeeAmount.HasValue)
                        command.Parameters.AddWithValue("@fee_amount", coinTransaction.FeeAmount.Value);
                    else
                        command.Parameters.AddWithValue("@fee_amount", null);
                    
                    if (coinTransaction.FeeCurrency.HasValue)
                        command.Parameters.AddWithValue("@fee_currency", coinTransaction.FeeCurrency.Value);
                    else
                        command.Parameters.AddWithValue("@fee_currency", null);
                    
                    if (coinTransaction.FeeFiatValue.HasValue)
                        command.Parameters.AddWithValue("@fee_fiat_value", coinTransaction.FeeFiatValue.Value);
                    else
                        command.Parameters.AddWithValue("@fee_fiat_value", null);
                    
                    if (coinTransaction.FeeFiatCurrency.HasValue)
                        command.Parameters.AddWithValue("@fee_fiat_currency", coinTransaction.FeeFiatCurrency.Value);
                    else
                        command.Parameters.AddWithValue("@fee_fiat_currency", null);

                    command.Parameters.AddWithValue("@exchange", coinTransaction.Exchange);
                    command.Parameters.AddWithValue("@comments", coinTransaction.Comment);
                    command.Parameters.AddWithValue("@external_id", coinTransaction.ExternalId);

                    connection.Open();

                    command.ExecuteNonQuery();
                    
                    connection.Close();
                }
            }
        }
    }
}