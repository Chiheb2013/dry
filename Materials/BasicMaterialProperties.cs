using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class BasicMaterialProperties
    {
        float ambient;
        float diffuse;

        Color color;

        public float Ambient { get { return ambient; } }
        public float Diffuse { get { return diffuse; } }
        public Color Color { get { return color; } }

        public BasicMaterialProperties(Color color, float ambient, float diffuse)
        {
            this.color = color;
            this.ambient = ambient;
            this.diffuse = diffuse;
        }
    }
}
