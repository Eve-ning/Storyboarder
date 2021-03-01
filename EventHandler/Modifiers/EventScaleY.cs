using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventScaleY : EventModifier
    {
        public Func<float, float> scale;

        public EventScaleY(float scaleConst)
        {
            scale = f => scaleConst;
        }

        /// <summary>
        ///     Creates a Scale Y Modifier
        /// </summary>
        /// <param name="scaleFunc">Scale(Time) Function</param>
        public EventScaleY(Func<float, float> scaleFunc)
        {
            scale = scaleFunc;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.Y *= scale(ev.T);
            return ev;
        }
    }
}