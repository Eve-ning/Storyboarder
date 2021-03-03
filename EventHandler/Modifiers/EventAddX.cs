using System;
using EventHandler.Event;

namespace EventHandler.Modifiers {
    public class EventAddX : EventModifier {
        public Func<float, float> Func;

        public EventAddX(float value) {
            Func = f => value;
        }

        public EventAddX(Func<float, float> func) {
            Func = func;
        }

        public override Event.Event Modify(Event.Event ev) {
            ev.X += Func(ev.T);
            return ev;
        }
    }
}