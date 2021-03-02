﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventHandler.Modifiers;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace EventHandler.Sprite
{
    public class SpriteEventList
    {
        public Matrix<float> data;
        private int _numberOfColumns = 6; // XYSART
        private int _position;
        
        public const int XCol = 0;
        public const int YCol = 1;
        public const int SCol = 2;
        public const int ACol = 3;
        public const int RCol = 4;
        public const int TCol = 5;
        
        public SpriteEventList(Matrix<float> data)
        {
            this.data = data;
        }

        public SpriteEventList(List<SpriteEvent> events, int size)
        {
            this.data = Matrix<float>.Build.Dense(size, 6);
        }

        public Vector<float> X { get { return data.Column(XCol); } set { data.SetColumn(XCol, value); } }       
        public Vector<float> Y { get { return data.Column(YCol); } set { data.SetColumn(YCol, value); } }       
        public Vector<float> S { get { return data.Column(SCol); } set { data.SetColumn(SCol, value); } }       
        public Vector<float> A { get { return data.Column(ACol); } set { data.SetColumn(ACol, value); } }       
        public Vector<float> R { get { return data.Column(RCol); } set { data.SetColumn(RCol, value); } }       
        public Vector<float> T { get { return data.Column(TCol); } set { data.SetColumn(TCol, value); } }       
        public IEnumerator<Vector<float>> GetEnumerator()
        {
            return data.EnumerateRows().GetEnumerator();
        }
        //IEnumerator
        public bool MoveNext()
        {
            _position++;
            return (_position < data.RowCount);
        }
        //IEnumerable
        public void Reset()
        {
            _position = 0;
        }
        //IEnumerable
        public Vector<float> Current
        {
            get { return data.Row(_position);}
        }

        public SpriteEvent this[int index]
        {
            get { return new (data.Row(index));  }
            set { data.SetRow(index, value.data);  }
        }
        
        public SpriteEventModify Modify
        {
            get { return new SpriteEventModify(this); }
        }

        public static SpriteEventList Join(List<SpriteEventList> lists)
        {
            Matrix<float>[,] ar = new Matrix<float>[lists.Count,1];
            for (int i = 0; i < lists.Count; i++)
                ar[i, 0] = lists[i].data;

            return new SpriteEventList(Matrix<float>.Build.DenseOfMatrixArray(ar));
        }
    }
}