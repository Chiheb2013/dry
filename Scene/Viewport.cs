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

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public float Scaling { get { return 1f / zoom; } }

        public Viewport(int width, int height)
        {
            this.zoom = 1f;
            this.width = width;
            this.height = height;
        }

        public Viewport(int width, int height, float zoom)
        {
            this.zoom = zoom;
            this.width = width;
            this.height = height;
        }
    }
}
