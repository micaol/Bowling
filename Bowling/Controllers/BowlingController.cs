using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bowling.Models;

namespace Bowling.Controllers
{
    /// <summary>
    ///     Controller for the Bowling API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {

        /// <summary>
        ///     Initialise a new 10 pins bowling game. 
        /// </summary>
        /// <returns> Id of the new Game. </returns>
        [HttpGet]
        public ActionResult<int> StartNewGame()
        {
            return 0;
        }

        /// <summary>
        ///     Get the score of each of the frame and the score of the game. 
        /// </summary>
        /// <param name="Id"> Id of the game</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int[]> GetScores(int Id)
        {
            var scores = new List<int>().ToArray(); 
            return scores;
        }

        /// <summary>
    ///         Set the number of pins knocked for the last roll. 
        /// </summary>
        /// <param name="id"> Id of the game. </param>
        /// <param name="nPinsKnocked"> Number of pins knocked.</param>
        [HttpPut("{id}")]
        public void Put(int id, int nPinsKnocked)
        {

        }
    }
}
