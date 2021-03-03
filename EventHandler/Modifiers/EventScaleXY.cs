using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers {
    public class EventScaleXY : EventModifier {
        public Func<float, float> Func;

        public EventScaleXY(float value) {
            Func = f => value;
        }

        public EventScaleXY(Func<float, float> func) {
            Func = func;
        }

        public override SpriteEvent Modify(SpriteEvent ev) {
            ev.X *= Func(ev.T);
            ev.Y *= Func(ev.T);
            return ev;
        }
    }
}