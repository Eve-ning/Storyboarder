using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventSetY : EventModifier
    {
        public Func<float, float> Func;

        public EventSetY(float value)
        {
            Func = f => value;
        }
        public EventSetY(Func<float, float> func)
        {
            Func = func;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.Y += Func(ev.T);
            return ev;
        }
    }
}