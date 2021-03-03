using EventHandler.Event;
using MathNet.Numerics.LinearAlgebra;

namespace EventHandler.Modifiers {
    public abstract class EventModifier {
        public abstract Event.Event Modify(Event.Event ev);

        public Vector<float> Modify(Vector<float> vector) {
            return Modify(new Event.Event(vector)).data;
        }

        public Matrix<float> ModifyAll(Matrix<float> matrix) {
            return ModifyAll(new EventList(matrix)).Events;
        }

        public EventList ModifyAll(EventList evList) {
            for (var i = 0; i < evList.Events.RowCount; i++) {
                var ev = new Event.Event(evList.Events.Row(i));
                evList.Events.SetRow(i, Modify(ev).data.ToArray());
            }

            return evList;
        }
    }
}