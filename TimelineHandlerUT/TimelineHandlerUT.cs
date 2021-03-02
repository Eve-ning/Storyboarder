using System;
using System.Collections.Generic;
using EventHandler.Modifiers;
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
        private List<EvCon> _evCon = new List<EvCon>();
        private TlCon _tlCon;
        private List<float> begins = new List<float>() {1000f, 3000f};
        private List<float> ends = new List<float>() {2000f, 4000f};
        private double delta = 0.0001f;
        
        [SetUp]
        public void Setup()
        {
            var evCon = new EvCon(begins[0], ends[0]);
            evCon.Modifiers.Add(new EventRotate((float) Math.PI));
            _evCon.Add(evCon);
            
            evCon = new EvCon(begins[1], ends[1]);
            evCon.Modifiers.Add(new EventScaleY(0.5f));
            _evCon.Add(evCon);

            _tlCon = new TlSpriteEventConstructor(_evCon);
        }

        [Test]
        public void TlSampler()
        {
            var samples = _tlCon.Sample(_pts);
            
            Assert.AreEqual(begins[0],samples.T[0]);
            Assert.AreEqual(ends[0],  samples.T[_pts]);
            Assert.AreEqual(begins[1],samples.T[_pts+1]);
            Assert.AreEqual(ends[1],  samples.T[_pts*2+1]);
            
            Assert.AreEqual(0, samples.X[0],        delta);
            Assert.AreEqual(0, samples.X[_pts],     delta);
            Assert.AreEqual(0, samples.X[_pts+1],   delta);
            Assert.AreEqual(0, samples.X[_pts*2+1], delta);
            
            Assert.AreEqual(-1,  samples.Y[0],        delta);
            Assert.AreEqual(0,   samples.Y[_pts],     delta);
            Assert.AreEqual(0.5, samples.Y[_pts+1],   delta);
            Assert.AreEqual(0,   samples.Y[_pts*2+1], delta);
            
        }

        
    }
}