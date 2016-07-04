using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Color
    {
        public static Color White = new Color(1, 1, 1);
        public static Color Black = new Color(0, 0, 0);
        public static Color Red = new Color(1, 0, 0);
        public static Color Green = new Color(0, 1, 0);
        public static Color Blue = new Color(0, 0, 1);

        Vector3D color;

        public Color(Vector3D color)
        {
            this.color = color;
        }

        public Color(float r, float g, float b)
        {
            this.color = new Vector3D(r, g, b);
        }

        public System.Drawing.Color ToRGB()
        {
            var c = 255f * color;
            var d = new Vector3D(c.X > 255f ? 255 : c.X, c.Y > 255f ? 255 : c.Y, c.Z > 255f ? 255 : c.Z);
            return System.Drawing.Color.FromArgb((int)d.X, (int)d.Y, (int)d.Z);
        }

        public static Color operator+(Color a, Color b)
        {
            return new Color(a.color + b.color);
        }

        public static Color operator*(float s, Color c)
        {
            return new Color(s * c.color);
        }

        public static Color operator*(Color c, float s)
        {
            return s * c;
        }

        public static Color operator/(Color c, float s)
        {
            return new Color(c.color / s);
        }
    }
}
