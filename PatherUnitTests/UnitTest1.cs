using System;
using NUnit.Framework;
using Pather;

namespace PatherUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            BasicPath p = new BasicPath();
            foreach (var s in p.Sample(100))
            {
                Console.WriteLine(PathPlotter.ConvertPathPoint(s));
            }
            PathPlotter.PlotPoints(p.Sample(100), "Out.png");
            
            Assert.Pass();
        }
    }
}