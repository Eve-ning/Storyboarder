﻿using System;

namespace EventMaker.Modifiers {
    public class EventAddRotateXY : EventModifier {
        public Func<float, float> Radians;

        public EventAddRotateXY(float radians) {
            Radians = f => radians;
        }

        public EventAddRotateXY(Func<float, float> radiansFunc) {
            Radians = radiansFunc;
        }

        public override Event Modify(Event ev) {
            ev.Rotate(Radians(ev.T));
            return ev;
        }
    }
}