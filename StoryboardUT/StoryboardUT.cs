using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Community.CsharpSqlite;
using EventMaker;
using MathNet.Numerics.Random;
using NUnit.Framework;
using SpriteMaker;
using StoryboardMaker;
using StoryboardMaker.OsuReader;

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

        [Test]
        public void TestStandard() {
            var reader = new OsuManiaReader("tests/Files/ex.osu");
            var columns = reader.Columns.Take(200).ToList();
            var offsets = reader.Offsets.Take(200).ToList();
            var samples = 20;
            var duration = 1000;
            var columnSpace = 0.3f;
            var spritePath = "down.png";
            var sprites = new List<Sprite>();
            var constructor = new EventConstructor();

            var colMap = new Dictionary<int, float>();
            colMap.Add(0, 0.5f * (float) Math.PI);
            colMap.Add(1, 0);
            colMap.Add(2, - 1f * (float) Math.PI);
            colMap.Add(3, - 0.5f * (float) Math.PI);
            
            // Receptors
            for (int i = 0; i < 4; i++) {
                
                var sprite = new Sprite(
                    new EventConstructor(yBegin:0)
                        .SampleEvents(samples)
                        .Modify
                        .SetTimeRange(-duration, 20000-duration)
                        .AddRotate(colMap[i]) 
                        .AddX((i - 1.5f) * columnSpace)  
                        .AddRotateXY(t => t % 20000 / 10000f * (float) Math.PI)
                        .FitXY(-1, 1, -1, 1,
                            0, 480, 480, 0)
                        .AddX(80)
                        .Events,
                    "receptor.png"
                );
                sprites.Add(sprite);
            }
            
            // Notes
            foreach (var obj in columns.Zip(offsets)) {
                var column = obj.First;
                var offset = obj.Second;
                var sprite = new Sprite(
                    constructor
                        .SampleEvents(samples)
                        .Modify
                        .AddRotate(t => -t * 2 * (float) Math.PI) 
                        .AddRotateXY(t => -t * (float) Math.PI)
                        .SetTimeRange(offset - duration, offset)
                        .AddRotate(colMap[column]) 
                        .AddX((column - 1.5f) * columnSpace) 
                        .AddRotateXY(t => t % 20000 / 10000f * (float) Math.PI)
                        .FitXY(-1, 1, -1, 1,
                            0, 480, 480, 0)
                        .AddX(80)
                        .Events,
                    spritePath
                );
                
                sprites.Add(sprite);
            }


            var storyboard = new Storyboard(sprites);
            storyboard.Export("Getty - Sonic Bass (Evening).osb");
        }
    }
}