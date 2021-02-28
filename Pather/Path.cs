using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Pather.Modifiers;

namespace Pather
{
    /*
     * The premise of Path is that we will always follow this traversal:
     * X:  0 -> 0
     * Y:  1 -> 0
     * T: -1 -> 0 (T goes from negative so as to fix the ending time
     *
     * Whenever we transform the Vector 
     */
    public class BasicPath
    {
        // This vector is the vector 3 of X-Axis, Y-Axis, and the time.
        public Vector3 InitialVecXyt = new Vector3(0, 1, -1);
        public Vector3 FinalVecXyt   = new Vector3(0, 0, 0);
        
        public List<PathModifier> Modifiers = new List<PathModifier>();

        /// <summary>
        /// Samples the Basic Path to generate discrete path anchors
        /// </summary>
        /// <param name="points">The number of points to generate</param>
        /// <returns>A List of Sampled Vector3 points</returns>
        public List<Vector3> Sample(int points)
        {
            var vector3List = new List<Vector3>();
            var vector3Diff = InitialVecXyt - FinalVecXyt;
            for (int t = 0; t <= points; t++)
            {
                var vector3 = InitialVecXyt - vector3Diff * t / points;
                vector3List.Add(vector3);
            }

            return vector3List;
        }

        public List<Vector3> SampleTransform(int points)
        {
            var samples = Sample(points);
            foreach (var modifier in Modifiers)
            {
                samples = modifier.ModifyAll(samples);
            }

            return samples;
        }
    }
}
