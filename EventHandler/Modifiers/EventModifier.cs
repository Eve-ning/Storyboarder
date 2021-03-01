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
            for (int i = 0; i < evList.events.RowCount; i++)
            {
                var ev = new SpriteEvent(evList.events.Row(i));
                evList.events.SetRow(i, Modify(ev).data.ToArray());
            }
            return evList;
        }
    }
}