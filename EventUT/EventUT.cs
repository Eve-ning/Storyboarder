using System;
using System.Collections.Generic;
using System.Numerics;
using EventMaker;
using EventMaker.Modifiers;
using NUnit.Framework;

namespace EventUT {
    public class BasicTests {
        private String dir = "tests/EventMakerUT/";
        private int _pts = 100;
        private EventList Events { get; set; }
        private EventConstructor EventConstructor { get; set; }

        [SetUp]
        public void Setup() {
            EventConstructor = new EventConstructor();
            Events = EventConstructor.SampleEvents(_pts);
            System.IO.Directory.CreateDirectory(dir);
        }

        public void PlotPoints(EventModifier modifier, int ptsMul = 1) {
            EventConstructor
                .SampleEvents(_pts * ptsMul)
                .Modify
                .WithModifiers(modifier)
                .Events
                .Plot
                .PlotPoints(
                    dir +
                    new System.Diagnostics.StackTrace().GetFrame(1)?.GetMethod()?.Name +
                    ".png");
        }

        public void PlotPoints(List<EventModifier> modifiers, int ptsMul = 1) {
            EventConstructor
                .SampleEvents(_pts * ptsMul)
                .Modify
                .WithModifiers(modifiers)
                .Events
                .Plot
                .PlotPoints(
                    dir +
                    new System.Diagnostics.StackTrace().GetFrame(1)?.GetMethod()?.Name +
                    ".png");
        }

        public void PlotPoints(EventList eventList) {
            eventList.Plot.PlotPoints(
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
            PlotPoints(EventConstructor
                .SampleEvents(_pts)
                .Modify.SetAlpha(t => -t).Events);
        }

        [Test]
        public void TestBasicConstRotation() {
            PlotPoints(new List<EventModifier>() { 
                new EventAddRotateXY((float) Math.PI * 3),
            });
    }

        [Test]
        public void TestBasicRotation() {
            PlotPoints(new List<EventModifier>(){
                new EventAddRotateXY(t => (float) (16 * Math.PI * t)),
                new EventAlignRotate()
            }
            );
        }
        [Test]
        public void TestBasicOffsetAlign() {
            PlotPoints(new List<EventModifier>(){
                new EventAddRotateXY(t => (float) (16 * Math.PI * t)),
                new EventAlignRotate(origin: new Vector2(0.25f,0.25f))
            }
            );
        }

        [Test]
        public void TestBasicConstScaleX() {
            PlotPoints(new List<EventModifier>() {
                new EventAddRotateXY((float) Math.PI / 2),
                new EventScaleX(0.5f)
            });
        }

        [Test]
        public void TestBasicConstScaleY() {
            PlotPoints(new EventScaleY(0.5f));
        }

        [Test]
        public void TestBasicScaleX() {
            PlotPoints(new List<EventModifier>() {
                new EventAddRotateXY((float) Math.PI / 2),
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
        public void TestBasicFitXY() {
            PlotPoints(Events.Modify
                .FitXY(
                -1, 1, -0f, 1f,
                -1, 1, 1, 0).Events);
        }

        [Test]
        public void TestBasicTimeRange() {
            var begin = 1000f;
            var end = 2000f;
            var eventList = EventConstructor
                .SampleEvents(_pts)
                .Modify
                .SetTimeRange(begin, end)
                .Events;

            Assert.AreEqual(begin, eventList.T[0]);
            Assert.AreEqual(end, eventList.T[_pts]);
        }


        [Test]
        public void TestHybrid() {
            PlotPoints(new List<EventModifier>() {
                new EventAddRotateXY(t => (float) (16 * Math.PI * t)),
                new EventSetSize(t => -t + 1),
                new EventSetAlpha(t => (-t * 3 + 1) / 4),
                new EventScaleX(t => (float) Math.Sin(-t * 2 * Math.PI)),
                new EventScaleY(t => (float) Math.Cos(-t * 2 * Math.PI)),
                new EventAlignRotate()
            });
        }

        [TearDown]
        public void TearDown() { }
    }
}