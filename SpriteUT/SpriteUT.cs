using System;
using System.Collections.Generic;
using EventMaker;
using NUnit.Framework;
using SpriteMaker;

namespace SpriteUT {
    public class Tests {
        private String dir = "tests/SpriteMakerTests/";
        private int _pts = 100;
        private double delta = 0.0001f;

        private EventConstructor Constructor { get; set; }
        private EventList EventList { get; set; }
        
        [SetUp]
        public void Setup() {
            System.IO.Directory.CreateDirectory(dir);
            Constructor = new EventConstructor();
            EventList = Constructor.SampleEvents(_pts);
        }

    }
}