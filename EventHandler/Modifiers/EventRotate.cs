using System;
using System.Collections.Generic;
using System.Numerics;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public class EventRotate : EventModifier
    {
        public Func<float, float> radians;

        public EventRotate(float radiansConst)
        {
            radians = f => radiansConst;
        }

        /// <summary>
        /// Creates a Rotate Modifier
        /// </summary>
        /// <param name="radiansFunc">Rotation(Time) Function</param>
        public EventRotate(Func<float, float> radiansFunc)
        {
            radians = radiansFunc;
        }

        public override SpriteEvent Modify(SpriteEvent ev)
        {
            ev.Rotate(radians(ev.T));
            return ev;
        }
    }
}