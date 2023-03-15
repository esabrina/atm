


namespace ATM.Contracts.Interfaces
{
    public interface IAtmService
    {
        void InitializeAtm();
        void DisplayBanknotes(Dictionary<int, int> dict);
    }
}
