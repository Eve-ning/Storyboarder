using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;

namespace Pather
{
    public class PathPlotter
    {
        private static int _plotSize = 1000;
        private static int _plotCircleSize = 3;
        private static int _maxRgb = 255;
        
        public static void PlotPoints(List<Vector3> points, String exportPath)
        {
            using (var bmp = new Bitmap(_plotSize, _plotSize))
            using (var gfx = Graphics.FromImage(bmp))
            using (var pen = new Pen(Color.White))
            {
                gfx.Clear(Color.Black);
                foreach (var point in points)
                {
                    var convPoint = ConvertPathPoint(point);
                    pen.Color = Color.FromArgb(
                        (int)convPoint.Z,
                        _maxRgb - (int) convPoint.Z,
                        (int) _maxRgb / 2);
                    gfx.DrawEllipse(pen, convPoint.X, convPoint.Y,
                        _plotCircleSize, _plotCircleSize);
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
        /// <param name="vector3"></param>
        /// <returns> </returns>
        public static Vector3 ConvertPathPoint(Vector3 vector3)
        {
            return new(
                // [-1, 1] -> [0, 2] -> [0, 1000]
                (vector3.X + 1) * _plotSize / 2,
                // [-1, 1] -> [0, 2] -> [1000, 0] : Y Axis is flipped
                _plotSize - (vector3.Y + 1) * _plotSize / 2,
                // [-1, 0] -> [0, 1] -> [0, 255]
                (vector3.Z + 1) * _maxRgb
            );
        }
    }
}
