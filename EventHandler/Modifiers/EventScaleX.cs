﻿using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventScaleX : EventModifier
    {
        public Func<float, float> Func;

        public EventScaleX(float value)
        {
            Func = f => value;
        }
        public EventScaleX(Func<float, float> func)
        {
            Func = func;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.X *= Func(ev.T);
            return ev;
        }
    }
}