using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;
using TimelineHandler.Timeline;

namespace TimelineHandlerUT
{
    using EvCon = SpriteEventConstructor;

    public class Tests
    {
        private String dir = "tests/TlEventHandlerTests/";
        private int _pts = 100;
        private TlSpriteEventList _tlCon;
        private double delta = 0.0001f;
        
        public void PlotPoints(SpriteEventList eventList)
        {
            EventPlotter.PlotPoints(eventList,
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }
        
        [SetUp]
        public void Setup()
        {
            System.IO.Directory.CreateDirectory(dir);
        }

        [Test]
        public void TestTlWorkflow()
        {
            var constructor = new SpriteEventConstructor();
            var sampleOut = TlSpriteEventList.Join(new List<SpriteEventList>()
            {
                constructor
                    .SampleEvents(_pts)
                    .Modify
                    .Rotate(t => (t + 1) * (float) Math.PI)
                    .ScaleX(0.25f).ScaleY(0.25f)
                    .TimeRange(2000, 3000).EventList,

                constructor
                    .SampleEvents(_pts)
                    .Modify
                    .Rotate(t => (t + 1) * (float) Math.PI)
                    .ScaleX(0.75f).ScaleY(0.75f)
                    .TimeRange(1000, 2000).EventList
            });
            sampleOut.Modify.Rotate(0.25f * (float) Math.PI);
            PlotPoints(sampleOut);
        }

        
    }
}