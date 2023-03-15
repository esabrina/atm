

namespace ATM.Domain
{
    public static class AtmTransactionFactory
    {
        private static Transaction? Create(string type, Dispenser dispenser, int amount) => type.ToLowerInvariant() switch
        {
            "withdraw" => new Withdraw(amount, dispenser),
            _ => throw new ArgumentException("Transaction not identified ", type),
        };

        public static Transaction? Create(TransactionType type, Dispenser dispenser, int amount)
        {
            return Create(type.ToString(), dispenser, amount);
        }

    }
}
