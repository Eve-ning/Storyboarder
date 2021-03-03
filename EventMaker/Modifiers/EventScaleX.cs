using System;

namespace EventMaker.Modifiers {
    public class EventScaleX : EventModifier {
        public Func<float, float> Func;

        public EventScaleX(float value) {
            Func = f => value;
        }

        public EventScaleX(Func<float, float> func) {
            Func = func;
        }

        public override Event Modify(Event ev) {
            ev.X *= Func(ev.T);
            return ev;
        }
    }
}