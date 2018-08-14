using System;
using System.Collections.Generic;

namespace Bowling.Tools
{
    /// <summary>
    ///     Common error messages.
    /// </summary>
    public static class ErrorMessage
    {   
        /// <summary>
        ///     The game did not start.
        /// </summary>
        public const string GAME_NOT_STARTED = "The game was not started."; 
        /// <summary>
        ///     The game is over.
        /// </summary>
        public const string GAME_IS_OVER = "The game is over. Please restart a new game (api/controller/start). "; 
        /// <summary>
        ///     An error occured on our side. 
        /// </summary>
        public const string OUR_SIDE = "An error occured on our side, it was logged and will be dealt with ASAP. "; 
    }
}