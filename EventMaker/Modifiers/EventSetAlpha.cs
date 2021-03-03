using System;

namespace EventMaker.Modifiers {
    public class EventSetAlpha : EventModifier {
        public Func<float, float> Func;

        public EventSetAlpha(float value) {
            Func = f => value;
        }

        public EventSetAlpha(Func<float, float> func) {
            Func = func;
        }

        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.A = Func(ev.T);
            return ev;
        }
    }
}