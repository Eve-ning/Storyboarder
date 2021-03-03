using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using EventHandler.Sprite;
using ImageMagick.ImageOptimizers;

namespace EventHandler.Tools
{
    public static class EventPlotter
    {
        private static int _plotSize = 1000;
        private static int _plotPieSize = 20;
        private static float _plotPieSweepStart = 270f;
        private static int _maxRgb = 255;
        private static float _plotPieSweep = 40f;
        
        /// <summary>
        /// Plots the event.
        /// Note that, by default, the direction of the sprite points down
        /// </summary>
        /// <param name="events"></param>
        /// <param name="exportPath"></param>
        /// <param name="drawPath"></param>
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
                    var evConv = ConvertEvent(new SpriteEvent(ev),
                        events.TimeBegin(), events.TimeEnd());
                    pen.Color = Color.FromArgb(
                        (int)evConv.A,
                        (int)evConv.T,
                        _maxRgb - (int) evConv.T,
                        (int) _maxRgb / 2);

                    var newSize = Math.Max(_plotPieSize * evConv.S, 0.001f);
                    gfx.DrawPie(
                        pen,
                        evConv.X - newSize / 2, 
                        evConv.Y - newSize / 2,
                        newSize, newSize,
                        _plotPieSweepStart - _plotPieSweep / 2 + evConv.R,
                        _plotPieSweep);
                    
                    if (drawPath && (prevX >= 0 || prevY >= 0))
                        gfx.DrawLine(pen,
                            prevX   ,
                            prevY   ,
                            evConv.X,
                            evConv.Y);

                    prevX = evConv.X;
                    prevY = evConv.Y;

                    Console.Write(new SpriteEvent(ev).ToString() + " | \t | ");
                    Console.WriteLine(evConv.ToString());
                }
                bmp.Save(exportPath);
            }
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
        /// <param name="ev"></param>
        /// <returns> </returns>
        public static SpriteEvent ConvertEvent(SpriteEvent ev, float tBegin, float tEnd)
        {
            return new SpriteEvent(
                // [-1, 1] -> [0, 2] -> [0, 1000]
                (ev.X + 1) * _plotSize / 2,
                
                // [-1, 1] -> [0, 2] -> [1000, 0] : Y Axis is flipped
                _plotSize - (ev.Y + 1) * _plotSize / 2,
                
                // S No Change
                ev.S,
                
                // [0, 1] -> [0, 255]
                ev.A * _maxRgb,
                
                // R Convert to Degrees
                (float)(ev.R * 360f / 2 / Math.PI) ,
                
                // [-1, 0] -> [0, 1] -> [0, 255]
                (ev.T - tBegin) / (tEnd - tBegin) * _maxRgb
            );
        }
    }
}
