using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class VoidGeometry : Geometry
    {
        static Tuple<bool, float> bt;

        static VoidGeometry()
        {
            bt = new Tuple<bool, float>(false, float.PositiveInfinity);
        }

        public VoidGeometry()
        {
        }

        public override Vector3D GetNormalAtPoint(Vector3D point)
        {
            return Vector3D.Zero;
        }

        public override Tuple<bool, float> Hit(Ray r)
        {
            return bt;
        }
    }
}
