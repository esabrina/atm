using ATM.Application;
using ATM.Contracts.Interfaces;
using ATM.Domain;
using ATM.UnitTests.Mock;
using System.Text.RegularExpressions;

namespace ATM.UnitTests
{
    public class AtmServiceTest
    {
        private readonly IAtmService _service;
        private readonly ConsoleServiceStub _console;


        public AtmServiceTest()
        {
            _console = new ConsoleServiceStub();
            _service = new AtmService(_console);
        }

        [Fact]
        public void InitializeATM_WithdrawWithOKResults_Test()
        {
            _console.ReadLineValue = new List<string>() {"130", "20", ConsoleMessage.ExitCommand };
            _service.InitializeAtm();

            Assert.NotEmpty(_console.WriteLineResult.ToString());
            Assert.Equal(Seed.WithdrawOkResult().ToString(), _console.WriteLineResult.ToString());
        }

        [Fact]
        public void InitializeATM_WithdrawWithInvalidInputResults_Test()
        {
            _console.ReadLineValue = new List<string>() { "x", "20", ConsoleMessage.ExitCommand };
            _service.InitializeAtm();

            Assert.NotEmpty(_console.WriteLineResult.ToString());
            Assert.Equal(Seed.WithdrawWithInvalidInputResult().ToString(), _console.WriteLineResult.ToString());
        }

        [Fact]
        public void InitializeATM_WithdrawWithInsufficientCashResults_Test()
        {
            _console.ReadLineValue = new List<string>() { "5000", ConsoleMessage.ExitCommand };
            _service.InitializeAtm();

            Assert.NotEmpty(_console.WriteLineResult.ToString());
            Assert.Equal(Seed.WithdrawWithInsufficientCashResult().ToString(), _console.WriteLineResult.ToString());
        }

        [Fact]
        public void InitializeATM_WithdrawWithBanknoteFinishedResults_Test()
        {
            var expected = 1;
            var banknoteValueToWithdraw = 10; 
            var atm = new Atm();
            var banknotes = atm.TotalOfBanknotes();
            var count = banknotes[banknoteValueToWithdraw] + 1;
            var list = Enumerable.Repeat($"{banknoteValueToWithdraw}", count).ToList();
            list.Add(ConsoleMessage.ExitCommand);
            _console.ReadLineValue = list;
            _service.InitializeAtm();
            var countOccurrences = Regex.Matches(_console.WriteLineResult.ToString(), ConsoleMessage.AtmInsuficientCashMessage).Count;

            Assert.NotEmpty(_console.WriteLineResult.ToString());
            Assert.Contains(ConsoleMessage.AtmInsuficientCashMessage, _console.WriteLineResult.ToString());
            Assert.Equal(expected, countOccurrences);
        }

        [Fact]
        public void DisplayBanknotes_OK_Test()
        {
            _service.DisplayBanknotes(Seed.BanknotesSample());

            Assert.NotEmpty(_console.WriteLineResult.ToString());
            Assert.Equal(Seed.AtmDispenserBanknotesStarted().ToString(), _console.WriteLineResult.ToString());
        }

        [Fact]
        public void DisplayBanknotes_Empty_Test()
        {
            _service.DisplayBanknotes(new Dictionary<int, int>());

            Assert.Empty(_console.WriteLineResult.ToString());
        }

        [Fact]
        public void DisplayBanknotes_Null_Test()
        {
            _service.DisplayBanknotes(null);

            Assert.Empty(_console.WriteLineResult.ToString());
        }
    }
}