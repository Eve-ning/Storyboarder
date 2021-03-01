using System;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventAlpha : EventModifier
    {
        public Func<float, float> Alpha;

        public EventAlpha(float alphaConst)
        {
            Alpha = f => alphaConst;
        }

        /// <summary>
        ///     Creates a Scale X Modifier
        /// </summary>
        /// <param name="alphaFunc">Scale(Time) Function</param>
        public EventAlpha(Func<float, float> alphaFunc)
        {
            Alpha = alphaFunc;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.A = Alpha(ev.T);
            return ev;
        }
    }
}