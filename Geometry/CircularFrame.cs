using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class CircularFrame : Geometry
    {
        Plane plane; //the underlying plane of the frame

        float radius;   //frame radius
        Vector3D A;     //the center of the frame

        public CircularFrame(Vector3D center, float radius, Plane plane)
        {
            this.A = center;
            this.plane = plane;
            this.radius = radius;
        }

        public override Vector3D GetNormalAtPoint(Vector3D point)
        {
            return plane.GetNormalAtPoint(point);
        }

        public override Tuple<bool, float> Hit(Ray r)
        {
            Tuple<bool, float> hit = plane.Hit(r);
            Vector3D hitpoint = r.Origin + hit.Item2 * r.Direction;
            Vector3D v = hitpoint - A;
            float dot = plane.GetNormalAtPoint(hitpoint) * v;

            if (v.Length <= radius && dot < Geometry.Epsilon)
                return hit;
            return Geometry.NoIntersection;
        }
    }
}
