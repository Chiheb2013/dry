using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Matrix
    {
        int n;
        float[,] matrix;

        public int Order { get { return n; } }
        public float this[int i, int j] { get { return matrix[i, j]; } }

        public Matrix(float[,] matrix)
        {
            this.matrix = matrix;
            this.n = matrix.GetLength(0);

            if (n != matrix.GetLength(1))
                throw new Exception("Non square matrix");
        }

        public static Matrix CreateTranslationMatrix(Vector3D translation)
        {
            return new Matrix(new float[4, 4] 
                {
                    { 1, 0, 0, translation.X},
                    { 0, 1, 0, translation.Y},
                    { 0, 0, 1, translation.Z},
                    { 0, 0, 0, 1}
                });
        }

        public static Matrix CreateRotationMatrix(Axis axis, float phi)
        {
            if (axis == Axis.X)
                return new Matrix(new float[4, 4]
                    {
                        {1,0,0, 0},
                        {0, (float)Math.Cos(phi), -(float)Math.Sin(phi), 0},
                        {0, (float)Math.Sin(phi), (float)Math.Cos(phi), 0},
                        {0,0,0,1}
                    });
            else if (axis == Axis.Y)
                return new Matrix(new float[4, 4]
                    {
                        {(float)Math.Cos(phi),0,(float)Math.Sin(phi),0},
                        {0,1,0,0},
                        {-(float)Math.Sin(phi),0,(float)Math.Cos(phi),0},
                        {0,0,0,1}
                    });
            else
                return new Matrix(new float[4, 4]
                    {
                        {(float)Math.Cos(phi), -(float)Math.Sin(phi), 0, 0},
                        {(float)Math.Sin(phi), (float)Math.Cos(phi), 0, 0},
                        {0,0,1,0},
                        {0,0,0,1}
                    });
        }

        public static Vector4D operator*(Matrix m, Vector4D v)
        {
            float[] vc = new float[m.Order];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < m.Order; j++)
                    vc[i] += m[i, j] * v[j];

            return new Vector4D(vc[0], vc[1], vc[2], vc[3]);
        }

        public static Matrix operator*(Matrix A, Matrix B)
        {
            if (A.Order != B.Order) throw new Exception("Matrices of different orders");
            float[,] m = new float[A.Order, A.Order];

            for (int i = 0; i < A.Order; i++)
                for (int j = 0; j < A.Order; j++)
                    for (int k = 0; k < A.Order; k++)
                        m[i, j] += A[i, k] * B[k, j];

            return new Matrix(m);
        }
    }
}
