using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventHandler.Modifiers;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace EventHandler.Sprite {
    public class SpriteEventList {
        public Matrix<float> data;
        private int _numberOfColumns = 6; // XYSART
        private int _position;

        public const int XCol = 0;
        public const int YCol = 1;
        public const int SCol = 2;
        public const int ACol = 3;
        public const int RCol = 4;
        public const int TCol = 5;

        public SpriteEventList(Matrix<float> data) {
            this.data = data;
        }

        public SpriteEventList(List<SpriteEvent> events, int size) {
            this.data = Matrix<float>.Build.Dense(size, 6);
        }

        public Vector<float> X {
            get => data.Column(XCol);
            set => data.SetColumn(XCol, value);
        }

        public Vector<float> Y {
            get => data.Column(YCol);
            set => data.SetColumn(YCol, value);
        }

        public Vector<float> S {
            get => data.Column(SCol);
            set => data.SetColumn(SCol, value);
        }

        public Vector<float> A {
            get => data.Column(ACol);
            set => data.SetColumn(ACol, value);
        }

        public Vector<float> R {
            get => data.Column(RCol);
            set => data.SetColumn(RCol, value);
        }

        public Vector<float> T {
            get => data.Column(TCol);
            set => data.SetColumn(TCol, value);
        }

        public int Length() {
            return data.RowCount;
        }

        public float TimeBegin() {
            return T.Min();
        }

        public float TimeEnd() {
            return T.Max();
        }

        public float TimeDuration() {
            return TimeEnd() - TimeBegin();
        }

        public IEnumerator<Vector<float>> GetEnumerator() {
            return data.EnumerateRows().GetEnumerator();
        }

        //IEnumerator
        public bool MoveNext() {
            _position++;
            return (_position < data.RowCount);
        }

        //IEnumerable
        public void Reset() {
            _position = 0;
        }

        //IEnumerable
        public Vector<float> Current => data.Row(_position);

        public SpriteEvent this[int index] {
            get => new(data.Row(index));
            set => data.SetRow(index, value.data);
        }

        public SpriteEventModify Modify => new SpriteEventModify(this);
    }
}