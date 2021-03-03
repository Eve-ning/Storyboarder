using System;
using System.Numerics;

namespace EventMaker.Modifiers {
    /// <summary>
    /// Fits XY of the effect into another boundary
    ///
    /// E.g. Mapping (0-1, 0-1) to (0-320, 0-640)
    /// == (FLX-FUX, FLY-FUY) to (TLX-TUX, TLY-TUY)
    ///
    /// 
    /// </summary>
    public class EventFitXY : EventModifier {

        public float fromLowerX;
        public float fromUpperX;
        public float fromLowerY;
        public float fromUpperY;
        public float toLowerX;
        public float toUpperX;
        public float toLowerY;
        public float toUpperY;

        public EventFitXY(
            float fromLowerX, float fromUpperX,
            float fromLowerY, float fromUpperY,
            float toLowerX, float toUpperX,
            float toLowerY, float toUpperY) {
            this.fromLowerX = fromLowerX;
            this.fromUpperX = fromUpperX;
            this.fromLowerY = fromLowerY;
            this.fromUpperY = fromUpperY;
            this.toLowerX = toLowerX;
            this.toUpperX = toUpperX;
            this.toLowerY = toLowerY;
            this.toUpperY = toUpperY;
        }


        public override Event Modify(Event ev) {
            ev.X = (ev.X - fromLowerX) / (fromUpperX - fromLowerX) *
                   (toUpperX - toLowerX) + toLowerX;
            ev.Y = (ev.Y - fromLowerY) / (fromUpperY - fromLowerY) *
                   (toUpperY - toLowerY) + toLowerY;
            return ev;
        }
    }
}