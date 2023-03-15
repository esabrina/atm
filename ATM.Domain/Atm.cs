using System.Text;

namespace ATM.Domain
{
    /// <summary>
    /// ATM cash machine
    /// </summary>
    public class Atm
    {
        private readonly Dispenser _dispenser;

        public Atm()
        {
            _dispenser = new Dispenser();
        }
        private Transaction? CreateTransaction(TransactionType type, int amount) => AtmTransactionFactory.Create(type, _dispenser, amount);

        public StringBuilder? DoTransaction(TransactionType type, int amount)
        {
            var currentTransaction = CreateTransaction(type, amount);
            return currentTransaction?.Execute();

        }
        public Dictionary<int, int> TotalOfBanknotes() => _dispenser.TotalOfBanknotes;
    }
}