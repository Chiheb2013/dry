using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera(0, 0, Vector3D.Zero);
            World world = new World(camera, new Viewport(640, 640));

            BasicMaterialProperties bmp1 = new BasicMaterialProperties(Color.Red, 0.2f, 0.8f);
            BasicMaterialProperties bmp2 = new BasicMaterialProperties(Color.Blue, 0.2f, 0.8f);
            BasicMaterialProperties bmp3 = new BasicMaterialProperties(Color.White, 0.2f, 0.8f);
            Material red = new Material(bmp1, true, world);
            Material blue = new Material(bmp2, true, world);
            Material white = new Material(bmp3, true, true, 3f, world);
            SceneObject s1 = new SceneObject(new Sphere(50, new Vector3D(50, 0, 100)), red);
            SceneObject s2 = new SceneObject(new Sphere(50, new Vector3D(0, -30, 100)), white);
            SceneObject s3 = new SceneObject(new Sphere(50, new Vector3D(-50, 0, 100)), blue);
            BasicMaterialProperties bmp4 = new BasicMaterialProperties(Color.White, 0, 1);
            Material green = new Material(bmp4, true, world);
            SceneObject pl = new SceneObject(new CircularFrame(new Vector3D(0, 0, 180), 200, 
                new Plane(new Vector3D(0, 0, 160), new Vector3D(0, 1, 1))), green);

            world.AddLight(new Light(new Vector3D(0, 60, 100f)));
            world.AddSceneObject(s1);
            world.AddSceneObject(s2);
            world.AddSceneObject(s3);
            world.AddSceneObject(pl);

            world.Render().Save("rendered3.png");
        }

        private static float ToRadians(float deg)
        {
            return (float)Math.PI * deg / 180f;
        }
    }
}
