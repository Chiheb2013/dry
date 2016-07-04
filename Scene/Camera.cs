using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Camera
    {
        float alpha;    //horizontal fov angle
        float beta;     //vertical fov angle
        float distance;

        Viewport viewport;

        public Viewport Viewport { get { return viewport; } }

        public Vector3D Position
        {
            get
            {
                return new Vector3D(0, 0, distance);
            }
        }

        public Camera(float distance, float alpha, float beta, int width, int height)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.distance = distance;

            this.viewport = GetViewport(width, height);
        }

        public Camera(float distance, float alpha, float beta, int width, int height, float zoom)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.distance = distance;

            this.viewport = GetViewport(width, height, zoom);
        }

        private Viewport GetViewport(int width, int height)
        {
            Vector3D hdelta = new Vector3D(distance * (float)Math.Tan(alpha), 0, 0);
            Vector3D vdelta = new Vector3D(0, distance * (float)Math.Tan(beta), 0);

            Vector3D topLeft = vdelta - hdelta;
            Vector3D bottomRight = hdelta - vdelta;

            return new Viewport(width, height, topLeft, bottomRight);
        }

        private Viewport GetViewport(int width, int height, float zoom)
        {
            var v = GetViewport(width, height);
            return new Viewport(v.Width, v.Height, zoom, v.TopLeft, v.BottomRight);
        }
    }
}
