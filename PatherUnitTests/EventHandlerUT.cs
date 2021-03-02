using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace EventHandlerUT
{
    public class Tests
    {
        private String dir = "tests/PatherUnitTest/";
        private int _pts = 100;
        private SpriteEventConstructor _eventConstructor;
        [SetUp]
        public void Setup()
        {
            _eventConstructor = new SpriteEventConstructor();
            System.IO.Directory.CreateDirectory(dir);
        }

        public void PlotPoints(EventModifier modifier, int ptsMul = 1)
        {
            EventPlotter.PlotPoints(
                _eventConstructor
                    .SampleEvents(_pts * ptsMul)
                    .Modify
                    .WithModifiers(modifier)
                    .EventList,
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }
        public void PlotPoints(List<EventModifier> modifiers, int ptsMul = 1)
        {
            EventPlotter.PlotPoints(
                _eventConstructor
                    .SampleEvents(_pts * ptsMul)
                    .Modify
                    .WithModifiers(modifiers)
                    .EventList,
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }
        
        public void PlotPoints(SpriteEventList eventList)
        {
            EventPlotter.PlotPoints(eventList,
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }

        [Test]
        public void TestBasicLinear()
        {
            PlotPoints(new List<EventModifier>(){});
        }
        
        [Test]
        public void TestBasicPipelining()
        {
            PlotPoints(_eventConstructor
                .SampleEvents(_pts)
                .Modify.Alpha(t => -t).EventList);
        }
        
        [Test]
        public void TestBasicLinearRotation()
        {
            PlotPoints(new EventRotate((float) Math.PI * 3));
        }
        
        [Test]
        public void TestBasicRotation()
        {
            PlotPoints(new EventRotate(t => (float) (16 * Math.PI * t)));
        }
        
        [Test]
        public void TestBasicLinearScaleX()
        {
            PlotPoints(new List<EventModifier>()
            {
                new EventRotate((float) Math.PI / 2),
                new EventScaleX(0.5f)
            });
        }
        
        [Test]
        public void TestBasicLinearScaleY()
        {
            PlotPoints(new EventScaleY(0.5f));
        }
        
        [Test]
        public void TestBasicScaleX()
        {

            PlotPoints(new List<EventModifier>()
            {
                new EventRotate((float) Math.PI / 2),
                new EventScaleX(t => -t * 2)
            });
        }
        
        [Test]
        public void TestBasicScaleY()
        {
            PlotPoints(new EventScaleY(t => -t * 2));
        }      
        
        [Test]
        public void TestBasicSize()
        {
            PlotPoints(new EventSize(t => (-t * 4 + 1) / 2));
        }
                
        [Test]
        public void TestBasicAlpha()
        {
            PlotPoints(new EventAlpha(t => -t));
        }

        [Test]
        public void TestBasicTimeRange()
        {
            var begin = 1000f;
            var end = 2000f;
            var eventList = _eventConstructor
                .SampleEvents(_pts)
                .Modify
                .TimeRange(begin,end)
                .EventList;

            Assert.AreEqual(begin, eventList.T[0]);
            Assert.AreEqual(end, eventList.T[_pts]);
        }
        

        
        [Test]
        public void TestHybrid()
        {
            PlotPoints(new List<EventModifier>()
            {
                new EventRotate(t => (float) (16 * Math.PI * t)),
                new EventSize(t => -t + 1),
                new EventAlpha(t => (-t * 3 + 1) / 4),
                new EventScaleX(t => (float) Math.Sin(-t * 2 * Math.PI)),
                new EventScaleY(t => (float) Math.Cos(-t * 2 * Math.PI))
            });
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}