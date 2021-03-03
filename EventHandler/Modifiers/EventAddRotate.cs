﻿using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers {
    public class EventAddRotate : EventModifier {
        public Func<float, float> Radians;

        public EventAddRotate(float radians) {
            Radians = f => radians;
        }

        public EventAddRotate(Func<float, float> radiansFunc) {
            Radians = radiansFunc;
        }

        public override SpriteEvent Modify(SpriteEvent ev) {
            ev.R += Radians(ev.T);
            return ev;
        }
    }
}