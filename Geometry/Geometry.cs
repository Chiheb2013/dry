using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Geometry
    {
        public const float Epsilon = 0.0001f;
        public static Tuple<bool, float> NoIntersection = new Tuple<bool, float>(false, float.PositiveInfinity);

        public virtual Tuple<bool, float> Hit(Ray r) { throw new NotImplementedException(); }
        public virtual Vector3D GetNormalAtPoint(Vector3D point) { throw new NotImplementedException(); }
    }
}
