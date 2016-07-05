using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Vector4D
    {
        public static Vector4D Zero = new Vector4D(0, 0, 0, 0);

        float x, y, z, t;

        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float Z { get { return z; } }
        public float T { get { return t; } }
        public float LengthSqr { get { return x * x + y * y + z * z + t * t; } }
        public float Length { get { return (float)Math.Sqrt(LengthSqr); } }
        public Vector4D Unit
        {
            get
            {
                if (Length != 0f)
                    return this / Length;
                throw new DivideByZeroException();
            }
        }
        public float this[int i]
        {
            get
            {
                if (i == 0) return x;
                if (i == 1) return y;
                if (i == 2) return z;
                if (i == 3) return t;
                throw new ArgumentOutOfRangeException();
            }
        }
        public Vector3D Vect3D { get { return new Vector3D(x, y, z); } }

        public Vector4D(float x, float y, float z, float t)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.t = t;
        }

        public Vector4D(Vector3D v)
        {
            this.x = v.X;
            this.y = v.Y;
            this.z = v.Z;
            this.t = 1f;
        }

        public static Vector4D operator+(Vector4D a, Vector4D b)
        {
            return new Vector4D(a.x + b.x, a.y + b.y, a.z + b.z, a.t + b.t);
        }

        public static Vector4D operator-(Vector4D a, Vector4D b)
        {
            return new Vector4D(a.x - b.x, a.y - b.y, a.z - b.z, a.t - b.t);
        }

        public static Vector4D operator*(Vector4D a, float s)
        {
            return new Vector4D(s * a.x, s * a.y, s * a.z, s * a.t);
        }

        public static Vector4D operator*(float s, Vector4D a)
        {
            return a * s;
        }

        public static float operator*(Vector4D a, Vector4D b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.t * b.t;
        }

        public static Vector4D operator/(Vector4D a, float s)
        {
            if (s == 0f) throw new DivideByZeroException();
            float invs = 1f / s;
            return invs * a;
        }
    }
}
