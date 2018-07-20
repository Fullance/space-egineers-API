namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using VRageMath;

    public class MyMeshHelper
    {
        private static readonly int C_BUFFER_CAPACITY = 0x1388;
        private static List<Vector3D> m_tmpVectorBuffer = new List<Vector3D>(C_BUFFER_CAPACITY);

        public static void GenerateSphere(ref MatrixD worldMatrix, float radius, int steps, List<Vector3D> vertices)
        {
            m_tmpVectorBuffer.Clear();
            int num = 0;
            float num2 = 360 / steps;
            float num3 = 90f - num2;
            float num4 = 360f - num2;
            for (float i = 0f; i <= num3; i += num2)
            {
                for (float k = 0f; k <= num4; k += num2)
                {
                    Vector3D vectord;
                    vectord.X = (float) ((radius * Math.Sin((double) MathHelper.ToRadians(k))) * Math.Sin((double) MathHelper.ToRadians(i)));
                    vectord.Y = (float) ((radius * Math.Cos((double) MathHelper.ToRadians(k))) * Math.Sin((double) MathHelper.ToRadians(i)));
                    vectord.Z = (float) (radius * Math.Cos((double) MathHelper.ToRadians(i)));
                    m_tmpVectorBuffer.Add(vectord);
                    num++;
                    vectord.X = (float) ((radius * Math.Sin((double) MathHelper.ToRadians(k))) * Math.Sin((double) MathHelper.ToRadians((float) (i + num2))));
                    vectord.Y = (float) ((radius * Math.Cos((double) MathHelper.ToRadians(k))) * Math.Sin((double) MathHelper.ToRadians((float) (i + num2))));
                    vectord.Z = (float) (radius * Math.Cos((double) MathHelper.ToRadians((float) (i + num2))));
                    m_tmpVectorBuffer.Add(vectord);
                    num++;
                    vectord.X = (float) ((radius * Math.Sin((double) MathHelper.ToRadians((float) (k + num2)))) * Math.Sin((double) MathHelper.ToRadians(i)));
                    vectord.Y = (float) ((radius * Math.Cos((double) MathHelper.ToRadians((float) (k + num2)))) * Math.Sin((double) MathHelper.ToRadians(i)));
                    vectord.Z = (float) (radius * Math.Cos((double) MathHelper.ToRadians(i)));
                    m_tmpVectorBuffer.Add(vectord);
                    num++;
                    vectord.X = (float) ((radius * Math.Sin((double) MathHelper.ToRadians((float) (k + num2)))) * Math.Sin((double) MathHelper.ToRadians((float) (i + num2))));
                    vectord.Y = (float) ((radius * Math.Cos((double) MathHelper.ToRadians((float) (k + num2)))) * Math.Sin((double) MathHelper.ToRadians((float) (i + num2))));
                    vectord.Z = (float) (radius * Math.Cos((double) MathHelper.ToRadians((float) (i + num2))));
                    m_tmpVectorBuffer.Add(vectord);
                    num++;
                }
            }
            int count = m_tmpVectorBuffer.Count;
            foreach (Vector3D vectord2 in m_tmpVectorBuffer)
            {
                vertices.Add(vectord2);
            }
            foreach (Vector3D vectord3 in m_tmpVectorBuffer)
            {
                Vector3D item = new Vector3D(vectord3.X, vectord3.Y, -vectord3.Z);
                vertices.Add(item);
            }
            for (int j = 0; j < vertices.Count; j++)
            {
                vertices[j] = Vector3D.Transform(vertices[j], (MatrixD) worldMatrix);
            }
        }
    }
}

