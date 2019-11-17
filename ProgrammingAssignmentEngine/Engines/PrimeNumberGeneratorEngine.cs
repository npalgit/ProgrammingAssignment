using ProgrammingAssignmentCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingAssignmentEngine
{
    public interface IPrimeNumberGeneratorEngine
    {
        Task GeneratePrime(int size);
        Task<bool> ComputeAndDisplayPrimeNUmber(int number);
        void DisplayPrime(int number);
    }
    public class PrimeNumberGeneratorEngine : IPrimeNumberGeneratorEngine
    {
        public ILogger _logger;
        public PrimeNumberGeneratorEngine(ILogger logger)
        {
            _logger = logger;
        }
        public  async Task GeneratePrime(int size)
        {
            var list = Enumerable.Range(1, size).Select(i => i).ToList();
            await Task.Run(async () =>
            {
                foreach (var chunks in list.Batch(100))
                {
                    await Task.WhenAll(chunks.Select(i => ComputeAndDisplayPrimeNUmber(i)));
                }
            });
        }

        public Task<bool> ComputeAndDisplayPrimeNUmber(int number)
        {
            return Task.Run(() =>
            {
                if (number.IsPrime())
                {
                    DisplayPrime(number);
                    return true;
                }
                return false;
            });
        }
        public void DisplayPrime(int i)
        {
            string _message = $"Prime number {i}.";
            _logger.Log(LogLevel.Info, _message);
        }
    }
}
