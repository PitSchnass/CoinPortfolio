namespace Common.Enums
{
    public enum TransactionOperation
    {
        Invalid = -1,

        Trade = 1,
        Transfer = 2,
        
        Income = 3,
        Interest = 4,
        
        Spend = 5,
        Stolen = 6,
        Lost = 7,
        
        Airdrop = 8,
        Staking = 9,
        Mining = 10,
        
        Deposit = 11,
        Withdrawal = 12,
        
        UnknownIgnore = 13
    }
}