using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Bowling.Models
{
    /// <summary>
    ///     The 10 pins bowling game. 
    ///     Roll: 
    ///     Frame: 
    /// </summary>
    public class Game
    {
        /// <summary>
        ///     List of the game frames. 
        /// </summary>
        private List<Frame> frames;

        /// <summary>
        ///     Create a new instance of a game.
        /// </summary>
        public Game()
        {
            this.frames = new List<Frame>(); 
        }

        /// <summary>
        ///     Set the number of pins knocked by the latest ball. 
        /// </summary>
        /// <param name="nPins"> Number of pins knocked in the last roll. </param>
        public void PinsKnocked(int nPins)
        {
            // TODO: Write the code for the method below.  
            throw new System.Exception(); 
        }

        /// <summary>
        ///     Calculate the current score for the given frame. 
        /// </summary>
        /// <param name="frameNumber"> Identifier of the frame. </param>
        /// <returns> Score of the frame. Return -1 if the score cannot be calculated yet. </returns>
        public int Score(int frameNumber){
            // TODO: Write the code for the method below.  
            throw new System.Exception(); 
        }

    }
}