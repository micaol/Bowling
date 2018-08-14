using System;
using Xunit;
using Bowling.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Tests.Models
{
    public class UnitTestGame
    {
        /// <summary>
        /// 3    -> _ : The frame is not over yet. 
        /// 3 3  -> 6  : The frame is over. 
        /// </summary>

        [Fact]
        public void TestScore1()
        {
            var game = new Game();
            game.PinsKnocked(3);
            Assert.True(game.Score(1) == -1); // The frame is not over yet.  
    
            game.PinsKnocked(3);
            Assert.True(game.Score(1) == 6); // The frame is over.  
            
        }

        /// <summary>
        ///     1-1/1-1/1-1/1-1/1-1/1-1/1-1/1-1/1-1/1-1
        ///     ->
        ///     2/4/6/8/10/12/14/16/18/20
        /// </summary>
        [Fact]
        public void TestScoreAllFrame(){
            var game = new Game(); 
            for(int i = 0; i<10 ; i++)
            {
                game.PinsKnocked(1); 
                game.PinsKnocked(1); 
            }
            for(int i = 0; i<10 ; i++)
            {
                Assert.True(game.Score(i+1) == 2*(i+1)); // The frame is over.
            }
        }

        /// <summary>
        ///     1 -> _
        ///     1-9 -> _
        ///     1-9/10 -> 10
        /// </summary>
        [Fact]
        public void TestScoreSpare(){
            Game game = new Game();             
            game.PinsKnocked(1); 
            Assert.True(game.Score(1) == -1); // The frame is not over.
            game.PinsKnocked(9); 
            Assert.True(game.Score(1) == -1); // It's a spare, it needs the next roll to be calculated. 
            game.PinsKnocked(10); 
            Assert.True(game.Score(1) == 20); // The score is (1 + 9 + 10) for the first frame.              
        }
        
        /// <summary>
        ///     0-0/0-0/0-0/0-0/0-0/0-0/0-0/0-0/3-7/10-10-10
        ///     ->
        ///     0/0/0/0/0/0/0/0/20/50
        /// </summary>
        [Fact]
        public void TestScoreSpareNineFrame()
        {
            var game = new Game(); 
            for(int i = 0; i<8 ; i++)
            {
                game.PinsKnocked(0); 
                game.PinsKnocked(0); 
            }
            // Spare on the 9th game
            game.PinsKnocked(3); 
            game.PinsKnocked(7); 
            // Strike on the last game
            game.PinsKnocked(10); 
            game.PinsKnocked(10); 
            game.PinsKnocked(10); 
            
            Assert.True(game.Score(9) == 20);
            Assert.True(game.Score(10) == (50));
        }


        /// <summary>
        ///     0-0/0-0/0-0/0-0/0-0/0-0/0-0/0-0/3-7-5
        ///     ->
        ///     0/0/0/0/0/0/0/0/0/15
        /// </summary>
        [Fact]
        public void TestScoreSpareLastFrame()
        {
            var game = new Game(); 
            for(int i = 0; i<9 ; i++)
            {
                game.PinsKnocked(0); 
                game.PinsKnocked(0); 

            }
            // Spare on the last frame. 
            game.PinsKnocked(3); 
            game.PinsKnocked(7); 
            // Extra ball for a spare on the last frame. 
            game.PinsKnocked(5);  
            
            Assert.True(game.Score(10) == 15);
        }

        /// <summary>
        ///     Check the results of an entire game played.
        /// </summary>
        [Fact]
        public void TestFrameScore()
        {
            int[] enteredFrames = {1,1,2,2,3,3,4,4,5,5,4,6,3,7,2,8,1,9,10,0,10};
            int[] results ={2,6,12,20,34,47,59,70,90,110};  
            var list = new List<int>(); 
            list.AddRange(enteredFrames); 
            Game game = new Game(list); 
            Assert.True(game.GetFramesScore().ToArray().SequenceEqual(results)); 
        }

    }
}