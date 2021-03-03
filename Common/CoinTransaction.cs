using System;

namespace Common
{
    public struct CoinTransaction
    {
        public int TransactionId { get; set; }
        
        public int Operation { get; set; }
        
        public DateTime TransactionDate { get; set; }
        
        public double? BuyAmount { get; set; }
        
        public string BuyCurrency { get; set; }
        
        public decimal? BuyFiatValue { get; set; }
        
        public string BuyFiatCurrency { get; set; }
        
        public double? SellAmount { get; set; }
        
        public string SellCurrency { get; set; }
        
        public decimal? SellFiatValue { get; set; }
        
        public string SellFiatCurrency { get; set; }
        
        public double? FeeAmount { get; set; }
        
        public string FeeCurrency { get; set; }
        
        public decimal? FeeFiatValue { get; set; }
        
        public string FeeFiatCurrency { get; set; }
        
        public string Comment { get; set; }
        
        public string ExternalId { get; set; }
        
        public string Exchange { get; set; }
        
    }
}