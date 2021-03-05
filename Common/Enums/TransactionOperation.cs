namespace Common.Enums
{
    public enum TransactionOperation
    {
        Invalid = -1,

        Trade = 1,
        Transfer = 2,
        
        Income = 3,
        Interest = 4,
        Reward = 5,
        
        Spend = 6,
        Stolen = 7,
        Lost = 8,
        
        Airdrop = 9,
        Staking = 10,
        Mining = 11,
        
        Deposit = 12,
        Withdrawal = 13,
        
        UnknownIgnore = 14
    }
}