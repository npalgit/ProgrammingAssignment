using System;
using ProgrammingAssignmentCore;

namespace ProgrammingAssignmentEngine
{
    public interface IStringReverseEngine
    {
        void StringReverse(string input);
        void DisplayPrime(string result);
    }
    public class StringReverseEngine : IStringReverseEngine
    {
        public ILogger _logger;
        public StringReverseEngine(ILogger logger)
        {
            _logger = logger;
        }
        public void StringReverse(string input)
        {
            char[] strAsCharArray = input.ToCharArray();
            char[] result = new char[strAsCharArray.Length];

            for (int i = 0; i < strAsCharArray.Length; i++)
                result[i] = strAsCharArray[strAsCharArray.Length - i - 1];
            string stringResult = new string(result);
            Console.WriteLine(stringResult);
        }
        public void DisplayPrime(string result)
        {
            string _message = $"{Constans.ReversedStringMessage} {Constans.Space} {result}.";
            _logger.Log(LogLevel.Info, _message);
        }
    }
}
