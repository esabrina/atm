

namespace ATM.Domain
{
    /// <summary>
    /// ATM's cash dispenser
    /// </summary>
    public class Dispenser
    {
        public Dictionary<int, int> TotalOfBanknotes { get; } // total of each banknote
        public List<int> AvailableBanknotes { get; } // available banknotes
        public static readonly int[] Banknotes = { 10, 20, 50, 100 };

        const int InicialCount = 3;

        public Dispenser()
        {
            // Load dispenser with the InicialCount quantity for each banknote
            TotalOfBanknotes = new Dictionary<int, int>();
            AvailableBanknotes = Banknotes.ToList();
            AvailableBanknotes.Sort();
            foreach (var n in AvailableBanknotes)
                TotalOfBanknotes.Add(n, InicialCount);
        }

        /// <summary>
        /// Calculate the amount of available cash on dispenser 
        /// </summary>
        /// <returns>total amount of available cash</returns>
        /// 
        private int CalculateAvailableCash()
        {
            var totalCash = 0;
            foreach (var item in TotalOfBanknotes)
                totalCash += (item.Key * item.Value);
            return totalCash;
        }


        /// <summary>
        /// Chech if dispenser has enough banknotes available and 
        /// indicates whether cash dispenser can dispense desired amount
        /// </summary>
        /// <param name="amount">amount to withdraw</param>
        /// <returns>Has enough cash or not</returns>
        public bool IsSufficientCashAvailable(int amount)
        {
            // return whether there are enough banknotes available
            var hasCash = true;
            var totalCash = CalculateAvailableCash();
            if ((AvailableBanknotes.Count == 0) || (amount < AvailableBanknotes[0]))
                    hasCash = false;
            if (totalCash < amount) hasCash = false;
            return hasCash;
        }

        /// <summary>
        /// Set banknote unavailable (when its over)
        /// </summary>
        /// <param name="value">banknote that must be unavailable</param>
        public void SetBankNoteUnavailable(int value) => AvailableBanknotes.Remove(value);

        /// <summary>
        /// Update the quantity of a banknote
        /// </summary>
        /// <param name="bankNote">banknote to be updated</param>
        /// <param name="total">total of available notes</param>
        public void UpdateBankNoteQuantity(int bankNote, int total) => TotalOfBanknotes[bankNote] = total;
    }
}
