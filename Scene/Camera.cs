using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dry
{
    class Camera
    {
        //coordinate system is as follows :
        //    y
        //    |__x
        //   /
        //  z
        Vector3D position;
        Vector3D forward; //direction of rays
        float alpha; //rotation about X axis
        float beta; //rotation about Y axis

        public Camera(float alpha, float beta, Vector3D position)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.position = position;
            this.forward = ComputeForward();
        }

        public Camera(float alpha, float beta, float zoom, Vector3D position)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.position = position;
            this.forward = ComputeForward();
        }

        private Vector3D ComputeForward()
        {
            Matrix RX = Matrix.CreateRotationMatrix(Axis.X, alpha);
            Matrix RY = Matrix.CreateRotationMatrix(Axis.Y, beta);
            Matrix R = RX * RY;
            Vector4D dir = new Vector4D(new Vector3D(0, 0, 1));

            return (R * dir).Vect3D;
        }

        public Ray ShootRay(Viewport viewport, int x, int y)
        {
            Vector3D origin = new Vector3D(
                viewport.Scaling * ((float)x + 0.5f - (float)viewport.Width / 2f),
                viewport.Scaling * ((float)y + 0.5f - (float)viewport.Height / 2f),
                0f);
            Vector4D P = new Vector4D(origin);

            Matrix RX = Matrix.CreateRotationMatrix(Axis.X, alpha);
            Matrix RY = Matrix.CreateRotationMatrix(Axis.Y, beta);
            Matrix R = RX * RY;

            Matrix T = Matrix.CreateTranslationMatrix(position);

            Vector4D realOrigin = (T * R) * P;
            return new Ray(realOrigin.Vect3D, forward);
        }
    }
}
