using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers {
    public class EventSetSize : EventModifier {
        public Func<float, float> Func;

        public EventSetSize(float value) {
            Func = f => value;
        }

        public EventSetSize(Func<float, float> func) {
            Func = func;
        }

        public override SpriteEvent Modify(SpriteEvent ev) {
            ev.S = Func(ev.T);
            return ev;
        }
    }
}