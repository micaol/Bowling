using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bowling.Controllers;
using Xunit;

namespace Bowling.Tests.Controllers
{
    public class UnitTestBowlingController
    {
        /// <summary>
        ///     Check that the DB (file) is cleared on call start. 
        /// </summary>
        [Fact]
        public void TestStart()
        {
            var controller = new BowlingController(); 
            controller.Start(); 
            Assert.True(File.Exists(DbFileController.filePath)); 
        }


        /// <summary>
        ///     Start a game, send the pins knocked down, and check the results returned by the API.
        /// </summary>
        [Fact]
        public void TestPlayAndScore()
        {
            var controller = new BowlingController(); 
            controller.Start(); 
            int[] game = {2,2,5,5,10,2,0,0,3}; 
            int[] excpectedResults = {4,24,36,38,41,-1,-1,-1,-1,-1}; 
            
            foreach(int roll in game)
            {
                controller.Play(roll);
            }            
            var apiResults = controller.Scores(); 
            Assert.True(Enumerable.SequenceEqual(apiResults.Value.Frames, excpectedResults));
            Assert.Equal(apiResults.Value.TotalScore, excpectedResults.Max());  
        }

        /// <summary>
        ///     Test controller exception handling. 
        /// </summary>
        [Fact]
        public void TestExceptionHandlingRangeFirstRoll()
        {
            var controller = new BowlingController(); 
            controller.Start(); 
            // The number of pin should be in the [0,10] range. 
            Assert.Throws<ArgumentOutOfRangeException>(() => controller.Play(12));
        }

        [Fact]
        public void TestExceptionHandlingRangeSecondRoll()
        {
            var controller = new BowlingController(); 
            controller.Start(); 
            controller.Play(3);  
             /// The maximum number of pins is 7 for the second roll.
            Assert.Throws<ArgumentOutOfRangeException>(() => controller.Play(8));
        }

        [Fact]
        public void TestExceptionHandlingGameOver()
        {
            var controller = new BowlingController(); 
            controller.Start(); 
            for(int i =0 ; i<12; i++)
            {
                controller.Play(10);
            }  
            // The game is over.
            Assert.Throws<ApplicationException>(() => controller.Play(8));
        }
    }
}