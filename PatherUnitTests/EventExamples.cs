using System;
using System.Collections.Generic;
using EventHandler.Event;
using EventHandler.Modifiers;
using NUnit.Framework;

namespace EventHandlerUT {
    public class BasicExamples {
        private String dir = "tests/EventExamples/";
        private int _pts = 100;

        [SetUp]
        public void Setup() {
            System.IO.Directory.CreateDirectory(dir);
        }

        public void PlotPoints(EventList eventList, float tBegin, float tEnd) {
            eventList.Plot.PlotPoints(
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png",
                true
            );
        }

        [Test]
        public void TestPipelineWorkflow() {
            var constructor = new EventConstructor();
            var samples = constructor.SampleEvents(_pts);
            samples.Modify
                .AddRotateXY(0.5f * (float) Math.PI)
                .AddRotateXY(0.5f * (float) Math.PI);
            Assert.AreEqual(-1f, samples.Y[0]);
            Assert.AreEqual(0, samples.Y[_pts]);
        }

        [Test]
        public void TestOopWorkflow() {
            var constructor = new EventConstructor();
            var samples = constructor.SampleEvents(_pts);
            var rotate = new EventAddRotateXY(0.5f * (float) Math.PI);
            samples.Modify.WithModifiers(new List<EventModifier>() {rotate, rotate});

            Assert.AreEqual(-1f, samples.Y[0]);
            Assert.AreEqual(0, samples.Y[_pts]);
        }


        [TearDown]
        public void TearDown() { }
    }
}