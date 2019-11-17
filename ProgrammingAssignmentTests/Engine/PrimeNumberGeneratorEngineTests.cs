using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingAssignmentEngine;
using Ninject;
using System.Threading.Tasks;
using ProgrammingAssignmentCore;
using Moq;
using System;

namespace ProgrammingAssignment.Tests
{
    [TestClass()]
    public class PrimeNumberGeneratorEngineTests
    {
        private static readonly int[] SAMPLE_PRIMES = {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 1021
        };
        private static readonly int[] SAMPLE_NonPrime = {
            4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27, 28,
            30, 32, 33, 34, 35, 36, 38, 39, 40, 42, 44, 45, 46, 48, 49, 50
        };
        private static IPrimeNumberGeneratorEngine engine;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var kernel = new StandardKernel();
            var mockLogger = new Mock<ILogger>();
            kernel.Unbind<ILogger>();
            kernel.Bind<ILogger>().ToConstant(mockLogger.Object);
            kernel.Load<EngineModule>();
            mockLogger.Setup(x => x.Log(It.IsAny<LogLevel>() ,It.IsAny<string>(), It.IsAny<Exception>()));
            engine = kernel.Get<IPrimeNumberGeneratorEngine>();

        }

        [TestMethod()]
        public void testIsPrime()
        {
            foreach (int i in SAMPLE_PRIMES)
            {
                var task = Task.Run(() => engine.ComputeAndDisplayPrimeNUmber(i));
                bool result = task.GetAwaiter().GetResult();
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod()]
        public void testIsNotPrime()
        {
            foreach (int i in SAMPLE_NonPrime)
            {
                var task = Task.Run(() => engine.ComputeAndDisplayPrimeNUmber(i));
                bool result = task.GetAwaiter().GetResult();
                Assert.AreEqual(false, result);
            }
        }
    }
}