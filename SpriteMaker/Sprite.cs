using System;
using EventMaker;

namespace SpriteMaker {
    public class Sprite {
        public EventList Events { get; set; }
        public String SpritePath { get; set; }
        public Sprite(EventList events, string spritePath) {
            Events = events;
            SpritePath = spritePath;
        }
        
        public SpriteExport Export => new SpriteExport(this);
    }
}