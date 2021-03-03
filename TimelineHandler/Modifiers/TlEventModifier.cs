using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using EventHandler.Event;

namespace TimelineHandler.Modifiers
{
    /// <summary>
    /// The difference between a Timeline Event Modifier and a normal Event Modifier is that
    /// 1. Event Modifier    will modify the Events before construction 
    /// 2. Timeline Modifier will modify the Events after construction.
    /// </summary>
    public abstract class TlEventModifier
    {
        public abstract Event Modify(Event ev);

        public EventList ModifyAll(EventList evList)
        {
            for (int i = 0; i < evList.Events.RowCount; i++)
            {
                var ev = new Event(evList.Events.Row(i));
                evList.Events.SetRow(i, Modify(ev).data.ToArray());
            }
            return evList;
        }
    }
}