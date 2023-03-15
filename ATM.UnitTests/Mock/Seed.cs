using ATM.Domain;
using System.Text;


namespace ATM.UnitTests.Mock
{
    /// <summary>
    /// Seeded data for tests purposes
    /// </summary>
    public static class Seed
    {
        public static StringBuilder AtmDispenserBanknotesStarted()
        {
            var builder = new StringBuilder();
            builder.AppendLine("3 notes of R$10");
            builder.AppendLine("3 notes of R$20");
            builder.AppendLine("3 notes of R$50");
            builder.AppendLine("3 notes of R$100");
            return builder;
        }
        public static StringBuilder WithdrawOkResult()
        {
            var builder = new StringBuilder();
            builder.AppendLine(ConsoleMessage.AtmStartMessage);
            builder.Append(AtmDispenserBanknotesStarted());
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine("Entregar 1 notas de R$10");
            builder.AppendLine("Entregar 1 notas de R$20");
            builder.AppendLine("Entregar 1 notas de R$100");
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine("Entregar 1 notas de R$20");
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine(ConsoleMessage.AtmFinishMessage);
            return builder;
        }

        public static StringBuilder WithdrawWithInvalidInputResult()
        {
            var builder = new StringBuilder();
            builder.AppendLine(ConsoleMessage.AtmStartMessage);
            builder.Append(AtmDispenserBanknotesStarted());
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine(ConsoleMessage.WithdrawInvalidInputMessage);
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine("Entregar 1 notas de R$20");
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine(ConsoleMessage.AtmFinishMessage);
            return builder;
        }

        public static StringBuilder WithdrawWithInsufficientCashResult()
        {
            var builder = new StringBuilder();
            builder.AppendLine(ConsoleMessage.AtmStartMessage);
            builder.Append(AtmDispenserBanknotesStarted());
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine(ConsoleMessage.AtmInsuficientCashMessage);
            builder.AppendLine(ConsoleMessage.WithdrawInputMessage);
            builder.AppendLine(ConsoleMessage.AtmFinishMessage);
            return builder;
        }

        public static Dictionary<int, int> BanknotesSample()
        {
           Dictionary<int, int> dict = new()
            {
                { 10, 3 },
                { 20, 3 },
                { 50, 3 },
                { 100, 3 }
            };
            return dict;
        }
    }
}
