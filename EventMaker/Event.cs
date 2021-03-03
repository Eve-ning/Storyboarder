using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace EventMaker
{
    public class Event
    {
        public const int Length = 6;
        public Vector<float> data;
        private int _position = -1;
        
        /// <param name="x">X Axis</param>
        /// <param name="y">Y Axis</param>
        /// <param name="s">Scale</param>
        /// <param name="a">Alpha</param>
        /// <param name="r">Rotate</param>
        /// <param name="t">Time</param>
        public Event(float x = 0, float y = 1, float s = 1,
                           float a = 1, float r = 0, float t = -1)
        {
            float[] ar = {x, y, s, a, r, t};
            data = Vector<float>.Build.Dense(ar);
        }

        public Event(Vector<float> data)
        {
            this.data = data;
        }

        public static Event operator -(Event a, Event b)
        {
            return new (a.data - b.data);
        }
        public static Event operator +(Event a, Event b)
        {
            return new (a.data + b.data);
        }
        public static Event operator /(Event a, Event b)
        {
            return new (a.data / b.data);
        }
        public static Event operator *(Event a, Event b)
        {
            return new (a.data * b.data);
        }

        public static Event operator -(Event a, dynamic b)
        {
            return new (a.data - b);
        }
        public static Event operator +(Event a, dynamic b)
        {
            return new (a.data + b);
        }
        public static Event operator /(Event a, dynamic b)
        {
            return new (a.data / b);
        }
        public static Event operator *(Event a, dynamic b)
        {
            return new (a.data * b);
        }

        public IEnumerable<float> Attributes()
        {
            yield return X;
            yield return Y;
            yield return S;
            yield return A;
            yield return R;
            yield return T;
        }

        public float X { get { return data[0]; } set { data[0] = value; } }
        public float Y { get { return data[1]; } set { data[1] = value; } }
        public float S { get { return data[2]; } set { data[2] = value; } }
        public float A { get { return data[3]; } set { data[3] = value; } }
        public float R { get { return data[4]; } set { data[4] = value; } }
        public float T { get { return data[5]; } set { data[5] = value; } }
        
        public void Rotate(float radians)
        {
            float x = X; // We have a separate variable as X dynamically changes Y
            X = (float) (X * Math.Cos(radians) - Y * Math.Sin(radians));
            Y = (float) (x * Math.Sin(radians) + Y * Math.Cos(radians));
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(S)}: {S}, {nameof(A)}: {A}, {nameof(R)}: {R}, {nameof(T)}: {T}";
        }
    }
}