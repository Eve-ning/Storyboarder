using System.ComponentModel;
using EventHandler.Sprite;

namespace TimelineHandler.Timeline
{
    public class TlSpriteEvent
    {
        private SpriteEventHandler EventHandler { get; set; }
        private float Begin { get; set; }
        private float End { get; set; }

        private float Length => End - Begin;

        public TlSpriteEvent(SpriteEventHandler eventHandler, float begin, float end)
        {
            EventHandler = eventHandler;
            Begin = begin;
            End = end;
        }

        public SpriteEventList Sample(int pts)
        {
            var samples = EventHandler.SampleEvents(pts);
            var t = samples.T;
            t[0] += 100;
            
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