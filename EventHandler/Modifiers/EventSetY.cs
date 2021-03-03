using System;
using EventHandler.Event;

namespace EventHandler.Modifiers {
    public class EventSetY : EventModifier {
        public Func<float, float> Func;

        public EventSetY(float value) {
            Func = f => value;
        }

        public EventSetY(Func<float, float> func) {
            Func = func;
        }

        public override Event.Event Modify(Event.Event ev) {
            ev.Y = Func(ev.T);
            return ev;
        }
    }
}