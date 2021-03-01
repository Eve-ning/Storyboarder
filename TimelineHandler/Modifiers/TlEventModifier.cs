using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using EventHandler.Sprite;

namespace TimelineHandler.Modifiers
{
    /// <summary>
    /// The difference between a Timeline Event Modifier and a normal Event Modifier is that
    /// 1. Event Modifier    will modify the Events before construction 
    /// 2. Timeline Modifier will modify the Events after construction.
    /// </summary>
    public abstract class TlEventModifier
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