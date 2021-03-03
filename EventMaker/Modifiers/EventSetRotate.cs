using System;

namespace EventMaker.Modifiers {
    public class EventSetRotate : EventModifier {
        public Func<float, float> Radians;

        public EventSetRotate(float radians) {
            Radians = f => radians;
        }

        public EventSetRotate(Func<float, float> radiansFunc) {
            Radians = radiansFunc;
        }

        public override Event Modify(Event ev) {
            ev.R = Radians(ev.T);
            return ev;
        }
    }
}