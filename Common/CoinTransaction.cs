using System;

namespace Common
{
    public struct CoinTransaction
    {
        public int TransactionId { get; set; }
        
        public int Operation { get; set; }
        
        public DateTime TransactionDate { get; set; }
        
        public decimal? BuyAmount { get; set; }
        
        public int? BuyCurrency { get; set; }
        
        public decimal? BuyFiatValue { get; set; }
        
        public int? BuyFiatCurrency { get; set; }
        
        public decimal? SellAmount { get; set; }
        
        public int? SellCurrency { get; set; }
        
        public decimal? SellFiatValue { get; set; }
        
        public int? SellFiatCurrency { get; set; }
        
        public decimal? FeeAmount { get; set; }
        
        public int? FeeCurrency { get; set; }
        
        public decimal? FeeFiatValue { get; set; }
        
        public int? FeeFiatCurrency { get; set; }
        
        public string Comment { get; set; }
        
        public string ExternalId { get; set; }
        
        public string Exchange { get; set; }
        
    }
}