using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace dry
{
    class World
    {
        const int maxDepth = 2;

        Camera camera;
        Viewport viewport;

        List<SceneObject> sceneObjects;
        List<Light> lights;

        public List<Light> Lights { get { return lights; } }

        public World(Camera camera, Viewport viewport)
        {
            this.camera = camera;
            this.viewport = viewport;
            this.lights = new List<Light>();
            this.sceneObjects = new List<SceneObject>();
        }

        public void AddLight(Light light)
        {
            lights.Add(light);
        }

        public void AddSceneObject(SceneObject so)
        {
            sceneObjects.Add(so);
        }
        
        public Bitmap Render()
        {
            Bitmap image = new Bitmap(viewport.Width, viewport.Height);

            for (int y = 0; y < viewport.Height; y++)
                for (int x = 0; x < viewport.Width; x++)
                {
                    Ray r = camera.ShootRay(viewport, x, y);

                    Color color = TraceRay(r,1);
                    image.SetPixel(x, viewport.Height - y - 1, color.ToRGB());
                }

            return image;
        }

        private Color TraceRay(Ray r, int d)
        {
            Color L = Color.Black;
            if (d > maxDepth) return L;

            var hitObject = GetIntersectedObject(r);

            if (hitObject == null) return L;
            L = hitObject.Material.Shade(r);

            if (hitObject.Material.IsReflexive)
                L += TraceRay(GetReflectedRay(r, hitObject), d + 1);
            if (hitObject.Material.IsRefractive)
                L += TraceRay(GetRefractedRay(r, hitObject), d + 1);

            return L;
        }

        public SceneObject GetIntersectedObject(Ray r)
        {
            var hitObjects = from so in sceneObjects
                             where so.Hit(r).Item1
                             orderby so.Hit(r).Item2
                             select so;
            return hitObjects.FirstOrDefault();
        }

        private Ray GetReflectedRay(Ray r, SceneObject hitObject)
        {
            Vector3D n = hitObject.Geometry.GetNormalAtPoint(hitObject.Material.Hitpoint);
            float k = (-1f) * r.Direction * n;

            return new Ray(hitObject.Material.Hitpoint, r.Direction + (2 * k * n), hitObject);
        }

        private Ray GetRefractedRay(Ray r, SceneObject hitObject)
        {
            Vector3D n = hitObject.Geometry.GetNormalAtPoint(hitObject.Material.Hitpoint);
            float n1 = r.ObjectAtEmission.Material.RefractiveIndex;
            float n2 = hitObject.Material.RefractiveIndex;
            float ri = n1 / n2;
            float c1 = -(n * r.Direction);
            float c2 = (float)Math.Sqrt(1f - ri * ri * (1f - c1 * c1));
            Vector3D dir = (ri * r.Direction) + (ri * c1 - c2) * n;

            return new Ray(hitObject.Material.Hitpoint, dir, hitObject);
        }
    }
}
