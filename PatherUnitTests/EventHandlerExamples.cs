using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
using EventHandler.Sprite;
using EventHandler.Tools;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace EventHandlerUT
{
    public class Examples
    {
        private String dir = "tests/EventHandlerExamples/";
        private int _pts = 100;
        [SetUp]
        public void Setup()
        {
            System.IO.Directory.CreateDirectory(dir);
        }
        
        [Test]
        public void TestPipelineWorkflow()
        {
            var constructor = new SpriteEventConstructor();
            var samples = constructor.SampleEvents(_pts);
            samples.Modify
                .Rotate(0.5f * (float) Math.PI)
                .Rotate(0.5f * (float) Math.PI);
            Assert.AreEqual(-1f, samples.Y[0]);
            Assert.AreEqual(0, samples.Y[_pts]);
        }
        
        [Test]
        public void TestOopWorkflow()
        {
            var constructor = new SpriteEventConstructor();
            var samples = constructor.SampleEvents(_pts);
            var rotate = new EventRotate(0.5f * (float) Math.PI);
            samples.Modify.WithModifiers(new List<EventModifier>() {rotate, rotate});
            
            Assert.AreEqual(-1f, samples.Y[0]);
            Assert.AreEqual(0, samples.Y[_pts]);
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}