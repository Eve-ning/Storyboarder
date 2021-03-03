using System;
using EventMaker;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Objects;

namespace SpriteMaker {
    public class SpriteExport {
        private Sprite Sprite { get; set; }
        private EventList Events { get; set; }
        private String SpritePath { get; set; }

        public SpriteExport(Sprite sprite) {
            Sprite = sprite;
        }

        public String ExportAsOsb(String exportPath) {
            var sbSprite = new StoryboardSprite(Origins.Centre, SpritePath, 0, 0);
            foreach (var v in Events) {
                var e = new Event(v); 
            }
            sbSprite.ToString();
            return "hello";
        }
        
        
    }
}