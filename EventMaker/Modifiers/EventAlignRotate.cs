using System;
using System.Numerics;

namespace EventMaker.Modifiers {
    /// <summary>
    /// Aligns all rotations to point towards the origin.
    /// </summary>
    public class EventAlignRotate : EventModifier {
        public Func<float, float> RadiansFunc;
        public Func<float, Vector2> OriginFunc;

        public EventAlignRotate(float radians = 0f, Vector2 origin = default(Vector2)) {
            RadiansFunc = f => radians;
            OriginFunc = f => origin;
        }

        public EventAlignRotate(Func<float, float> radiansFunc, Vector2 origin = default(Vector2)) {
            RadiansFunc = radiansFunc;
            OriginFunc = f => origin;
        }

        public override Event Modify(Event ev) {
            try {
                ev.R += (float)
                    (- Math.Atan2(ev.Y - OriginFunc(ev.T).Y,
                                  ev.X - OriginFunc(ev.T).X) + Math.PI / 2) + RadiansFunc(ev.T);
            }
            catch (DivideByZeroException exc) {
                ev.R = RadiansFunc(ev.T);
            }
            return ev;
        }
    }
}