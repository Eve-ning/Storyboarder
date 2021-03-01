using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using EventHandler.Sprite;

namespace EventHandler.Tools
{
    public class EventPlotter
    {
        private static int _plotSize = 1000;
        private static int _plotPieSize = 20;
        private static int _maxRgb = 255;
        private static float _plotPieSweep = 40f;
        
        public static void PlotPoints(SpriteEventList events, String exportPath,
            bool drawPath = true)
        {
            using (var bmp = new Bitmap(_plotSize, _plotSize))
            using (var gfx = Graphics.FromImage(bmp))
            using (var pen = new Pen(Color.White))
            {
                gfx.Clear(Color.Black);
                float prevX = -1f;
                float prevY = -1f;

                // Draw Axis
                gfx.DrawLine(new Pen(Color.Gray),
                    0f, (float) _plotSize / 2,
                    _plotSize, (float) _plotSize / 2);
                gfx.DrawLine(new Pen(Color.Gray),
                    (float) _plotSize / 2, 0f,
                    (float) _plotSize / 2, _plotSize);
                
                foreach (var ev in events)
                {
                    var evConv = ConvertEvent(ev);
                    pen.Color = Color.FromArgb(
                        (int)evConv.F,
                        (int)evConv.T,
                        _maxRgb - (int) evConv.T,
                        (int) _maxRgb / 2);
                    gfx.DrawPie(
                        pen,
                        evConv.X - (float) _plotPieSize / 2, 
                        evConv.Y - (float) _plotPieSize / 2,
                        evConv.S * _plotPieSize, evConv.S * _plotPieSize,
                        270f - _plotPieSweep / 2 - evConv.R, _plotPieSweep);
                    
                    if (drawPath && (prevX >= 0 || prevY >= 0))
                        gfx.DrawLine(pen,
                            prevX   ,
                            prevY   ,
                            evConv.X,
                            evConv.Y);

                    prevX = evConv.X;
                    prevY = evConv.Y;

                    // Console.Write(ev.ToString() + " | \t | ");
                    // Console.WriteLine(evConv.ToString());
                }
                bmp.Save(exportPath);
            }
        }

        struct Pie
        {
            public int X;
            public int Y;
            public int S;
            public int A;
            public int R;
        }
        
        /// <summary>
        /// We expect
        /// X in [-1, 1]
        /// Y in [-1, 1]
        /// T in [-1, 0]
        ///
        /// to be the viewable screen.
        /// Returns XYT in the expected range of
        /// [0, 1000], [1000, 0], [0, 255] 
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns> </returns>
        public static SpriteEvent ConvertEvent(SpriteEvent ev)
        {
            return new SpriteEvent(
                // [-1, 1] -> [0, 2] -> [0, 1000]
                (ev.X + 1) * _plotSize / 2,
                
                // [-1, 1] -> [0, 2] -> [1000, 0] : Y Axis is flipped
                _plotSize - (ev.Y + 1) * _plotSize / 2,
                
                // S No Change
                ev.S,
                
                // [0, 1] -> [0, 255]
                ev.F * _maxRgb,
                
                // R Convert to Degrees
                (float)(ev.R * 360f / 2 / Math.PI) ,
                
                // [-1, 0] -> [0, 1] -> [0, 255]
                (ev.T + 1) * _maxRgb
            );
        }
    }
}
