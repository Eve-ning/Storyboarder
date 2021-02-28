using System;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;

namespace EventHandlerUT
{
    public class Tests
    {
        private String dir = "tests/PatherUnitTest/";
        private int _pts = 1000;
        [SetUp]
        public void Setup()
        {
            System.IO.Directory.CreateDirectory(dir);
        }

        [Test]
        public void TestBasicLinear()
        {
            var p = new SpriteEventHandler();
            EventPlotter.PlotPoints(p.SampleEvents(_pts),
                dir + "TestBasicLinear.png");
            
            Assert.Pass();
        }
        
        [Test]
        public void TestBasicLinearRotation()
        {
            var p = new SpriteEventHandler();
            var rotate = new EventRotate((float) Math.PI * 3);
            p.Modifiers.Add(rotate);
            EventPlotter.PlotPoints(p.SampleTransform(_pts),
                dir + "TestBasicLinearRotation.png");
            Assert.Pass();
        }
        
        [Test]
        public void TestBasicRotation()
        {
            var p = new SpriteEventHandler();
            var rotate = new EventRotate(t => (float) (16 * Math.PI * t));
            p.Modifiers.Add(rotate);
            EventPlotter.PlotPoints(p.SampleTransform(_pts),
                dir + "TestBasicRotation.png");
            Assert.Pass();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}