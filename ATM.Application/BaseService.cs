using ATM.Contracts.Interfaces;
using System.Text;


namespace ATM.Application
{
    public abstract class BaseService: IConsoleService
    {
        public abstract string ReadLine();
        public abstract void WriteLine(StringBuilder value);
        public abstract void WriteLine(string value);
    }
}
