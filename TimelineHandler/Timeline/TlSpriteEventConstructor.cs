using System;
using System.Collections.Generic;
using System.Linq;
using EventHandler.Sprite;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace TimelineHandler.Timeline
{
    public class TlSpriteEventConstructor
    {
        private List<SpriteEventConstructor> EventConstructors { get; set; }
        private float Begin { get; set; }
        private float End { get; set; }

        private float Length => End - Begin;

        public TlSpriteEventConstructor(List<SpriteEventConstructor> eventConstructors)
        {
            EventConstructors = eventConstructors;
        }

        public SpriteEventList Sample(int pts)
        {
            Matrix<float>[,] matrix = new Matrix<float>[EventConstructors.Count,1];
            for (var i = 0; i < EventConstructors.Count; i++)
            {
                matrix[i, 0] = EventConstructors[i].SampleTransform(pts).data;
            }
            var samples = Matrix<float>.Build.DenseOfMatrixArray(matrix);
            return new SpriteEventList(samples);
        }

    }
}