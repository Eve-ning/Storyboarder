using System;

namespace EventMaker.Modifiers {
    public class EventAddY : EventModifier {
        public Func<float, float> Func;

        public EventAddY(float value) {
            Func = f => value;
        }

        public EventAddY(Func<float, float> func) {
            Func = func;
        }

        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.Y += Func(ev.T);
            return ev;
        }
    }
}