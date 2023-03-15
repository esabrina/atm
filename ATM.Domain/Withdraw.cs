using System.Text;

namespace ATM.Domain
{
    /// <summary>
    /// ATM withdraw transaction
    /// </summary>
    public class Withdraw : Transaction
    {
        private Dispenser Dispenser { get; set; }

        public Withdraw(int amount, Dispenser dispenser): base(amount)
        {
            Dispenser = dispenser;
        }

        /// <summary>
        /// Execute withdraw
        /// </summary>
        /// <returns>banknotes and total of notes</returns>
        public override StringBuilder Execute()
        {
            var builder = new StringBuilder();
            var list = new List<int>();
            var dictTotalWithdrawBills = new Dictionary<int, int>(); // Withdraw cash
            foreach (var n in Dispenser.Banknotes)
                dictTotalWithdrawBills.Add(n, 0);

            list.AddRange(Dispenser.AvailableBanknotes);

            try
            {
                var receivedBankNotes = PerformWithdraw(Amount, dictTotalWithdrawBills, list);
                foreach (var banknote in receivedBankNotes?.Where(x => x.Value > 0))
                    builder.AppendLine($"Entregar {banknote.Value} notas de R${banknote.Key}");
            }
            catch (ArgumentException e)
            {
                builder.AppendLine(e.Message);
            }
            return builder;
        }

        private Dictionary<int, int> PerformWithdraw(int amount, Dictionary<int, int> dictTotalWithdrawBills,
                                     List<int> availableBills)
        {
            if (Dispenser.IsSufficientCashAvailable(amount))
            {
                var receivedBankNotes = DoPerform(amount, dictTotalWithdrawBills, availableBills);
                return receivedBankNotes.Where(x => x.Value > 0).ToDictionary(x=> x.Key, x=>x.Value);
            }
            else
            {
                throw new ArgumentException(ConsoleMessage.AtmInsuficientCashMessage);
            }
        }

        /// <summary>
        /// Recursive search for banknotes
        /// </summary>
        /// <param name="amount">amount or remaing amount to withdraw</param>
        /// <param name="dictTotalWithdrawBills">dictionary with banknotes and total of notes</param>
        /// <param name="availableBills">available bills during recursive search</param>
        /// <returns>dictionary with banknotes and total of notes</returns>
        private Dictionary<int, int> DoPerform(int amount, Dictionary<int, int> dictTotalWithdrawBills,
                                List<int> availableBills)
        {
            if (amount == 0) return dictTotalWithdrawBills;

            // Notebanks not available anymore
            if (availableBills.Count == 0)
                throw new ArgumentException(ConsoleMessage.AtmInsuficientCashMessage);

            // Choose from the highest available banknote value
            var bankNote = availableBills[availableBills.Count - 1];

            int remainingAmount = amount - bankNote;
            if (remainingAmount < 0)
            {
                // Remove banknote from available bills for recursive search
                availableBills.Remove(bankNote);
                return DoPerform(amount, dictTotalWithdrawBills, availableBills);
            }

            // Update dispenser's banknotes and add total of banknote to withdraw dict
            int qtde = Dispenser.TotalOfBanknotes[bankNote] - 1;
            Dispenser.UpdateBankNoteQuantity(bankNote, qtde);
            dictTotalWithdrawBills[bankNote] = dictTotalWithdrawBills[bankNote] + 1;

            // Check if a banknote is over
            if (qtde <= 0)
            {
                Dispenser.SetBankNoteUnavailable(bankNote);
                availableBills.Remove(bankNote);
            }

            return DoPerform(remainingAmount, dictTotalWithdrawBills, availableBills);
        }
    }
}
