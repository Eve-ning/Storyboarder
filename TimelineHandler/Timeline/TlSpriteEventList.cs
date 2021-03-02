using System;
using System.Collections.Generic;
using System.Linq;
using EventHandler.Sprite;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace TimelineHandler.Timeline
{
    public class TlSpriteEventList
    {
        private List<SpriteEventList> EventLists { get; set; }
        private float Begin { get; set; }
        private float End { get; set; }

        private float Length => End - Begin;

        public TlSpriteEventList(List<SpriteEventList> eventLists)
        {
            EventLists = eventLists;
        }

        public SpriteEventList Join()
        {
            return Join(EventLists);
        }
        
        public static SpriteEventList Join(List<SpriteEventList> lists, bool sort = true)
        {
            Matrix<float>[,] ar = new Matrix<float>[lists.Count,1];
            for (int i = 0; i < lists.Count; i++)
                ar[i, 0] = lists[i].data;

            var eventList = new SpriteEventList(Matrix<float>.Build.DenseOfMatrixArray(ar));
            
            if (sort) return SortRows(eventList);
            // Else
            return eventList;
        }

        public static SpriteEventList SortRows(SpriteEventList eventList)
        {
            return 
                new (
                    Matrix<float>.Build.DenseOfRows(
                    eventList.data
                        .EnumerateRows()
                        .OrderBy(e => e[SpriteEventList.TCol]))
                );
        }

    }
}