using ATM.Application;
using System.Text;


namespace ATM.UnitTests.Mock
{
    public class ConsoleServiceStub : BaseService
    {
        private StringBuilder _writeLineResult = new();
        public List<string> ReadLineValue { get; set; } = new();

        public StringBuilder WriteLineResult => _writeLineResult;
        public override string ReadLine()
        {
            var value = ReadLineValue[0];
            ReadLineValue.Remove(value);
            return value;
        }
        public override void WriteLine(StringBuilder value) => _writeLineResult.Append(value);


        public override void WriteLine(string value)
        {
            _writeLineResult.AppendLine(value);
        }
    }
}
