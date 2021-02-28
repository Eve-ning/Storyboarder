using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Pather.Modifiers
{
    public abstract class PathModifier
    {
        public abstract Vector3 Modify(Vector3 v3);

        public List<Vector3> ModifyAll(List<Vector3> vector3List)
        {
            return vector3List.Select(vector3 => Modify(vector3)).ToList();
        }
    }
}