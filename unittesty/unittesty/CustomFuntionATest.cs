using FluentAssertions;
using NUnit.Framework;
using Projektdotestowania.CustomerFunction.Class;
using System.Collections.Generic;
namespace unittesty
{
    [TestFixture]
    public class CustomFuntionATest
    {
        [Test]
        //[TestCase("123456",new Dictionary<string, string>()
        //{
        //    ["ILOSC_ZN"] = "6",
        //    ["PRW_ZN"] = "1",
        //    ["OST_ZN"] = "6",
        //    ["LICZ"] = "0"
        //})]
        public void TestForMyFunction()
        {
            //Arrange
            Dictionary<string, string> result = new Dictionary<string, string>();
           // var customfunction = new ClassA();
            //ACT

           // result = customfunction.Funkcja1("123456");
            //ASSERT
            //result.Should().Equal(new Dictionary<string, string>
            //{
            //    ["ILOSC_ZN"]="6",
            //    ["PRW_ZN"]="1",
            //    ["OST_ZN"] = "6",
            //    ["LICZ"] = "0"
            //});
        }
    }
}
