using System;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace EventHandlerUT
{
    using EvCon = SpriteEventConstructor;
    public class Tests
    {
        private String dir = "tests/PatherUnitTest/";
        private int _pts = 100;
        private EvCon _eventConstructor;
        [SetUp]
        public void Setup()
        {
            _eventConstructor = new EvCon();
            System.IO.Directory.CreateDirectory(dir);
        }

        public void PlotPoints(EvCon eventConstructor, int ptsMul = 1)
        {
            EventPlotter.PlotPoints(eventConstructor.SampleTransform(_pts * ptsMul),
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }

        [Test]
        public void TestBasicLinear()
        {
            PlotPoints(_eventConstructor);
        }
        
        [Test]
        public void TestBasicLinearRotation()
        {
            _eventConstructor.Modifiers.Add(new EventRotate((float) Math.PI * 3));
            PlotPoints(_eventConstructor);
        }
        
        [Test]
        public void TestBasicRotation()
        {
            _eventConstructor.Modifiers.Add(new EventRotate(t => (float) (16 * Math.PI * t)));
            PlotPoints(_eventConstructor);
        }
        
        [Test]
        public void TestBasicLinearScaleX()
        {
            _eventConstructor.Modifiers.Add(new EventRotate((float) Math.PI / 2));
            _eventConstructor.Modifiers.Add(new EventScaleX(0.5f));
            PlotPoints(_eventConstructor);
        }
        
        [Test]
        public void TestBasicLinearScaleY()
        {
            _eventConstructor.Modifiers.Add(new EventScaleY(0.5f));
            PlotPoints(_eventConstructor);
        }
        
        [Test]
        public void TestBasicScaleX()
        {
            _eventConstructor.Modifiers.Add(new EventRotate((float) Math.PI / 2));
            _eventConstructor.Modifiers.Add(new EventScaleX(t => -t * 2));
            PlotPoints(_eventConstructor);
        }
        
        [Test]
        public void TestBasicScaleY()
        {
            _eventConstructor.Modifiers.Add(new EventScaleY(t => -t * 2));
            PlotPoints(_eventConstructor);
        }      
        
        [Test]
        public void TestBasicSize()
        {
            _eventConstructor.Modifiers.Add(new EventSize(t => (-t * 4 + 1) / 2));
            PlotPoints(_eventConstructor);
        }
                
        [Test]
        public void TestBasicAlpha()
        {
            _eventConstructor.Modifiers.Add(new EventAlpha(t => -t));
            PlotPoints(_eventConstructor);
        }
        
        [Test]
        public void TestHybrid()
        {
            _eventConstructor.Modifiers.Add(new EventRotate(t => (float) (16 * Math.PI * t)));
            _eventConstructor.Modifiers.Add(new EventSize  (t => -t + 1));
            _eventConstructor.Modifiers.Add(new EventAlpha (t => (-t * 3 + 1) / 4));
            _eventConstructor.Modifiers.Add(new EventScaleX(t => (float) Math.Sin(-t * 2 * Math.PI)));
            _eventConstructor.Modifiers.Add(new EventScaleY(t => (float) Math.Cos(-t * 2 * Math.PI)));

            PlotPoints(_eventConstructor, 10);
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}