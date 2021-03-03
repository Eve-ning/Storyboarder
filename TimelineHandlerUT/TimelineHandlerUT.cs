using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
using EventHandler.Event;
using EventHandler.Tools;
using NUnit.Framework;
using TimelineHandler.Timeline;

namespace TimelineHandlerUT {
    public class Tests {
        private String dir = "tests/TlEventHandlerTests/";
        private int _pts = 100;
        private TlSpriteEventList _tlCon;
        private double delta = 0.0001f;

        public void PlotPoints(EventList eventList) {
            EventPlotter.PlotPoints(eventList,
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }

        [SetUp]
        public void Setup() {
            System.IO.Directory.CreateDirectory(dir);
        }

        [Test]
        public void TestTlWorkflowCircle() {
            var constructor = new EventConstructor(yBegin: 0, tBegin:0, tEnd:2 * (float)Math.PI);
            var sampleOut = TlSpriteEventList.Join(new List<EventList>() {
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
    }
}