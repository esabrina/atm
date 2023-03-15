

using System.Text;

namespace ATM.Contracts.Interfaces
{
    public interface IConsoleService
    {
        void WriteLine(string value);
        void WriteLine(StringBuilder value);
        string ReadLine();
    }
}
