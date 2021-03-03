using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers {
    public class EventScaleY : EventModifier {
        public Func<float, float> Func;

        public EventScaleY(float value) {
            Func = f => value;
        }

        public EventScaleY(Func<float, float> func) {
            Func = func;
        }

        public override SpriteEvent Modify(SpriteEvent ev) {
            ev.Y *= Func(ev.T);
            return ev;
        }
    }
}