using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScoring
{
    class BowlingGame
    {

        List<Frame> frames = new List<Frame>();

        public int Score(int[] rolls)
        {
            int score = 0;
            frames = ConvertToFrames(rolls);
            for(int i = 0; i < frames.Count(); i++)
            {
                int frameScore =

                score += ProcessFrame(i);
            }
            return score;
        }

        private List<Frame> ConvertToFrames(int[] rolls)
        {
            List<Frame> frames = new List<Frame>();
            Frame frame = new Frame();
            foreach(int roll in rolls)
            {
                if(!IsFinalFrame(frames.Count()) && frame.IsComplete())
                {
                    frames.Add(frame);
                    frame = new Frame();
                }
                frame.Add(roll);
            }
            frames.Add(frame); // Add the 10th frame
            return frames;
        }

        private bool IsFinalFrame(int currentFrame)
        {
            const int FRAMES_PER_GAME = 10;
            return (currentFrame + 1 == FRAMES_PER_GAME);
        }

        private int ProcessFrame(int ballIndex)
        {
            Frame frame = frames[ballIndex];
            int frameScore = frame.Sum();

            if (!IsFinalFrame(ballIndex))
            {
                Frame nextFrame = frames[ballIndex + 1];
                frameScore += ProcessNormalFrame(ballIndex);
            }
            else
            {
                frameScore += ProcessFinalFrame(frame);
            }
            return frameScore;
        }

        private int ProcessNormalFrame(int frameNumber)
        {
            int frameScore = 0;
            Frame frame = frames[frameNumber];
            Frame nextFrame = frames[frameNumber + 1];

            if (frame.IsStrike())
            {
                if (nextFrame.IsStrike())
                {
                    if(IsFinalFrame(frameNumber + 1))
                    {
                        frameScore = nextFrame.GetBall(1) + nextFrame.GetBall(2);
                    }
                    else
                    {
                        Frame farFrame = frames[frameNumber + 2];
                        frameScore += nextFrame.SpareBonus() + farFrame.SpareBonus();
                    }                    
                }
                else
                {
                    frameScore += nextFrame.StrikeBonus();
                }
            }
            else if (frame.IsSpare())
            {
                frameScore += nextFrame.SpareBonus();
            }
            return frameScore;
        }

        private int ProcessFinalFrame(Frame frame)
        {
            int frameScore = 0;
            if (frame.IsStrike())
            {
                frameScore += frame.GetBall(2) + frame.GetBall(3);
            }
            else if (frame.IsSpare())
            {
                frameScore += frame.GetBall(3);
            }
            return frameScore;
        }
    }
}
