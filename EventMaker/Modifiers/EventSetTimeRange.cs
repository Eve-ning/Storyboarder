using System;

namespace EventMaker.Modifiers {
    public class EventSetTimeRange : EventModifier {
        public float FromBegin;
        public float FromEnd;
        public float ToBegin;
        public float ToEnd;

        /// <summary>
        ///     Scales the Current Time Range to another Range
        ///     Note that, by default, the EventConstructor will have fromBegin and toBegin as (-1, 0)
        /// </summary>
        /// <param name="toBegin">The Position to move begin to</param>
        /// <param name="toEnd">The Position to move end to</param>
        /// <param name="fromBegin">The Position to move begin from, default -1</param>
        /// <param name="fromEnd">The Position to move end from, default 0</param>
        /// <exception cref="ArgumentException">Throws when begin >= end</exception>
        public EventSetTimeRange(float toBegin, float toEnd,
            float fromBegin = -1f, float fromEnd = 0f) {
            if (toBegin >= toEnd)
                throw new ArgumentException(
                    $"ToBegin {toBegin} cannot be later than or equal to ToEnd {toEnd}");

            if (fromBegin >= fromEnd)
                throw new ArgumentException(
                    $"FromBegin {fromBegin} cannot be later than or equal to FromEnd {fromEnd}");

            FromBegin = fromBegin;
            FromEnd = fromEnd;
            ToBegin = toBegin;
            ToEnd = toEnd;
        }


        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.T = (ev.T - FromEnd) / (FromEnd - FromBegin) * (ToEnd - ToBegin) + ToEnd;
            return ev;
        }
    }
}