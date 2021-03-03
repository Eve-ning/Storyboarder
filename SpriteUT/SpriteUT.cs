using System;
using System.Collections.Generic;
using EventMaker;
using NUnit.Framework;
using SpriteMaker;

namespace SpriteUT {
    public class Tests {
        private String dir = "tests/TlEventHandlerTests/";
        private int _pts = 100;
        private double delta = 0.0001f;

        private EventConstructor Constructor { get; set; }
        private EventList EventList { get; set; }
        
        [SetUp]
        public void Setup() {
            System.IO.Directory.CreateDirectory(dir);
            EventList = Constructor.SampleEvents(_pts);
        }

        [Test]
        public void TestTlWorkflowCircle() {
            var sprite = new Sprite(EventList, "sprite.jpg");
        }
    }
}