using EventHandler.Sprite;
using NUnit.Framework;
using TimelineHandler.Timeline;

namespace TimelineHandlerUT
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
            var ev = new SpriteEventHandler();
            var tev = new TlSpriteEvent(ev, 1000, 2000);

            var a = tev.Sample(100);
            System.Console.WriteLine(a.T[0]);
            
            Assert.Pass();
        }
    }
}