using System;

namespace EventMaker.Modifiers {
    public class EventSetY : EventModifier {
        public Func<float, float> Func;

        public EventSetY(float value) {
            Func = f => value;
        }

        public EventSetY(Func<float, float> func) {
            Func = func;
        }

        public override Event Modify(Event ev) {
            ev.Y = Func(ev.T);
            return ev;
        }
    }
}