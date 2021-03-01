using System;
using EventHandler.Sprite;

namespace TimelineHandler.Timeline
{
    public class TlSpriteEventConstructor
    {
        private SpriteEventConstructor EventConstructor { get; set; }
        private float Begin { get; set; }
        private float End { get; set; }

        private float Length => End - Begin;

        public TlSpriteEventConstructor(SpriteEventConstructor eventConstructor, float begin, float end)
        {
            EventConstructor = eventConstructor;
            if (begin >= end) 
                throw new ArgumentException($"Begin {begin}ms cannot be later than End {end}ms.");
            
            Begin = begin;
            End = end;
        }

        public SpriteEventList Sample(int pts)
        {
            var samples = EventConstructor.SampleEvents(pts);
            samples.T = samples.T * Length + End;
            return samples;
        }

        /// <summary>
        /// Sets the Length of the Event by moving the Begin Variable
        /// </summary>
        /// <param name="length"></param>
        public void SetLengthMovingBegin(float length)
        {
            Begin = End - Length;
        }
        
        /// <summary>
        /// Sets the Length of the Event by moving the End Variable
        /// </summary>
        /// <param name="length"></param>
        public void SetLengthMovingEnd(float length)
        {
            End = Begin + length;
        }
    }
}