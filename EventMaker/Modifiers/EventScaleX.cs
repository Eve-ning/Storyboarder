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

        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.X *= Func(ev.T);
            return ev;
        }
    }
}