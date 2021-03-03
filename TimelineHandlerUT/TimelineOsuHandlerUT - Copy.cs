using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
using EventHandler.Event;
using EventHandler.Tools;
using NUnit.Framework;
using TimelineHandler.Timeline;

namespace TimelineHandlerUT {
    public class TestsOsu {
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
        public void TestOsu() {
            TlSpriteEventList.Export();
        }
    }
}