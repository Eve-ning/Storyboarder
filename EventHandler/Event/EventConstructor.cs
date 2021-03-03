using System;
using System.Collections.Generic;

namespace EventHandler.Event {
    /*
     * The premise of Path is that we will always follow this traversal:
     * X, S, R, F:  0 -> 0
     * Y:  1 -> 0
     * T: -1 -> 0 (T goes from negative so as to fix the ending time)
     *
     * Whenever we transform the Vector 
     */
    public class EventConstructor {
        // This vector is the vector 3 of X-Axis, Y-Axis, and the time.
        public Event Begin = new Event(0, 1, 1, 1, 0, -1);
        public Event End   = new Event(0, 0, 1, 1, 0, 0);

        public EventConstructor() { }

        public EventConstructor(Event begin, Event end) {
            if (Begin.T >= End.T)
                throw new ArgumentException(
                    $"Begin {Begin.T}ms cannot be later than End {End.T}ms.");

            Begin = begin;
            End = end;
        }

        public EventConstructor(
            float xBegin = 0, float xEnd = 0,
            float yBegin = 1, float yEnd = 0,
            float sBegin = 1, float sEnd = 1,
            float aBegin = 1, float aEnd = 1,
            float rBegin = 0, float rEnd = 0,
            float tBegin = -1, float tEnd = 0
        ) :
            this(new Event(xBegin, yBegin, sBegin, aBegin, rBegin, tBegin),
                new Event(xEnd, yEnd, sEnd, aEnd, rEnd, tEnd)) { }

        /// <summary>
        /// Samples the Basic Path to generate discrete path anchors
        /// </summary>
        /// <param name="points">The number of points to generate</param>
        /// <returns>A List of Sampled Vector3 points</returns>
        public EventList SampleEvents(int points) {
            var evList = new EventList(new List<Event>(), points + 1);
            var evDiff = Begin - End;

            for (var t = 0; t <= points; t++)
                evList.Events.SetRow(t, (Begin - evDiff * t / points).data);

            return evList;
        }
    }
}