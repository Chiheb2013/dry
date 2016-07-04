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

        List<SceneObject> sceneObjects;
        List<Light> lights;

        public List<Light> Lights { get { return lights; } }

        public World(Camera camera)
        {
            this.camera = camera;
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
            Bitmap image = new Bitmap(camera.Viewport.Width, camera.Viewport.Height);
            Vector3D direction = new Vector3D(0, 0, 1);

            for (int y = 0; y < camera.Viewport.Height; y++)
                for (int x = 0; x < camera.Viewport.Width; x++)
                {
                    Vector3D origin = new Vector3D(
                        camera.Viewport.Scaling*((float)x + 0.5f - (float)camera.Viewport.Width / 2f),
                        camera.Viewport.Scaling*((float)y + 0.5f - (float)camera.Viewport.Height / 2f),
                        0f);
                    Ray r = new Ray(origin, direction);

                    Color color = TraceRay(r,1);
                    image.SetPixel(x, camera.Viewport.Height - y - 1, color.ToRGB());
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
