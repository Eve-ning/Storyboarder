using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using EventHandler.Sprite;

namespace EventHandler.Modifiers
{
    public abstract class EventModifier
    {
        public abstract SpriteEvent Modify(SpriteEvent ev);

        public SpriteEventList ModifyAll(SpriteEventList evList)
        {
            return new (evList.events.Select(Modify).ToList());
        }
    }
}