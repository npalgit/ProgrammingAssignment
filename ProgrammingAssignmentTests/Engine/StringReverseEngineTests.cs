using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using ProgrammingAssignmentCore;
using ProgrammingAssignmentEngine;
using System;

namespace ProgrammingAssignmentTests.Engine
{

    [TestClass()]
    public class StringReverseEngineTests
    {
        private static IStringReverseEngine engine;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var kernel = new StandardKernel();
            var mockLogger = new Mock<ILogger>();
            kernel.Unbind<ILogger>();
            kernel.Bind<ILogger>().ToConstant(mockLogger.Object);
            kernel.Load<EngineModule>();
            mockLogger.Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<string>(), It.IsAny<Exception>()));
            engine = kernel.Get<IStringReverseEngine>();

        }

        [TestMethod()]
        public void Reversed_String_When_Input_String_Is_PAssed_As_Parameter()
        {
            string originalString = "ABCD";
            string expectedResult = "DCBA";
            string reverseResult = engine.StringReverse(originalString);
            Assert.AreEqual(expectedResult, reverseResult);
        }
    }
}
