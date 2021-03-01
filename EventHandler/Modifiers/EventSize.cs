using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventSize : EventModifier
    {
        public Func<float, float> Size;

        public EventSize(float sizeConst)
        {
            Size = f => sizeConst;
        }

        /// <summary>
        ///     Creates a Scale X Modifier
        /// </summary>
        /// <param name="sizeFunc">Scale(Time) Function</param>
        public EventSize(Func<float, float> sizeFunc)
        {
            Size = sizeFunc;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.S = Size(ev.T);
            return ev;
        }
    }
}