
namespace ATM.Domain
{
    public static class ConsoleMessage
    {
        // display ATM messages
        public const string WithdrawInputMessage = "=> Enter withdraw amount (integer) or type 'exit' to leave: ";
        public const string WithdrawInvalidInputMessage = "Invalid input.";
        public const string AtmStartMessage = "=> ATM started with:";
        public const string AtmFinishMessage = "ATM finished.";
        public const string AtmInsuficientCashMessage = "Insufficient cash in the ATM.";

        // finish ATM
        public const string ExitCommand = "exit";
    }
}
