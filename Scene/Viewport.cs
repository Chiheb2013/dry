using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Viewport
    {
        int width;
        int height;

        float zoom;

        Vector3D topLeft;
        Vector3D bottomRight;

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public Vector3D TopLeft { get { return topLeft; } }
        public Vector3D BottomRight { get { return bottomRight; } }

        public float Scaling { get { return 1f / zoom; } }

        public Viewport(int width, int height, Vector3D topLeft, Vector3D bottomRight)
        {
            this.zoom = 1f;
            this.width = width;
            this.height = height;
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public Viewport(int width, int height, float zoom, Vector3D topLeft, Vector3D bottomRight)
        {
            this.zoom = zoom;
            this.width = width;
            this.height = height;
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }
    }
}
