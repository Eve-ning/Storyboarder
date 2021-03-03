using System;

namespace EventMaker.Modifiers {
    public class EventSetX : EventModifier {
        public Func<float, float> Func;

        public EventSetX(float value) {
            Func = f => value;
        }

        public EventSetX(Func<float, float> func) {
            Func = func;
        }

        public override Event Modify(Event ev) {
            ev.X = Func(ev.T);
            return ev;
        }
    }
}