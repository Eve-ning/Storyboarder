using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers {
    public class EventSetAlpha : EventModifier {
        public Func<float, float> Func;

        public EventSetAlpha(float value) {
            Func = f => value;
        }

        public EventSetAlpha(Func<float, float> func) {
            Func = func;
        }

        public override SpriteEvent Modify(SpriteEvent ev) {
            ev.A = Func(ev.T);
            return ev;
        }
    }
}