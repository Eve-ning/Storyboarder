using System;
using System.Collections.Generic;
using System.Linq;
using OsuParsers.Beatmaps;
using OsuParsers.Decoders;

namespace StoryboardMaker.OsuReader {
    public class OsuManiaReader {
        private Beatmap bm;

        public OsuManiaReader(String filePath) {
            bm = BeatmapDecoder.Decode(filePath);
        }

        public List<int> Offsets {
            get {
                return bm.HitObjects.Select(o => o.StartTime).ToList();
            }
        }

        public List<int> Columns {
            get {
                return bm.HitObjects.Select(o => PositionToColumn(o.Position.X)).ToList();
            }
        }

        public int PositionToColumn(float position) {
            return (int) Math.Ceiling((position * bm.DifficultySection.CircleSize - 256.0) / 512.0);
        }
    }
}