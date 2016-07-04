using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Sphere : Geometry
    {
        float radius;
        Vector3D center;

        public Sphere(float radius, Vector3D center)
        {
            this.radius = radius;
            this.center = center;
        }

        public override Vector3D GetNormalAtPoint(Vector3D point)
        {
            return (point - center).Unit;
        }

        public override Tuple<bool, float> Hit(Ray r)
        {
            Vector3D v = r.Origin - center;
            float a = r.Direction * r.Direction;
            float b = 2f * v * r.Direction;
            float c = v * v - radius * radius;
            float delta = b * b - 4f * a * c;

            if (delta < 0f) return Geometry.NoIntersection;
            if (delta > 0f)
            {
                float t = (-b - (float)Math.Sqrt(delta)) / (2f * a);
                if (t > Geometry.Epsilon)
                    return new Tuple<bool, float>(true, t);
            }
            return Geometry.NoIntersection;
        }
    }
}
