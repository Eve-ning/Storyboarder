using System;
using EventMaker;

namespace SpriteMaker {
    public class Sprite {
        private EventList Events { get; set; }
        private String SpritePath { get; set; }
        public Sprite(EventList events, string spritePath) {
            Events = events;
            SpritePath = spritePath;
        }
        
        public SpriteExport Export => new SpriteExport(this);
    }
}