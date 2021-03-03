using System;
using EventHandler.Event;

namespace EventHandler.Modifiers {
    public class EventAddY : EventModifier {
        public Func<float, float> Func;

        public EventAddY(float value) {
            Func = f => value;
        }

        public EventAddY(Func<float, float> func) {
            Func = func;
        }

        public override Event.Event Modify(Event.Event ev) {
            ev.Y += Func(ev.T);
            return ev;
        }
    }
}