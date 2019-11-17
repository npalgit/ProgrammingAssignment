using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingAssignmentCore;

namespace ProgrammingAssignmentTests.Extentions
{
    [TestClass()]
    public class ExtentionHelperTests
    {

        [TestMethod()]
        public void When_Pass_Prime_Number_Returns_True()
        {
            int primeNumber = 97;
            bool isPrime = primeNumber.IsPrime();
            Assert.AreEqual(true, isPrime);
        }
        [TestMethod()]
        public void When_Pass_Non_Prime_Number_Returns_False()
        {
            int primeNumber = 4;
            bool isPrime = primeNumber.IsPrime();
            Assert.AreEqual(false, isPrime);
        }

    }
}
