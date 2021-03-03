using EventHandler.Sprite;
using MathNet.Numerics.LinearAlgebra;

namespace EventHandler.Modifiers {
    public abstract class EventModifier {
        public abstract SpriteEvent Modify(SpriteEvent ev);

        public Vector<float> Modify(Vector<float> vector) {
            return Modify(new SpriteEvent(vector)).data;
        }

        public Matrix<float> ModifyAll(Matrix<float> matrix) {
            return ModifyAll(new SpriteEventList(matrix)).data;
        }

        public SpriteEventList ModifyAll(SpriteEventList evList) {
            for (var i = 0; i < evList.data.RowCount; i++) {
                var ev = new SpriteEvent(evList.data.Row(i));
                evList.data.SetRow(i, Modify(ev).data.ToArray());
            }

            return evList;
        }
    }
}