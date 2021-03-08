using System;
using System.Collections.Generic;
using SpriteMaker;

namespace StoryboardMaker {
    using OsuStoryboard = OsuParsers.Storyboards.Storyboard;
    
    public class Storyboard {
        private List<Sprite> Sprites { get; set; }
        private OsuStoryboard OsuStoryBoard { get; set; }
        
        public Storyboard(List<Sprite> sprites) {
            Sprites = sprites;
            OsuStoryBoard = new OsuStoryboard();
            foreach (var sprite in sprites) {
                OsuStoryBoard.ForegroundLayer.Add(sprite.Export.CreateOsuSprite());
            }
        }

        public void Export(String exportPath) {
            OsuStoryBoard.Save(exportPath);
        }
    }
}