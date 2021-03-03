using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace EventMaker.EventListImpl {
    public abstract class _EventAccess {
        public abstract Matrix<float> Events { get; set; }
       
        public const int XCol = 0;
        public const int YCol = 1;
        public const int SCol = 2;
        public const int ACol = 3;
        public const int RCol = 4;
        public const int TCol = 5;
        
        public Vector<float> X {
            get => Events.Column(XCol);
            set => Events.SetColumn(XCol, value);
        }

        public Vector<float> Y {
            get => Events.Column(YCol);
            set => Events.SetColumn(YCol, value);
        }

        public Vector<float> S {
            get => Events.Column(SCol);
            set => Events.SetColumn(SCol, value);
        }

        public Vector<float> A {
            get => Events.Column(ACol);
            set => Events.SetColumn(ACol, value);
        }

        public Vector<float> R {
            get => Events.Column(RCol);
            set => Events.SetColumn(RCol, value);
        }

        public Vector<float> T {
            get => Events.Column(TCol);
            set => Events.SetColumn(TCol, value);
        }

        public int Length() {
            return Events.RowCount;
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

        public global::EventMaker.Event this[int index] {
            get => new(Events.Row(index));
            set => Events.SetRow(index, value.data);
        }


    }
}