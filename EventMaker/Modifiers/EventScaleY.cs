using System;

namespace EventMaker.Modifiers {
    public class EventScaleY : EventModifier {
        public Func<float, float> Func;

        public EventScaleY(float value) {
            Func = f => value;
        }

        public EventScaleY(Func<float, float> func) {
            Func = func;
        }

        public override global::EventMaker.Event Modify(global::EventMaker.Event ev) {
            ev.Y *= Func(ev.T);
            return ev;
        }
    }
}