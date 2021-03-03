using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using EventHandler.Event;
using EventHandler.Event.EventListImpl;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Objects;

namespace TimelineHandler.Timeline
{
    public class TlSpriteEventList
    {
        private List<EventList> EventLists { get; set; }
        private float Begin { get; set; }
        private float End { get; set; }

        private float Length => End - Begin;

        public TlSpriteEventList(List<EventList> eventLists)
        {
            EventLists = eventLists;
        }

        public EventList Join()
        {
            return Join(EventLists);
        }
        
        public static EventList Join(List<EventList> lists, bool sort = true)
        {
            Matrix<float>[,] ar = new Matrix<float>[lists.Count,1];
            for (int i = 0; i < lists.Count; i++)
                ar[i, 0] = lists[i].Events;

            var eventList = new EventList(Matrix<float>.Build.DenseOfMatrixArray(ar));
            
            if (sort) return SortRows(eventList);
            // Else
            return eventList;
        }

        public static EventList SortRows(EventList eventList)
        {
            return 
                new (
                    Matrix<float>.Build.DenseOfRows(
                    eventList.Events
                        .EnumerateRows()
                        .OrderBy(e => e[_EventAccess.TCol]))
                );
        }

        public static void Export() {
            Storyboard sb = new Storyboard();
            var spr = new StoryboardSprite(Origins.Centre, "sprite.png", 0, 0);
            spr.Commands.Commands.Add(
                new Command(
                    CommandType.Movement, Easing.None,
                    0, 100,
                    Vector2.One * 4, Vector2.One));
            sb.ForegroundLayer.Add(spr);
            sb.Save("out.osb");
        }

    }
}