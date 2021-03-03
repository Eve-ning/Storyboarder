using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers {
    public class EventSetRotate : EventModifier {
        public Func<float, float> Radians;

        public EventSetRotate(float radians) {
            Radians = f => radians;
        }

        public EventSetRotate(Func<float, float> radiansFunc) {
            Radians = radiansFunc;
        }

        public override SpriteEvent Modify(SpriteEvent ev) {
            ev.R = Radians(ev.T);
            return ev;
        }
    }
}