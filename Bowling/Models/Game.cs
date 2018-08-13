using System;
using System.Collections.Generic;

namespace Bowling.Models
{
    /// <summary>
    ///     The 10 pins bowling game. 
    ///     Pins: The ten "targets" at the far end of the lane that a bowler attempts to knock down by rolling a ball at them.
    ///     Frame: A single turn for a bowler, constituting one, two or three rolls, depending on pinfall.
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
            for(int i = 0; i< Frame.N_FRAME ; i++)
            {
                this.frames.Add(new Frame(i+1)); 
            }
        }

        /// <summary>
        ///     Create a new instance of a game from a list of pins knocked.
        /// </summary>
        public Game(List<int> rolls) : base()
        {
            foreach(int pinsKnocked in rolls)
            {
                this.PinsKnocked(pinsKnocked); 
            }
        }

        /// <summary>
        ///     Set the number of pins knocked by the latest ball. 
        /// </summary>
        /// <param name="nPins"> Number of pins knocked in the last roll. </param>
        public void PinsKnocked(int nPins)
        {
            if(nPins < 0 || nPins > 10)
            {
                throw new System.Exception("The number of pins should be between 0 and 10. \n You inputed: " + nPins); 
            }
            bool isGameOver = true; 
            foreach(Frame frame in this.frames)
            {
                if(!frame.IsFrameOver)
                {
                    this.SetKnockedPins(frame, nPins); 
                    isGameOver = false; 
                    break; 
                }
            }
            if(isGameOver)
            {
                throw new System.Exception("The game is over. Please restart a new game. "); 
            }
        }

        /// <summary>
        ///     Set the number of pins knocked on the last roll for this frame. 
        /// </summary>
        /// <param name="nPins"> Number of pins knocked. </param>
        /// <param name="frame"> Current frame being played. </param>
        public void SetKnockedPins(Frame frame, int nPins)
        {
            if(frame.PinsDownFirstRoll == -1)
            {
                frame.PinsDownFirstRoll = nPins; 
            } 
            else if(frame.PinsDownSecondRoll == -1)
            {
                frame.PinsDownSecondRoll = nPins; 
            } 
            else if(frame.PinsDownThirdRoll == -1)
            {
                frame.PinsDownThirdRoll = nPins; 
            }
        }

        /// <summary>
        ///     Calculate the current score for the given frame. 
        /// </summary>
        /// <param name="frameNumber"> Identifier of the frame. </param>
        /// <returns> Score of the frame. Return -1 if the score cannot be calculated yet. </returns>
        public int Score(int frameNumber){
            if(frameNumber > Frame.N_FRAME || frameNumber < 1)
            {
                throw new System.Exception("The frame number should be between 0 and 10. \n You inputed: " + frameNumber); 
            }

            int scoreCurrentFrame = ScoreCurrentFrame(frameNumber);
            if(scoreCurrentFrame == -1)
            {
                return -1; 
            } 
            if(frameNumber == 1)
            {
                return scoreCurrentFrame; 
            }
            return scoreCurrentFrame + this.Score(frameNumber-1); 
        }

        /// <summary>
        ///     Return the score of the current frame (without adding it to the score of the previous frames)
        /// </summary>
        /// <param name="frameNumber"> Current frame</param>
        /// <returns> Score of the current frame ONLY </returns>
        public int ScoreCurrentFrame(int frameNumber)
        {
            Frame frame = this.frames[frameNumber-1]; 
            if(!frame.IsFrameOver)
            {
                return -1;     
            }
            if(frameNumber == Frame.N_FRAME) // last frame
            {
                return this.getLastFrameScore(frame, frameNumber); 
            }     
            if(frame.IsStrike())
            {
                return this.getStrikeScore(frame, frameNumber); 
            }
            if(frame.IsSpare())
            {
                return this.getSpareScore(frame, frameNumber); 
            }
            return frame.PinsDownFirstRoll + frame.PinsDownSecondRoll; 
        }

        /// <summary>
        ///     Get the score of a spare for the current frame ONLY.
        ///     It needs the score of the next roll to be computed.
        /// </summary>
        /// <param name="frame"> Frame which score's has to be computed </param>
        /// <param name="frameNumber"> Frame number</param>
        /// <returns> Spare's score </returns>
        private int getSpareScore(Frame frame, int frameNumber)
        {
            Frame secondFrame = this.frames[frameNumber]; 
            if(secondFrame.PinsDownFirstRoll == -1)
            {
                return -1; 
            }
            return frame.PinsDownFirstRoll + frame.PinsDownSecondRoll + secondFrame.PinsDownFirstRoll; 
        }

        /// <summary>
        ///     Get the score of the strike for the current frame ONLY.
        ///     It needs the score of the next TWO rolls to be computed.
        /// </summary>
        /// <param name="frame"> Frame which score has to be calculated </param>
        /// <param name="frameNumber"> Frame number </param>
        /// <returns> Strike's score </returns>
        private int getStrikeScore(Frame frame, int frameNumber)
        {
            Frame secondFrame = this.frames[frameNumber]; 
            if(frameNumber == Frame.N_FRAME -1 && secondFrame.IsStrike())
            {
                if(secondFrame.PinsDownFirstRoll == -1 || secondFrame.PinsDownSecondRoll == -1)
                {
                    return -1; 
                }
                return frame.PinsDownFirstRoll + secondFrame.PinsDownFirstRoll + secondFrame.PinsDownSecondRoll; 
            }
            if(!secondFrame.IsFrameOver)
            {
                return -1; 
            }
            if(secondFrame.IsStrike())
            {
                Frame thirdFrame = this.frames[frameNumber + 1]; 
                if(!thirdFrame.IsFrameOver)
                {
                    return -1; 
                }
                return frame.PinsDownFirstRoll + secondFrame.PinsDownFirstRoll + thirdFrame.PinsDownFirstRoll; 
            }
            return frame.PinsDownFirstRoll + secondFrame.PinsDownFirstRoll + secondFrame.PinsDownSecondRoll; 
        }

        /// <summary>
        ///     Get the score of the last frame ONLY.
        ///     If it's a strike or a spare, the second AND the third rolls will be counted. 
        /// </summary>
        /// <param name="frame"> Frame which score has to be computed</param>
        /// <param name="frameNumber"> Frame number </param>
        /// <returns></returns>
        private int getLastFrameScore(Frame frame, int frameNumber)
        {
            if(frame.IsStrike() || frame.IsSpare())
            {
                return frame.PinsDownFirstRoll + frame.PinsDownSecondRoll + frame.PinsDownThirdRoll; 
            }
            return frame.PinsDownFirstRoll + frame.PinsDownSecondRoll; 
        }
    }
}