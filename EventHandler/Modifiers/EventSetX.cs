using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventSetX : EventModifier
    {
        public Func<float, float> Func;

        public EventSetX(float value)
        {
            Func = f => value;
        }
        public EventSetX(Func<float, float> func)
        {
            Func = func;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.X = Func(ev.T);
            return ev;
        }
    }
}