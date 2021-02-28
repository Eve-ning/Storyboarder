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
        
        public static void PlotPoints(List<Vector3> points,
            String exportPath)
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
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public static Vector3 ConvertPathPoint(Vector3 vector3)
        {
            return new(
                (vector3.X + 1) * _plotSize / 2,
                _plotSize - (vector3.Y + 1) * _plotSize / 2,
                (vector3.Z + 1) * 255
            );
        }
    }
}
