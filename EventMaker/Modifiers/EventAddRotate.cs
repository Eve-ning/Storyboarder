using System;

namespace EventMaker.Modifiers {
    public class EventAddRotate : EventModifier {
        public Func<float, float> Radians;

        public EventAddRotate(float radians) {
            Radians = f => radians;
        }

        public EventAddRotate(Func<float, float> radiansFunc) {
            Radians = radiansFunc;
        }

        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.R += Radians(ev.T);
            return ev;
        }
    }
}