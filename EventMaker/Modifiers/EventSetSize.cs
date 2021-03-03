using System;

namespace EventMaker.Modifiers {
    public class EventSetSize : EventModifier {
        public Func<float, float> Func;

        public EventSetSize(float value) {
            Func = f => value;
        }

        public EventSetSize(Func<float, float> func) {
            Func = func;
        }

        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.S = Func(ev.T);
            return ev;
        }
    }
}