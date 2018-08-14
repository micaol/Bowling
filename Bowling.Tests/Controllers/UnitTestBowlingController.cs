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
            Assert.False(File.Exists(DbFileController.filePath)); 
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
    }
}