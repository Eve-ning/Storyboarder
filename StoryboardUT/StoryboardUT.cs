using System;
using System.Collections.Generic;
using System.Linq;
using EventMaker;
using MathNet.Numerics.Random;
using NUnit.Framework;
using SpriteMaker;
using StoryboardMaker;

namespace StoryboardUT {
    public class Tests {

        private String dir = "tests/StoryboardMakerTests/";
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

        [Test]
        public void TestExport() {

            List<Sprite> sprites = new List<Sprite>();


            foreach (var offset in Enumerable.Range(10,15).Select(x=>x * 200)) {
                var sprite = new Sprite(
                    new EventConstructor()
                        .SampleEvents(_pts)
                        .Modify
                        .SetTimeRange(0, 2 * (float) Math.PI)
                        .AddRotateXY(t => t)
                        .AlignRotate()
                        .SetTimeRange(0 + offset, 2000 + offset)
                        .FitXY(-1, 1, -1, 1,
                            0, 480, 480, 0)
                        .AddX(80)
                        
                        .Events,
                    "down.png"
                );
                sprites.Add(sprite);
            }
            
            foreach (var offset in Enumerable.Range(10,15).Select(x=>x * 200)) {
                var sprite = new Sprite(
                    new EventConstructor()
                        .SampleEvents(_pts)
                        .Modify
                        .SetTimeRange(0, 2 * (float) Math.PI)
                        .AddRotateXY(t => t + (float) Math.PI)
                        .AlignRotate()
                        .SetTimeRange(50 + offset, 2050 + offset)
                        .FitXY(-1, 1, -1, 1,
                            0, 480, 480, 0)
                        .AddX(80)
                        .Events,
                    "down.png"
                );
                sprites.Add(sprite);
            }

            var sb = new Storyboard(sprites);
            sb.Export("out.osb");

        }
    }
}