using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace EventHandlerUT {
    public class Tests {
        private String dir = "tests/EventHandlerTests/";
        private int _pts = 100;
        private SpriteEventConstructor _eventConstructor;

        [SetUp]
        public void Setup() {
            _eventConstructor = new SpriteEventConstructor();
            System.IO.Directory.CreateDirectory(dir);
        }

        public void PlotPoints(EventModifier modifier, int ptsMul = 1) {
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

        public void PlotPoints(List<EventModifier> modifiers, int ptsMul = 1) {
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

        public void PlotPoints(SpriteEventList eventList) {
            EventPlotter.PlotPoints(eventList,
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }

        [Test]
        public void TestBasicLinear() {
            PlotPoints(new List<EventModifier>() { });
        }

        [Test]
        public void TestBasicPipelining() {
            PlotPoints(_eventConstructor
                .SampleEvents(_pts)
                .Modify.SetAlpha(t => -t).EventList);
        }

        [Test]
        public void TestBasicLinearRotation() {
            PlotPoints(new EventAddRotate((float) Math.PI * 3));
        }

        [Test]
        public void TestBasicRotation() {
            PlotPoints(new EventAddRotate(t => (float) (16 * Math.PI * t)));
        }

        [Test]
        public void TestBasicLinearScaleX() {
            PlotPoints(new List<EventModifier>() {
                new EventAddRotate((float) Math.PI / 2),
                new EventScaleX(0.5f)
            });
        }

        [Test]
        public void TestBasicLinearScaleY() {
            PlotPoints(new EventScaleY(0.5f));
        }

        [Test]
        public void TestBasicScaleX() {
            PlotPoints(new List<EventModifier>() {
                new EventAddRotate((float) Math.PI / 2),
                new EventScaleX(t => -t * 2)
            });
        }

        [Test]
        public void TestBasicScaleY() {
            PlotPoints(new EventScaleY(t => -t * 2));
        }

        [Test]
        public void TestBasicSize() {
            PlotPoints(new EventSetSize(t => (-t * 4 + 1) / 2));
        }

        [Test]
        public void TestBasicAlpha() {
            PlotPoints(new EventSetAlpha(t => -t));
        }

        [Test]
        public void TestBasicTimeRange() {
            var begin = 1000f;
            var end = 2000f;
            var eventList = _eventConstructor
                .SampleEvents(_pts)
                .Modify
                .SetTimeRange(begin, end)
                .EventList;

            Assert.AreEqual(begin, eventList.T[0]);
            Assert.AreEqual(end, eventList.T[_pts]);
        }


        [Test]
        public void TestHybrid() {
            PlotPoints(new List<EventModifier>() {
                new EventAddRotate(t => (float) (16 * Math.PI * t)),
                new EventSetSize(t => -t + 1),
                new EventSetAlpha(t => (-t * 3 + 1) / 4),
                new EventScaleX(t => (float) Math.Sin(-t * 2 * Math.PI)),
                new EventScaleY(t => (float) Math.Cos(-t * 2 * Math.PI))
            });
        }

        [TearDown]
        public void TearDown() { }
    }
}