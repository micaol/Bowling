using System;
using Microsoft.EntityFrameworkCore;
namespace Bowling.Models
{
    /// <summary>
    ///     A frame is a round where a player has up to two chances* to knock the pins. 
    /// </summary>
    /// <remarks> 
    ///     On the last frame the player may have a third chance if it's a spare or a strike.   
    /// </remarks>
    public class Frame
    {
        /// <summary>
        ///     Number of pins on the game.
        /// </summary>
        public const int MAX_PINS = 10;  

        /// <summary>
        ///     Number of frames for a Game.
        /// </summary>
        public const int N_FRAME = 10; 

        /// <summary>
        ///     Number of the frame. There is a maximum of 10 frames
        ///     It's initialised to -1. 
        /// </summary>
        private int frameNumber;
        
        /// <summary>
        ///     Number of pins knocked on the first ball.
        ///     It's initialised to -1.
        /// </summary>
        private int pinsDownFirstRoll;  

        /// <summary>
        ///     Number of pins knocked on the second ball.
        ///     It's initialised to -1.
        ///     The value can't be set if the frame is a strike.
        /// </summary>
        private int pinsDownSecondRoll;


        /// <summary>
        ///     Number of pins knocked down with the third ball.
        ///     It's initialised to -1. 
        ///     Used only for the last frame, in case of a strike or a spare. 
        /// </summary>
        private int pinsDownThirdRoll; 

        /// <summary>
        ///     True when all the rolls of this frame have been played.
        ///     - If it's a strike or, 
        ///     - If the second roll has been played.!-- 
        ///     Except for the last frame: 
        ///     - In case of a strike or a spare, the last frame will have a third roll.
        /// </summary>
        private bool isFrameOver; 

        /// <summary>
        ///     Set the pins knocked down on the first roll. 
        /// </summary>
        /// <value> Number of pins knocked on the first roll. </value>
        public int PinsDownFirstRoll 
        { 
            set 
            {   
                this.pinsDownFirstRoll = value;
                if(this.IsStrike() && this.frameNumber != N_FRAME)
                {
                    this.isFrameOver = true; 
                } 
            } 
            get { return this.pinsDownFirstRoll; }
        }

        /// <summary>
        ///     Set the pins knocked down on the second roll. 
        /// </summary>
        /// <value> Number of pins knocked on the second roll. </value>
        public int PinsDownSecondRoll 
        { 
            set 
            {
                this.pinsDownSecondRoll = value; 
                if((this.IsSpare() || this.IsStrike()) && frameNumber == N_FRAME)
                {
                    this.isFrameOver = false; 
                } 
                else
                {
                    this.isFrameOver = true; 
                }
            } 
            get { return this.pinsDownSecondRoll; }
        }

        /// <summary>
        ///     Set the pins knocked down on the third roll. 
        /// </summary>
        /// <value> Number of pins knocked on the third roll. </value>
        public int PinsDownThirdRoll 
        { 
            set 
            {
                this.pinsDownThirdRoll = value; 
                this.isFrameOver = true; 
            } 
            get { return this.pinsDownThirdRoll; } 
        }

        /// <summary>
        ///     Return true if the frame is over. 
        ///     There is no more roll to be played. 
        /// </summary>
        public bool IsFrameOver{ get {return this.isFrameOver; } }

        /// <summary>
        ///     Initialised the rolls to -1. 
        /// </summary>
        public Frame(int frameNumber)
        {
            this.frameNumber = frameNumber;
            this.pinsDownFirstRoll = -1;  
            this.pinsDownSecondRoll = -1; 
            this.pinsDownThirdRoll = -1; 
            this.isFrameOver = false; 
        }

        /// <summary>
        ///     Is the frame a strike?
        /// </summary>
        /// <returns> Return true when all the pins are knocked down on the first roll, false otherwise. </returns>
        public bool IsStrike()
        {
            return this.pinsDownFirstRoll == MAX_PINS; 
        }

        /// <summary>
        ///     Is the frame a spare?
        /// </summary>
        /// <returns> Return true when ALL the remaining pins are knocked down on the second roll, false otherwise. </returns>
        /// <remarks> Note that if it's a strike, there is only a single roll, so the method will return false.  </remarks>
        public bool IsSpare()
        {
            return (!this.IsStrike()) && (this.pinsDownSecondRoll + this.pinsDownFirstRoll) == MAX_PINS; 
        }
    }
}