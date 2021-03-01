using System;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace EventHandlerUT
{
    public class Tests
    {
        private String dir = "tests/PatherUnitTest/";
        private int _pts = 100;
        private SpriteEventHandler _eventHandler;
        [SetUp]
        public void Setup()
        {
            _eventHandler = new SpriteEventHandler();
            System.IO.Directory.CreateDirectory(dir);
        }

        public void PlotPoints(SpriteEventHandler eventHandler)
        {
            EventPlotter.PlotPoints(eventHandler.SampleTransform(_pts),
                dir +
                (new System.Diagnostics.StackTrace()).GetFrame(1)?.GetMethod()?.Name +
                ".png");
        }

        [Test]
        public void TestBasicLinear()
        {
            PlotPoints(_eventHandler);
        }
        
        [Test]
        public void TestBasicLinearRotation()
        {
            _eventHandler.Modifiers.Add(new EventRotate((float) Math.PI * 3));
            PlotPoints(_eventHandler);
        }
        
        [Test]
        public void TestBasicRotation()
        {
            _eventHandler.Modifiers.Add(new EventRotate(t => (float) (16 * Math.PI * t)));
            PlotPoints(_eventHandler);
        }
        
        [Test]
        public void TestBasicLinearScaleX()
        {
            _eventHandler.Modifiers.Add(new EventRotate((float) Math.PI / 2));
            _eventHandler.Modifiers.Add(new EventScaleX(0.5f));
            PlotPoints(_eventHandler);
        }
        
        [Test]
        public void TestBasicLinearScaleY()
        {
            _eventHandler.Modifiers.Add(new EventScaleY(0.5f));
            PlotPoints(_eventHandler);
        }
        
        [Test]
        public void TestBasicScaleX()
        {
            _eventHandler.Modifiers.Add(new EventRotate((float) Math.PI / 2));
            _eventHandler.Modifiers.Add(new EventScaleX(t => -t * 2));
            PlotPoints(_eventHandler);
        }
        
        [Test]
        public void TestBasicScaleY()
        {
            _eventHandler.Modifiers.Add(new EventScaleY(t => -t * 2));
            PlotPoints(_eventHandler);
        }
        
        [Test]
        public void TestHybrid()
        {
            _eventHandler.Modifiers.Add(new EventRotate(t => (float) (16 * Math.PI * t)));
            _eventHandler.Modifiers.Add(new EventScaleX(t => (float) Math.Sin(-t * 2 * Math.PI)));
            _eventHandler.Modifiers.Add(new EventScaleY(t => (float) Math.Cos(-t * 2 * Math.PI)));

            PlotPoints(_eventHandler);
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}