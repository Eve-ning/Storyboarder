using MathNet.Numerics.LinearAlgebra;

namespace EventMaker.Modifiers {
    public abstract class EventModifier {
        public abstract Event Modify(Event ev);

        public Vector<float> Modify(Vector<float> vector) {
            return Modify(new Event(vector)).data;
        }

        public Matrix<float> ModifyAll(Matrix<float> matrix) {
            return ModifyAll(new EventList(matrix)).Events;
        }

        public EventList ModifyAll(EventList evList) {
            for (var i = 0; i < evList.Events.RowCount; i++) {
                var ev = new Event(evList.Events.Row(i));
                evList.Events.SetRow(i, Modify(ev).data.ToArray());
            }

            return evList;
        }
    }
}