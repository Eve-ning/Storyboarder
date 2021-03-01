using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventScaleX : EventModifier
    {
        public Func<float, float> scale;

        public EventScaleX(float scaleConst)
        {
            scale = f => scaleConst;
        }

        /// <summary>
        ///     Creates a Scale X Modifier
        /// </summary>
        /// <param name="scaleFunc">Scale(Time) Function</param>
        public EventScaleX(Func<float, float> scaleFunc)
        {
            scale = scaleFunc;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.X *= scale(ev.T);
            return ev;
        }
    }
}