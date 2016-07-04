using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Ray
    {
        Vector3D origin;
        Vector3D direction;

        SceneObject emissionObject;

        public Vector3D Origin { get { return origin; } }
        public Vector3D Direction { get { return direction; } }

        public SceneObject ObjectAtEmission { get { return emissionObject; } }

        public Ray(Vector3D origin, Vector3D direction)
        {
            this.origin = origin;
            this.direction = direction;
            this.emissionObject = SceneObject.Air;
        }

        public Ray(Vector3D origin, Vector3D direction, SceneObject objectAtEmission)
        {
            this.origin = origin;
            this.direction = direction;
            this.emissionObject = objectAtEmission;
        }

        public override string ToString()
        {
            return "O:" + origin.ToString() + ", D:" + direction.ToString();
        }
    }
}
