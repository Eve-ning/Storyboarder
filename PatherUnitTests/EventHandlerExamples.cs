using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;

namespace EventHandlerUT {
    public class Examples {
        private String dir = "tests/EventHandlerExamples/";
        private int _pts = 100;

        [SetUp]
        public void Setup() {
            System.IO.Directory.CreateDirectory(dir);
        }

        public void PlotPoints(SpriteEventList eventList, float tBegin, float tEnd) {
            EventPlotter.PlotPoints(eventList,
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png",
                true
            );
        }

        [Test]
        public void TestPipelineWorkflow() {
            var constructor = new SpriteEventConstructor();
            var samples = constructor.SampleEvents(_pts);
            samples.Modify
                .AddRotateXY(0.5f * (float) Math.PI)
                .AddRotateXY(0.5f * (float) Math.PI);
            Assert.AreEqual(-1f, samples.Y[0]);
            Assert.AreEqual(0, samples.Y[_pts]);
        }

        [Test]
        public void TestOopWorkflow() {
            var constructor = new SpriteEventConstructor();
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