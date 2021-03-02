using System;
using System.Collections.Generic;
using System.Linq;
using EventHandler.Modifiers;

namespace EventHandler.Sprite
{
    /*
     * The premise of Path is that we will always follow this traversal:
     * X, S, R, F:  0 -> 0
     * Y:  1 -> 0
     * T: -1 -> 0 (T goes from negative so as to fix the ending time)
     *
     * Whenever we transform the Vector 
     */
    public class SpriteEventConstructor
    {
        // This vector is the vector 3 of X-Axis, Y-Axis, and the time.
        public SpriteEvent Init  = new SpriteEvent(0,1,1,1,0,-1);
        public SpriteEvent Final = new SpriteEvent(0,0,1,1,0,0);


        public SpriteEventConstructor(float begin = -1f, float end = 0f)
        {
            if (begin >= end) 
                throw new ArgumentException($"Begin {begin}ms cannot be later than End {end}ms.");

            Init.T = begin;
            Final.T = end;
        }

        /// <summary>
        /// Samples the Basic Path to generate discrete path anchors
        /// </summary>
        /// <param name="points">The number of points to generate</param>
        /// <returns>A List of Sampled Vector3 points</returns>
        public SpriteEventList SampleEvents(int points)
        {
            var evList = new SpriteEventList(new List<SpriteEvent>(), points + 1);
            var evDiff = Init - Final;

            for (var t = 0; t <= points; t++)
                evList.data.SetRow(t, (Init - evDiff * t / points).data);

            return evList;
        }
    }
}
