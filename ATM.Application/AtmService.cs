using ATM.Contracts.Interfaces;
using ATM.Domain;
using System.Text;


namespace ATM.Application
{
    public class AtmService: IAtmService
    {
        private readonly IConsoleService _consoleService;

        public AtmService(IConsoleService consoleService) => _consoleService = consoleService;

        private void DisplayResult(StringBuilder builder)
        {
            if (builder.Length > 0)
                _consoleService.WriteLine(builder);
        }
        private int ParseIntegerInput(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (Exception)
            {
                if (input != ConsoleMessage.ExitCommand)
                        _consoleService.WriteLine(ConsoleMessage.WithdrawInvalidInputMessage);
            }
            return -1;
        }

        public void InitializeAtm()
        {
            var atm = new Atm();
            var atmRunning = true;
            _consoleService.WriteLine(ConsoleMessage.AtmStartMessage);
            DisplayBanknotes(atm.TotalOfBanknotes());

            while (atmRunning)
            {
                int amount;
                _consoleService.WriteLine(ConsoleMessage.WithdrawInputMessage);
                var input = _consoleService.ReadLine();

                if (input != null && input?.ToLowerInvariant() == ConsoleMessage.ExitCommand) 
                    atmRunning = false;

                amount = ParseIntegerInput(input);
                if (amount >= 0)
                {
                    var result = atm.DoTransaction(TransactionType.Withdraw, amount);
                    DisplayResult(result);
                }
            }
            _consoleService.WriteLine(ConsoleMessage.AtmFinishMessage);
        }

        public void DisplayBanknotes(Dictionary<int, int> dict)
        {
            var builder = new StringBuilder();
            if (dict != null)
            {
                foreach (var item in dict)
                    builder.AppendLine($"{item.Value} notes of R${item.Key}");
            }
            DisplayResult(builder);
        }
    }
}
