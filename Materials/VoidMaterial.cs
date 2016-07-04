using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class VoidMaterial
    {
        Material material;

        public Material Material { get { return material; } }

        public VoidMaterial()
        {
            this.material = new Material(new BasicMaterialProperties(Color.Black, 0f, 0f), false, true, 1f, null);
        }
    }
}
