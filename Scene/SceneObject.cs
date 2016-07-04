using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class SceneObject
    {
        public static SceneObject Air = new SceneObject(new VoidGeometry(), (new VoidMaterial()).Material);
        
        Material material;
        Geometry geometry;

        public Material Material { get { return material; } }
        public Geometry Geometry { get { return geometry; } }

        public SceneObject(Geometry geometry, Material material)
        {
            this.geometry = geometry;
            this.material = material;
            this.material.SceneObject = this;
        }

        public Tuple<bool,float> Hit(Ray ray)
        {
            var ht = geometry.Hit(ray);

            if (ht.Item1)
                material.Hitpoint = ray.Origin + ray.Direction * ht.Item2;
            return ht;
        }
    }
}
