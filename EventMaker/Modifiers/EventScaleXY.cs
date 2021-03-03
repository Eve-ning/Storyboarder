using System;

namespace EventMaker.Modifiers {
    public class EventScaleXY : EventModifier {
        public Func<float, float> Func;

        public EventScaleXY(float value) {
            Func = f => value;
        }

        public EventScaleXY(Func<float, float> func) {
            Func = func;
        }

        public override Event Modify(Event ev) {
            ev.X *= Func(ev.T);
            ev.Y *= Func(ev.T);
            return ev;
        }
    }
}