using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Vector3D
    {
        public static Vector3D Zero = new Vector3D(0, 0, 0);

        float x, y, z;

        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float Z { get { return z; } }
        public float LengthSqr { get { return this * this; } }
        public float Length { get { return (float)Math.Sqrt(LengthSqr); } }
        public Vector3D Unit
        {
            get
            {
                if (LengthSqr == 0f)
                    throw new DivideByZeroException();
                return this / Length;
            }
        }

        public Vector3D()
        {
        }

        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return "[" + x + ", " + y + ", " + z + " | " + Length;
        }

        public static Vector3D operator+(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3D operator-(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static float operator *(Vector3D a, Vector3D b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3D operator*(float s, Vector3D v)
        {
            return new Vector3D(s * v.x, s * v.y, s * v.z);
        }

        public static Vector3D operator*(Vector3D v, float s)
        {
            return s * v;
        }

        public static Vector3D operator/(Vector3D v, float s)
        {
            if (s == 0f) throw new DivideByZeroException();
            float invs = 1f / s;
            return invs * v;
        }
    }
}
