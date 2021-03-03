using System;

namespace EventMaker.Modifiers {
    public class EventAddX : EventModifier {
        public Func<float, float> Func;

        public EventAddX(float value) {
            Func = f => value;
        }

        public EventAddX(Func<float, float> func) {
            Func = func;
        }

        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.X += Func(ev.T);
            return ev;
        }
    }
}