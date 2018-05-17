namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2B
    {
        private byte X;
        private byte Y;
        public Vector2B(byte x, byte y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2I operator *(Vector2B op1, Vector2I op2) => 
            new Vector2I(op1.X * op2.X, op1.Y * op2.Y);

        public static Vector2I operator *(Vector2B op1, int op2) => 
            new Vector2I(op1.X * op2, op1.Y * op2);
    }
}

