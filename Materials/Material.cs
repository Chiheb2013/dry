using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Material
    {
        bool isReflexive;
        bool isRefractive;

        BasicMaterialProperties props;
        float refractiveIndex;

        World world;
        Vector3D hitpoint;
        SceneObject parentObject;

        public bool IsReflexive { get { return isReflexive; } }
        public bool IsRefractive { get { return isRefractive; } }
        public float RefractiveIndex { get { return refractiveIndex; } }

        public Vector3D Hitpoint { get { return hitpoint; } set { hitpoint = value; } }
        public SceneObject SceneObject { get { return parentObject; } set { parentObject = value; } }

        public Material(BasicMaterialProperties props, bool isReflexive, World world)
        {
            this.world = world;
            this.props = props;

            this.isRefractive = false;
            this.isReflexive = isReflexive;
        }

        public Material(BasicMaterialProperties props, bool isReflexive, bool isRefractive, 
            float refractiveIndex, World world)
        {
            this.world = world;
            this.props = props;
            
            this.isReflexive = isReflexive;
            this.isRefractive = isRefractive;
            this.refractiveIndex = refractiveIndex;
        }

        public Color Shade(Ray ray)
        {
            Color L = Color.Black;
            Vector3D normal = parentObject.Geometry.GetNormalAtPoint(hitpoint);

            foreach (var light in world.Lights)
            {
                Vector3D toLight = (light.Position - hitpoint).Unit;
                float s = toLight * normal;

                if (s < 0f) s = 0f;
                L += props.Color * (props.Ambient + props.Diffuse * s);
            }

            return L;
        }
    }
}
