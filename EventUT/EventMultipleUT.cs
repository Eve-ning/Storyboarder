using System;
using System.Collections.Generic;
using EventMaker;
using EventMaker.Modifiers;
using NUnit.Framework;

namespace EventUT {
    public class JoinTests {
        private String dir = "tests/EventUT/";
        private int _pts = 100;
        private EventList Events { get; set; }
        private EventConstructor EventConstructor { get; set; }
        private double delta = 0.0001f;

        [SetUp]
        public void Setup() {
            EventConstructor = new EventConstructor();
            EventConstructor.SampleEvents(_pts);
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
            var constructor = new EventConstructor(yBegin: 0, tBegin:0, tEnd:2 * (float)Math.PI);
            var sampleOut = EventList.Join(new List<EventList>() {
                constructor.SampleEvents(_pts)
                    .Modify
                    .SetX(t => (float) Math.Cos(t))
                    .SetY(t => (float) Math.Sin(t))
                    .SetTimeRange(1000, 2000)
                    .AlignRotate()
                    .Events,
            }, false);
            PlotPoints(sampleOut);
            Assert.AreEqual((float)   Math.PI / 2,sampleOut.R[0],            delta);
            Assert.AreEqual(0,                    sampleOut.R[_pts / 4],     delta);
            Assert.AreEqual((float) - Math.PI / 2,sampleOut.R[_pts / 2],     delta);
            Assert.AreEqual((float)   Math.PI,    sampleOut.R[_pts / 4 * 3], delta);
            
            Assert.AreEqual(1 ,sampleOut.X[0],            delta);
            Assert.AreEqual(0 ,sampleOut.X[_pts / 4],     delta);
            Assert.AreEqual(-1,sampleOut.X[_pts / 2],     delta);
            Assert.AreEqual(0 ,sampleOut.X[_pts / 4 * 3], delta);
            
            Assert.AreEqual(0 ,sampleOut.Y[0],            delta);
            Assert.AreEqual(1 ,sampleOut.Y[_pts / 4],     delta);
            Assert.AreEqual(0 ,sampleOut.Y[_pts / 2],     delta);
            Assert.AreEqual(-1,sampleOut.Y[_pts / 4 * 3], delta);
        }

        [TearDown]
        public void TearDown() { }
    }
}