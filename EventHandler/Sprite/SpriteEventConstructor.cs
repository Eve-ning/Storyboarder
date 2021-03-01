using System.Collections.Generic;
using System.Numerics;
using EventHandler.Modifiers;
using EventHandler.Sprite;

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
        
        public List<EventModifier> Modifiers = new List<EventModifier>();

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
                evList.events.SetRow(t, (Init - evDiff * t / points).data);

            return evList;
        }

        public SpriteEventList SampleTransform(int points)
        {
            var evList = SampleEvents(points);
            foreach (var modifier in Modifiers) {
                evList = modifier.ModifyAll(evList);
            }

            return evList;
        }

    }
}
