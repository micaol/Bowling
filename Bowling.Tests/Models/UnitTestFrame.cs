using System;
using Xunit;
using Bowling.Models;

namespace Bowling.Tests.Models
{
    public class UnitTestFrame
    {
        /// <summary>
        ///     Check that the frame is a strike when all the 10 pins are knocked down.
        /// </summary>
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

        /// <summary>
        ///     Check that a frame is a spare when all the 10 pins are knocked down on the second roll ONLY.
        /// </summary>
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
