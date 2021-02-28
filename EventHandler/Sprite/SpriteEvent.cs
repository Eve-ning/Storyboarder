using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace EventHandler.Sprite
{
    public class SpriteEvent
    {
        public const int Length = 6;
        public Vector<float> data;
        private int _position = -1;
        public SpriteEvent(float x = 0, float y = 1, float s = 1,
                           float f = 0, float r = 0, float t = -1)
        {
            float[] a = {x, y, s, f, r, t};
            data = Vector<float>.Build.Dense(a);
        }

        public SpriteEvent(Vector<float> data)
        {
            this.data = data;
        }

        public static SpriteEvent operator -(SpriteEvent a, SpriteEvent b)
        {
            return new (a.data - b.data);
        }
        public static SpriteEvent operator +(SpriteEvent a, SpriteEvent b)
        {
            return new (a.data + b.data);
        }
        public static SpriteEvent operator /(SpriteEvent a, SpriteEvent b)
        {
            return new (a.data / b.data);
        }
        public static SpriteEvent operator *(SpriteEvent a, SpriteEvent b)
        {
            return new (a.data * b.data);
        }

        public static SpriteEvent operator -(SpriteEvent a, dynamic b)
        {
            return new (a.data - b);
        }
        public static SpriteEvent operator +(SpriteEvent a, dynamic b)
        {
            return new (a.data + b);
        }
        public static SpriteEvent operator /(SpriteEvent a, dynamic b)
        {
            return new (a.data / b);
        }
        public static SpriteEvent operator *(SpriteEvent a, dynamic b)
        {
            return new (a.data * b);
        }

        public IEnumerable<float> Attributes()
        {
            yield return X;
            yield return Y;
            yield return S;
            yield return F;
            yield return R;
            yield return T;
        }

        public float X { get { return data[0]; } set { data[0] = value; } }
        public float Y { get { return data[1]; } set { data[1] = value; } }
        public float S { get { return data[2]; } set { data[2] = value; } }
        public float F { get { return data[3]; } set { data[3] = value; } }
        public float R { get { return data[4]; } set { data[4] = value; } }
        public float T { get { return data[5]; } set { data[5] = value; } }
        
        public void Rotate(float radians)
        {
            float x = X; // We have a separate variable as X dynamically changes Y
            X = (float) (X * Math.Cos(radians) - Y * Math.Sin(radians));
            Y = (float) (x * Math.Sin(radians) + Y * Math.Cos(radians));
            R = radians;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(S)}: {S}, {nameof(F)}: {F}, {nameof(R)}: {R}, {nameof(T)}: {T}";
        }
    }
}