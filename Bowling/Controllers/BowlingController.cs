using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bowling.Models;
using Bowling.Tools;

namespace Bowling.Controllers
{
    /// <summary>
    ///     Controller for the Bowling API.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {

        /// <summary>
        ///     Initialise a new 10 pins bowling game. 
        ///     API Call: 
        ///         api/bowling/start
        /// </summary>
        [HttpPost]
        [ActionName("start")]
        public void Start()
        {
            DbFileController.StartDB();
        }

        /// <summary>
        ///     Set the number of pins knocked for the last roll. 
        ///     API Call: 
        ///         api/bowling/play/5
        /// </summary>
        /// <param name="nPinsKnocked"> Number of pins knocked.</param>
        [HttpPost("{nPinsKnocked}")]
        [ActionName("play")]
        public void Play(int nPinsKnocked)
        {
            if(!System.IO.File.Exists(DbFileController.filePath))
            {
                throw new ApplicationException(ErrorMessage.GAME_NOT_STARTED); 
            }

            // Check if the model is consistant before saving.
            // Will throw an exception if not.  
            this.tryUpdateModel(nPinsKnocked); 

            DbFileController.Save(nPinsKnocked); 
        }

        /// <summary>
        ///     Get the score of each of the frame.
        ///       
        /// </summary>
        /// <returns>
        ///     The score of each of the frame. 
        ///     -1 if the score of the frame can not be computed yet.
        /// </returns>
        [HttpGet]
        [ActionName("scores")]
        public ActionResult<APIGameResults> Scores()
        {
            string scoreString = DbFileController.Load(); 
            List<int> rolls = Tools.Parser.GetIntegers(scoreString); 
            Game game = new Game(rolls); 
            var apiResults = new APIGameResults(game.GetFramesScore().ToArray()); 
            return apiResults;
        }

        /// <summary>
        ///     Before the update in DB, check it the data is consistant.
        /// </summary>
        /// <param name="nPins"> Number of pins knocked. </param>
        private void tryUpdateModel(int nPins)
        {
            string scoreString = DbFileController.Load(); 
            List<int> rolls = Tools.Parser.GetIntegers(scoreString); 
            Game game = new Game(rolls);
            // Throw an exception if the model is invalid.  
            game.PinsKnocked(nPins); 
        }
    }
}
