using FuncAppPoc.Domain.Enum;
using FuncAppPoc.Domain.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace UnitTests.ModelTests
{
    [TestFixture]
    public class ParagraphModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestParagraphModel()
        {
            var message = new ParaMessage
            {
                Title = "Treasure Island",
                Published = new DateTime(1722, 3, 23),
                Author = "Robert Lewis Stephenson",
                Type = BookType.Fiction,
                Sample = "Long John Silver is a terrible man and prirate. He wore a long black coat, parot and sword. He is very scary."                
            };

            Assert.AreEqual(message.Year, 1722);            
        }

        [Test]
        public void TestParagraphModelJson()
        {
            var message = new ParaMessage
            {
                Title = "Treasure Island",
                Published = new DateTime(1722, 3, 23),
                Author = "Robert Lewis Stephenson",
                Type = BookType.Fiction,
                Sample = "Long John Silver is a terrible man and prirate. He wore a long black coat, parot and sword. He is very scary."
            };

            var json = JsonConvert.SerializeObject(message, Formatting.Indented);

            var deserialisedMessage = JsonConvert.DeserializeObject<ParaMessage>(json);

            Assert.AreEqual(message.Author, deserialisedMessage.Author);
            Assert.AreEqual(message.Year, 1722);
            Assert.AreEqual(message.Created, deserialisedMessage.Created);
        }

        [Test]
        public void TestParagraphModelGuardTest()
        {
            var message = new ParaMessage("Treasure Island", "Robert L Stephenson");

            message.Published = new DateTime(1722, 3, 23);
            message.Type = BookType.Fiction;
            message.Sample = "Some Sample";
            
            var json = JsonConvert.SerializeObject(message, Formatting.Indented);

            var deserialisedMessage = JsonConvert.DeserializeObject<ParaMessage>(json);

            Assert.AreEqual(message.Author, deserialisedMessage.Author);
            Assert.AreEqual(message.Year, 1722);
            Assert.AreEqual(message.Created, deserialisedMessage.Created);
        }
    }
}