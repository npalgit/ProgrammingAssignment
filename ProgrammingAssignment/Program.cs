using System;
using System.Threading.Tasks;
using ProgrammingAssignmentEngine;
using Ninject;
using ProgrammingAssignmentCore;

namespace ProgrammingAssignment
{
    class Program
    {
        private static IPrimeNumberGeneratorEngine _primeNumberGeneratorEngine;
        private static IStringReverseEngine _stringReverseEngine;
        private static ILogger _logger;
        private bool _running = true;
        static void Main(string[] args)
        {
            Program program = new Program();
            while (program._running)
            {
                var kernel = MainModule.CreateKernel();
                _primeNumberGeneratorEngine = kernel.Get<IPrimeNumberGeneratorEngine>();
                _stringReverseEngine = kernel.Get<IStringReverseEngine>();
                _logger = kernel.Get<ILogger>();
                _logger.Log(LogLevel.Info, "\n\n\nType P and hit enter to run prime number generator Algorithm");
                _logger.Log(LogLevel.Info, "\n Type R and hit enter to run string reverse Algorithm");
                _logger.Log(LogLevel.Info, "\n Type Q and hit enter to exit");
                string command;
                command = Console.ReadLine();
                switch (command)
                {
                    case "P":
                        GeneratePrime();
                        break;

                    case "R":
                        StringReverse();
                        break;

                    case "Q":
                        program._running = false;
                        break;

                    default:
                        _logger.Log(LogLevel.Error, "Unknown Command " + command);
                        break;
                }
            }
        }
        public static void GeneratePrime()
        {
            _logger.Log(LogLevel.Info, "\n\n\n Please enter a number to set a range for prime number generator");
            string line = Console.ReadLine();
            int size;
            if (int.TryParse(line, out size) && size > 0)
            {
                var task = Task.Run(() => _primeNumberGeneratorEngine.GeneratePrime(size));
                task.GetAwaiter().GetResult();
            }
            else
            {
                _logger.Log(LogLevel.Error, "\n You did not entered a valid number");
            }
        }
        public static void StringReverse()
        {
            _logger.Log(LogLevel.Info, "\n\n\n Please enter a string to reverse");
            string line = Console.ReadLine();
            if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
            {
                _stringReverseEngine.StringReverse(line);
            }
            else
            {
                _logger.Log(LogLevel.Error, "\n You did not entered a valid number");
            }
        }
    }    
}
