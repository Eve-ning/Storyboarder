using System;
using Community.CsharpSqlite;
using EventHandler.Sprite;

namespace EventHandler.Modifiers {
    /// <summary>
    /// Aligns all rotations to point towards the origin.
    /// </summary>
    public class EventAlignRotate : EventModifier {
        public float RadiansOffset;

        public EventAlignRotate(float radiansOffset = 0f) {
            RadiansOffset = radiansOffset;
        }

        public override SpriteEvent Modify(SpriteEvent ev) {
            try {
                var div = ev.Y / ev.X;
                ev.R = (float) (- Math.Atan(div) + Math.PI / 2) + RadiansOffset;
                if (ev.X < 0) ev.R += (float) Math.PI;
            }
            catch (DivideByZeroException exc) {
                ev.R = RadiansOffset;
            }
            return ev;
        }
    }
}