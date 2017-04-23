using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projektdotestowania.CustomerFunction.Class;
using Projektdotestowania.CustomerFunction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unittesty
{
    class Program
    {

        Mock<IExternalServiceAdapter> mockService;
        static void Main(string[] args)
        {
        }
        public static Dictionary<string, string> shortLengthMessage = new Dictionary<string, string>
        {
            { "Message","String is too small" }
        };
        [SetUp]
        public void Setup()
        {
            mockService = new Mock<IExternalServiceAdapter>();
        }


        [Test]
        public void CustomerFunctionTest()
        {
            // Arrange
            mockService.Setup(x => x.IsOpenService(It.IsAny<ExternalService>())).Returns(true);

            var customerFunction = new Projektdotestowania.CustomerFunction.Class.ClassA(mockService.Object);
            
            // Act

            Dictionary<string, string> result = customerFunction.Funkcja1("TOTALE");

            // Assert

            result.Should().Equal(new Dictionary<string, string>
            {
                ["ILOSC_ZN"] = "6",
                ["PRW_ZN"] = "T",
                ["OST_ZN"] = "E",
                ["LICZ"] = "1"

            });
        }
        [Test]
        [TestCase("")]
        public void CustomerFunctionNullTest(string input)
        {
            try
            {
                // Arrange 
                mockService.Setup(x => x.IsOpenService(It.IsAny<ExternalService>())).Returns(true);
                var customer = new ClassA(mockService.Object);

                // Act
                Dictionary<string, string> result = customer.Funkcja1(input);

                // Assert
                result.Should().BeNull();
            }catch(NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }
        }
        [Test]
        [TestCase("abcd")]
        public void ShortLengthTest(string input)
        {
            // Arrange 
            mockService.Setup(x => x.IsOpenService(It.IsAny<ExternalService>())).Returns(true);
            var customer = new ClassA(mockService.Object);

            // Act
            Dictionary<string, string> result = customer.Funkcja1(input);

            // Assert
            result.Should().Equal(shortLengthMessage);
        }
        [Test]
        [TestCase("")]

        public void CustomerFunctionOnNull(string content)
        {
            try
            {
                // Arrange
                mockService.Setup(x => x.IsOpenService(It.IsAny<ExternalService>())).Returns(true);
                var customerFunction = new Projektdotestowania.CustomerFunction.Class.ClassA(mockService.Object);
                // Act

                Dictionary<string, string> result = customerFunction.Funkcja1(content);

                // Assert

                result.Should().BeNull();
            }catch(NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }
        }

        [Test, TestCase(false, "TOTALE", "Connection problem!")]
        public void ConnectionWithServerTest(bool connection, string content, string errorMsg)
        {
            // Arrange
            mockService.Setup(x => x.IsOpenService(It.IsAny<ExternalService>())).Returns(connection);
            var customerFunction = new Projektdotestowania.CustomerFunction.Class.ClassA(mockService.Object);
            // Act

            Action action = () => customerFunction.Funkcja1(content);

            // Assert

            action.ShouldThrow<Exception>().Where(e => e.Message.Equals(errorMsg));

        }
    }
}

