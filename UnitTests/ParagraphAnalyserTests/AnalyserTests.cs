using FuncAppPoc.ParagraphProcessor.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTests.ParagraphAnalyserTests
{
    [TestFixture]
    public class AnalyserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSimpleParagraph()
        {
            var sample = "Long John Silver is a terrible man and prirate. He wore a long black coat, parot and sword. He is very scary.";

            var mockLogger = new Mock<ILogger<ParagraphAnalyser>>();
            var analyser = new ParagraphAnalyser(mockLogger.Object);

            var result = analyser.Analyse(sample);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.MaxWordCount, 9);
            Assert.AreEqual(result.LongestSentence, "Long John Silver is a terrible man and prirate");
        }

        /*
        [TestCase("N", ExpectedResult = true)]
        [TestCase("E", ExpectedResult = true)]
        [TestCase("S", ExpectedResult = true)]
        [TestCase("W", ExpectedResult = true)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("Q", ExpectedResult = false)]
        public bool TestValidCommand(string command)
        {
            var handler = new RobotHandler();

            return handler.IsValidCommand(command);
        }
        */
    }
}