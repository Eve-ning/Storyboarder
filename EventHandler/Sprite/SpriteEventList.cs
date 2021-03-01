using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace EventHandler.Sprite
{
    public class SpriteEventList
    {
        public Matrix<float> events;
        private int _numberOfColumns = 6; // XYSART
        private int _position;
        
        public const int XCol = 0;
        public const int YCol = 1;
        public const int SCol = 2;
        public const int ACol = 3;
        public const int RCol = 4;
        public const int TCol = 5;
        
        public SpriteEventList(Matrix<float> events)
        {
            this.events = events;
        }

        public SpriteEventList(List<SpriteEvent> events, int size)
        {
            this.events = Matrix<float>.Build.Dense(size, 6);
        }

        public Vector<float> X { get { return events.Column(XCol); } set { events.SetColumn(XCol, value); } }       
        public Vector<float> Y { get { return events.Column(YCol); } set { events.SetColumn(YCol, value); } }       
        public Vector<float> S { get { return events.Column(SCol); } set { events.SetColumn(SCol, value); } }       
        public Vector<float> A { get { return events.Column(ACol); } set { events.SetColumn(ACol, value); } }       
        public Vector<float> R { get { return events.Column(RCol); } set { events.SetColumn(RCol, value); } }       
        public Vector<float> T { get { return events.Column(TCol); } set { events.SetColumn(TCol, value); } }       
        public IEnumerator<Vector<float>> GetEnumerator()
        {
            return events.EnumerateRows().GetEnumerator();
        }
        //IEnumerator
        public bool MoveNext()
        {
            _position++;
            return (_position < events.RowCount);
        }
        //IEnumerable
        public void Reset()
        {
            _position = 0;
        }
        //IEnumerable
        public Vector<float> Current
        {
            get { return events.Row(_position);}
        }

        public SpriteEvent this[int index]
        {
            get { return new (events.Row(index));  }
            set { events.SetRow(index, value.data);  }
        }
    }
}