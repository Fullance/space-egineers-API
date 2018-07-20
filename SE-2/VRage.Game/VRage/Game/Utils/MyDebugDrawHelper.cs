namespace VRage.Game.Utils
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Utils;
    using VRageMath;
    using VRageRender;

    public static class MyDebugDrawHelper
    {
        public static void DrawDashedLine(Vector3D pos1, Vector3D pos2, Color colorValue)
        {
            Vector3D vectord3 = pos1 - pos2;
            float num = (float) (0.1 / vectord3.Length());
            for (float i = 0f; i < 1f; i += num)
            {
                Vector3D vectord;
                Vector3D vectord2;
                Vector3D.Lerp(ref pos1, ref pos2, (double) i, out vectord);
                Vector3D.Lerp(ref pos1, ref pos2, (double) (i + (0.3f * num)), out vectord2);
                MyRenderProxy.DebugDrawLine3D(vectord, vectord2, colorValue, colorValue, false, false);
            }
        }

        public static void DrawNamedColoredAxis(MatrixD matrix, float axisLengthScale = 1f, string name = null, Color? color = new Color?())
        {
            if (!color.HasValue)
            {
                color = new Color?(Color.White);
            }
            MyRenderProxy.DebugDrawLine3D(matrix.Translation, matrix.Translation + ((Vector3D) (matrix.Right * (axisLengthScale * 0.8f))), color.Value, color.Value, false, false);
            MyRenderProxy.DebugDrawLine3D(matrix.Translation + ((Vector3D) (matrix.Right * (axisLengthScale * 0.8f))), matrix.Translation + ((Vector3D) (matrix.Right * axisLengthScale)), Color.Red, Color.Red, false, false);
            MyRenderProxy.DebugDrawLine3D(matrix.Translation, matrix.Translation + ((Vector3D) (matrix.Up * (axisLengthScale * 0.8f))), color.Value, color.Value, false, false);
            MyRenderProxy.DebugDrawLine3D(matrix.Translation + ((Vector3D) (matrix.Up * (axisLengthScale * 0.8f))), matrix.Translation + ((Vector3D) (matrix.Up * axisLengthScale)), Color.Green, Color.Green, false, false);
            MyRenderProxy.DebugDrawLine3D(matrix.Translation, matrix.Translation + ((Vector3D) (matrix.Forward * (axisLengthScale * 0.8f))), color.Value, color.Value, false, false);
            MyRenderProxy.DebugDrawLine3D(matrix.Translation + ((Vector3D) (matrix.Forward * (axisLengthScale * 0.8f))), matrix.Translation + ((Vector3D) (matrix.Forward * axisLengthScale)), Color.Blue, Color.Blue, false, false);
            DrawNamedPoint(matrix.Translation, name, color, null);
        }

        public static void DrawNamedPoint(Vector3D pos, string name, Color? color = new Color?(), MatrixD? cameraViewMatrix = new MatrixD?())
        {
            if (!cameraViewMatrix.HasValue)
            {
                cameraViewMatrix = new MatrixD?(MatrixD.Identity);
            }
            if (!color.HasValue)
            {
                color = new Color?(Color.White);
            }
            MatrixD xd = MatrixD.Invert(ref cameraViewMatrix.Value);
            int hashCode = name.GetHashCode();
            Vector3D vectord = (Vector3D) (((0.5 * xd.Right) * Math.Cos((double) hashCode)) + (xd.Up * (0.75 + (0.25 * Math.Abs(Math.Sin((double) hashCode))))));
            MyRenderProxy.DebugDrawText3D(pos + vectord, name, color.Value, 0.5f, false, MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_BOTTOM, -1, false);
            DrawDashedLine(pos + vectord, pos, color.Value);
            MyRenderProxy.DebugDrawSphere(pos, 0.025f, color.Value, 1f, false, false, true, false);
        }
    }
}

