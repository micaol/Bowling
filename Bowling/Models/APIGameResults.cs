using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Bowling.Models
{
    /// <summary>
    ///     Results of the 10 pins bowling game returned by the API.
    /// </summary>
    public class APIGameResults
    {
        /// <summary>
        ///     Build the results of The API.
        /// </summary>
        /// <param name="frames"></param>
        public APIGameResults(int[] frames)
        {
            this.Frames = frames;
            this.TotalScore = frames.Max(); 
        }


        /// <summary>
        ///     Score for each of the 10 frames.
        ///     The score is -1, if it could'nt be computed.
        /// </summary>
        public int[] Frames; 

        /// <summary>
        ///     Total score of the game. 
        ///     The score is -1 if it couldn't be computed. 
        /// </summary>
        public int TotalScore;
    }
}
