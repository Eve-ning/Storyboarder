using System.Collections.Generic;
using System.Linq;
using EventMaker.EventListImpl;
using MathNet.Numerics.LinearAlgebra;

namespace EventMaker {
    public class EventList : _EventAccess {
        public sealed override Matrix<float> Events { get; set; }
        
        public EventList(Matrix<float> events) {
            Events = events;
        }

        public EventList(List<EventMaker.Event> events, int size) {
            Events = Matrix<float>.Build.Dense(size, 6);
        }
        
        public static EventList Join(List<EventList> lists, bool sort = true)
        {
            Matrix<float>[,] ar = new Matrix<float>[lists.Count,1];
            for (int i = 0; i < lists.Count; i++)
                ar[i, 0] = lists[i].Events;

            var eventList = new EventList(Matrix<float>.Build.DenseOfMatrixArray(ar));
            
            if (sort) return SortRows(eventList);
            // Else
            return eventList;
        }
        
        public static EventList SortRows(EventList eventList)
        {
            return 
                new (
                    Matrix<float>.Build.DenseOfRows(
                        eventList.Events
                            .EnumerateRows()
                            .OrderBy(e => e[_EventAccess.TCol]))
                );
        }
        
        public EventModify Modify => new EventModify(this);
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