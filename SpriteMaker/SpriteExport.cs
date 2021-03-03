using System;
using EventMaker;
using OsuParsers.Enums.Storyboards;
using OsuParsers.Storyboards.Commands;
using OsuParsers.Storyboards.Objects;

namespace SpriteMaker {
    public class SpriteExport {
        private Sprite Sprite { get; set; }
        private EventList Events => Sprite.Events;
        private String SpritePath => Sprite.SpritePath;

        public SpriteExport(Sprite sprite) {
            Sprite = sprite;
        }

        public StoryboardSprite CreateOsuSprite() {
            var sbSprite = new StoryboardSprite(Origins.Centre, SpritePath, 0, 0);
            bool first = true;
            Event prev = new Event();
            foreach (var v in Events) {
                var curr = new Event(v);
                if (first) {
                    prev = curr;
                    first = false;
                    continue;
                }
                
                var cmd = new Command(CommandType.Movement, Easing.None,
                    (int) prev.T,(int) curr.T,
                    prev.XY, curr.XY);
                sbSprite.Commands.Commands.Add(cmd);
                if (!(Math.Abs(prev.R - curr.R) > Math.PI)) {
                    var cmdR = new Command(CommandType.Rotation, Easing.None,
                        (int) prev.T, (int) curr.T,
                        prev.R, curr.R);
                    sbSprite.Commands.Commands.Add(cmdR);
                }
                prev = curr;
            }
            return sbSprite;
        }
    }
}