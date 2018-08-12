using System;
using Xunit;
using Bowling.Models;

namespace Bowling.Tests.Models
{
    public class UnitTestFrame
    {
        [Fact]
        public void TestIsStrike()
        {
            var frame = new Frame(1); 
            frame.PinsDownFirstRoll = 10; 
            Assert.True(frame.IsStrike());    

            frame = new Frame(1); 
            frame.PinsDownFirstRoll = 5; 
            Assert.False(frame.IsStrike());    
        }

        [Fact]
        public void TestIsSpare()
        {
            var frame = new Frame(1); 
            frame.PinsDownFirstRoll = 3;
            frame.PinsDownSecondRoll = 7; 
            Assert.True(frame.IsSpare()); 

            frame = new Frame(1); 
            frame.PinsDownFirstRoll = 10;
            frame.PinsDownSecondRoll = 7; 
            Assert.False(frame.IsSpare()); 
            
            frame = new Frame(1); 
            frame.PinsDownFirstRoll = 2;
            frame.PinsDownSecondRoll = 7; 
            Assert.False(frame.IsSpare()); 
        }
    }
}
