using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventAddY : EventModifier
    {
        public Func<float, float> Func;

        public EventAddY(float value)
        {
            Func = f => value;
        }
        
        public EventAddY(Func<float, float> func)
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