using System.Text;


namespace ATM.Application
{
    public class ConsoleService : BaseService
    {
        public override string ReadLine() => Console.ReadLine();
        public override void WriteLine(StringBuilder value) => Console.WriteLine(value);
        public override void WriteLine(string value) => Console.WriteLine(value);
    }
}
