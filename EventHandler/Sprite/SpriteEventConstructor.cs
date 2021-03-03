using System;
using System.Collections.Generic;
using System.Linq;
using EventHandler.Modifiers;

namespace EventHandler.Sprite {
    /*
     * The premise of Path is that we will always follow this traversal:
     * X, S, R, F:  0 -> 0
     * Y:  1 -> 0
     * T: -1 -> 0 (T goes from negative so as to fix the ending time)
     *
     * Whenever we transform the Vector 
     */
    public class SpriteEventConstructor {
        // This vector is the vector 3 of X-Axis, Y-Axis, and the time.
        public SpriteEvent Begin = new SpriteEvent(0, 1, 1, 1, 0, -1);
        public SpriteEvent End = new SpriteEvent(0, 0, 1, 1, 0, 0);

        public SpriteEventConstructor() { }

        public SpriteEventConstructor(SpriteEvent begin, SpriteEvent end) {
            if (Begin.T >= End.T)
                throw new ArgumentException(
                    $"Begin {Begin.T}ms cannot be later than End {End.T}ms.");

            Begin = begin;
            End = end;
        }

        public SpriteEventConstructor(
            float xBegin = 0, float xEnd = 0,
            float yBegin = 1, float yEnd = 0,
            float sBegin = 1, float sEnd = 1,
            float aBegin = 1, float aEnd = 1,
            float rBegin = 0, float rEnd = 0,
            float tBegin = -1, float tEnd = 0
        ) :
            this(new SpriteEvent(xBegin, yBegin, sBegin, aBegin, rBegin, tBegin),
                new SpriteEvent(xEnd, yEnd, sEnd, aEnd, rEnd, tEnd)) { }

        /// <summary>
        /// Samples the Basic Path to generate discrete path anchors
        /// </summary>
        /// <param name="points">The number of points to generate</param>
        /// <returns>A List of Sampled Vector3 points</returns>
        public SpriteEventList SampleEvents(int points) {
            var evList = new SpriteEventList(new List<SpriteEvent>(), points + 1);
            var evDiff = Begin - End;

            for (var t = 0; t <= points; t++)
                evList.data.SetRow(t, (Begin - evDiff * t / points).data);

            return evList;
        }
    }
}