using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Plane : Geometry
    {
        Vector3D p; //a point of the plane
        Vector3D n; //normal at the plane

        public Plane(Vector3D p, Vector3D n)
        {
            this.p = p;
            this.n = n.Unit;
        }

        public override Vector3D GetNormalAtPoint(Vector3D point)
        {
            return n;
        }

        public override Tuple<bool, float> Hit(Ray r)
        {
            Vector3D v = p - r.Origin;

            float a = n * v;
            float b = n * r.Direction;

            if (b < Geometry.Epsilon) return Geometry.NoIntersection;

            return new Tuple<bool, float>(true, a / b);
        }
    }
}
