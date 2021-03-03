using System.Collections.Generic;
using System.Linq;
using EventHandler.Event.EventListImpl;
using MathNet.Numerics.LinearAlgebra;

namespace EventHandler.Event {
    public class EventList : _EventAccess {
        public sealed override Matrix<float> Events { get; set; }
        
        public EventList(Matrix<float> events) {
            Events = events;
        }

        public EventList(List<Event> events, int size) {
            Events = Matrix<float>.Build.Dense(size, 6);
        }

        public EventModify Modify => new EventModify(this);
        public EventExport Export => new EventExport(this);
        public EventPlot   Plot   => new EventPlot  (this);
        
        public IEnumerator<Vector<float>> GetEnumerator() {
            return Events.EnumerateRows().GetEnumerator();
        }
        
        // Looping Impl
        protected int Position;

        //IEnumerator
        public bool MoveNext() {
            Position++;
            return (Position < Events.RowCount);
        }

        //IEnumerable
        public void Reset() {
            Position = 0;
        }

        //IEnumerable
        public Vector<float> Current => Events.Row(Position);

    }
}