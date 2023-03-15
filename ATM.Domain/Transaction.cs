using System.Text;

namespace ATM.Domain
{
    /// <summary>
    /// ATM transaction (withdraw, deposit, transfer, and so on)
    /// </summary>
    public abstract class Transaction
    {
        protected int Amount { get;}

        protected Transaction(int amount)
        {
            Amount = amount;
        }

        public abstract StringBuilder Execute();
    }
}
