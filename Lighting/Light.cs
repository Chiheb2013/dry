using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Light
    {
        Vector3D position;

        public Vector3D Position { get { return position; } }

        public Light(Vector3D position)
        {
            this.position = position;
        }
    }
}
