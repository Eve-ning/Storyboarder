using System;
using EventHandler.Event;

namespace EventHandler.Modifiers {
    public class EventAddRotate : EventModifier {
        public Func<float, float> Radians;

        public EventAddRotate(float radians) {
            Radians = f => radians;
        }

        public EventAddRotate(Func<float, float> radiansFunc) {
            Radians = radiansFunc;
        }

        public override Event.Event Modify(Event.Event ev) {
            ev.R += Radians(ev.T);
            return ev;
        }
    }
}