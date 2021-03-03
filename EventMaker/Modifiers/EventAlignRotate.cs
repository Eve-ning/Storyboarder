using System;

namespace EventMaker.Modifiers {
    /// <summary>
    /// Aligns all rotations to point towards the origin.
    /// </summary>
    public class EventAlignRotate : EventModifier {
        public Func<float, float> RadiansFunc;

        public EventAlignRotate(float radians = 0f) {
            RadiansFunc = f => radians;
        }

        public EventAlignRotate(Func<float, float> radiansFunc) {
            RadiansFunc = radiansFunc;
        }

        public override Event Modify(Event ev) {
            try {
                var div = ev.Y / ev.X;
                ev.R += (float) (- Math.Atan(div) + Math.PI / 2) + RadiansFunc(ev.T);
                if (ev.X < 0) ev.R += (float) Math.PI;
            }
            catch (DivideByZeroException exc) {
                ev.R = RadiansFunc(ev.T);
            }
            return ev;
        }
    }
}