using System;
using IronPython.Modules;
using NUnit.Framework;
using Pather;
using Pather.Modifiers;

namespace PatherUnitTests
{
    public class Tests
    {
        private String dir = "tests/PatherUnitTest/";
        [SetUp]
        public void Setup()
        {
            System.IO.Directory.CreateDirectory(dir);
        }

        [Test]
        public void TestBasicLinear()
        {
            BasicPath p = new BasicPath();
            foreach (var s in p.Sample(100)) {
                Console.WriteLine(PathPlotter.ConvertPathPoint(s));
            }
            PathPlotter.PlotPoints(p.Sample(100),
                dir + "TestBasicLinear.png");
            
            Assert.Pass();
        }
        
        [Test]
        public void TestBasicLinearRotation()
        {
            BasicPath p = new BasicPath();
            var rotate = new PathRotate(t => (float) Math.PI * 4 * t);
            p.Modifiers.Add(rotate);
            PathPlotter.PlotPoints(p.SampleTransform(400),
                dir + "TestBasicLinearRotation.png");
            
            Assert.Pass();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}