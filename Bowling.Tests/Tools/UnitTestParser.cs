using System;
using System.Collections.Generic;
using Xunit;

namespace Bowling.Tests.Tools
{
    public class UnitTestParser
    {
        [Fact]
        public void TestGetIntegers()
        {
            string s = "2 3 10 0 5 "; 
            List<int> integerList = Bowling.Tools.Parser.GetIntegers(s);
            Assert.True(integerList[0] == 2); 
            Assert.True(integerList[1] == 3); 
            Assert.True(integerList[2] == 10); 
            Assert.True(integerList[3] == 0); 
            Assert.True(integerList[4] == 5); 
        }
    }
}