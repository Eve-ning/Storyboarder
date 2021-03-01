using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.Sprite
{
    public class SpriteEventList
    {
        public List<SpriteEvent> events;
        private int _position;
        
        public SpriteEventList(List<SpriteEvent> events)
        {
            this.events = events;
        }

        public void Add(SpriteEvent ev)
        {
            events.Add(ev);
        }
        
        public List<float> X() { return events.Select(ev => ev.X).ToList(); }
        public List<float> Y() { return events.Select(ev => ev.Y).ToList(); }
        public List<float> S() { return events.Select(ev => ev.S).ToList(); }
        public List<float> F() { return events.Select(ev => ev.A).ToList(); }
        public List<float> R() { return events.Select(ev => ev.R).ToList(); }
        public List<float> T() { return events.Select(ev => ev.T).ToList(); }
        
        public IEnumerator<SpriteEvent> GetEnumerator()
        {
            return ((IEnumerable<SpriteEvent>) events).GetEnumerator();
        }
        //IEnumerator
        public bool MoveNext()
        {
            _position++;
            return (_position < events.Count);
        }
        //IEnumerable
        public void Reset()
        {
            _position = 0;
        }
        //IEnumerable
        public SpriteEvent Current
        {
            get { return events[_position];}
        }

        public SpriteEvent this[int index]
        {
            get { return events[index];  }
            set { events[index] = value;  }
        }
    }
}