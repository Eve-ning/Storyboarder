using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Pather.Modifiers
{
    public class PathRotate : PathModifier
    {
        public Func<float, float> radians;

        public PathRotate(float radiansConst)
        {
            this.radians = f => radiansConst;
        }
        /// <summary>
        /// Creates a Rotate Modifier
        /// </summary>
        /// <param name="radiansFunc">Rotation(Time) Function</param>
        public PathRotate(Func<float, float> radiansFunc)
        {
            this.radians = radiansFunc;
        }

        public override Vector3 Modify(Vector3 v3){
            return new Vector3(
                (float) (v3.X * Math.Cos(radians(v3.Z)) - v3.Y * Math.Sin(radians(v3.Z))),
                (float) (v3.X * Math.Sin(radians(v3.Z)) + v3.Y * Math.Cos(radians(v3.Z))),
                v3.Z
            );
        }


    }
}