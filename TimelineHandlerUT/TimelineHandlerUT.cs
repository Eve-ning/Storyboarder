using System;
using EventHandler.Sprite;
using NUnit.Framework;
using TimelineHandler.Timeline;

namespace TimelineHandlerUT
{
    using EvCon = SpriteEventConstructor;
    using TlCon = TlSpriteEventConstructor;
    public class Tests
    {
        private int _pts = 100;
        private EvCon _evCon;
        [SetUp]
        public void Setup()
        {
            _evCon = new EvCon();
        }

        [Test]
        public void TlSampler()
        {
            var begin = 1000;
            var end   = 2000;
            var tlCon = new TlCon(_evCon, begin, end);

            var samples = tlCon.Sample(_pts);
            Assert.AreEqual(samples.T[0], begin);
            Assert.AreEqual(samples.T[_pts], end);
        }
        [Test]
        public void TlSamplerException()
        {
            try
            {
                var tlCon = new TlCon(_evCon, 2000, 1000);
                Assert.Fail();
            }
            catch (ArgumentException exc)
            {
                Assert.Pass();
            }   
        }
        
    }
}