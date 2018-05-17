namespace VRageMath
{
    using System;

    public class Base27Directions
    {
        private const float DIRECTION_EPSILON = 1E-05f;
        public static readonly Vector3[] Directions = new Vector3[] { 
            new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0f), new Vector3(-1f, 0f, 0f), new Vector3(-0.7071068f, 0f, -0.7071068f), new Vector3(-0.7071068f, 0f, 0.7071068f), new Vector3(-1f, 0f, 0f), new Vector3(1f, 0f, 0f), new Vector3(0.7071068f, 0f, -0.7071068f), new Vector3(0.7071068f, 0f, 0.7071068f), new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0f),
            new Vector3(0f, 1f, 0f), new Vector3(0f, 0.7071068f, -0.7071068f), new Vector3(0f, 0.7071068f, 0.7071068f), new Vector3(0f, 1f, 0f), new Vector3(-0.7071068f, 0.7071068f, 0f), new Vector3(-0.5773503f, 0.5773503f, -0.5773503f), new Vector3(-0.5773503f, 0.5773503f, 0.5773503f), new Vector3(-0.7071068f, 0.7071068f, 0f), new Vector3(0.7071068f, 0.7071068f, 0f), new Vector3(0.5773503f, 0.5773503f, -0.5773503f), new Vector3(0.5773503f, 0.5773503f, 0.5773503f), new Vector3(0.7071068f, 0.7071068f, 0f), new Vector3(0f, 1f, 0f), new Vector3(0f, 0.7071068f, -0.7071068f), new Vector3(0f, 0.7071068f, 0.7071068f), new Vector3(0f, 1f, 0f),
            new Vector3(0f, -1f, 0f), new Vector3(0f, -0.7071068f, -0.7071068f), new Vector3(0f, -0.7071068f, 0.7071068f), new Vector3(0f, -1f, 0f), new Vector3(-0.7071068f, -0.7071068f, 0f), new Vector3(-0.5773503f, -0.5773503f, -0.5773503f), new Vector3(-0.5773503f, -0.5773503f, 0.5773503f), new Vector3(-0.7071068f, -0.7071068f, 0f), new Vector3(0.7071068f, -0.7071068f, 0f), new Vector3(0.5773503f, -0.5773503f, -0.5773503f), new Vector3(0.5773503f, -0.5773503f, 0.5773503f), new Vector3(0.7071068f, -0.7071068f, 0f), new Vector3(0f, -1f, 0f), new Vector3(0f, -0.7071068f, -0.7071068f), new Vector3(0f, -0.7071068f, 0.7071068f), new Vector3(0f, -1f, 0f),
            new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0f), new Vector3(-1f, 0f, 0f), new Vector3(-0.7071068f, 0f, -0.7071068f), new Vector3(-0.7071068f, 0f, 0.7071068f), new Vector3(-1f, 0f, 0f), new Vector3(1f, 0f, 0f), new Vector3(0.7071068f, 0f, -0.7071068f), new Vector3(0.7071068f, 0f, 0.7071068f), new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0f)
        };
        public static readonly Vector3I[] DirectionsInt = new Vector3I[] { 
            new Vector3I(0, 0, 0), new Vector3I(0, 0, -1), new Vector3I(0, 0, 1), new Vector3I(0, 0, 0), new Vector3I(-1, 0, 0), new Vector3I(-1, 0, -1), new Vector3I(-1, 0, 1), new Vector3I(-1, 0, 0), new Vector3I(1, 0, 0), new Vector3I(1, 0, -1), new Vector3I(1, 0, 1), new Vector3I(1, 0, 0), new Vector3I(0, 0, 0), new Vector3I(0, 0, -1), new Vector3I(0, 0, 1), new Vector3I(0, 0, 0),
            new Vector3I(0, 1, 0), new Vector3I(0, 1, -1), new Vector3I(0, 1, 1), new Vector3I(0, 1, 0), new Vector3I(-1, 1, 0), new Vector3I(-1, 1, -1), new Vector3I(-1, 1, 1), new Vector3I(-1, 1, 0), new Vector3I(1, 1, 0), new Vector3I(1, 1, -1), new Vector3I(1, 1, 1), new Vector3I(1, 1, 0), new Vector3I(0, 1, 0), new Vector3I(0, 1, -1), new Vector3I(0, 1, 1), new Vector3I(0, 1, 0),
            new Vector3I(0, -1, 0), new Vector3I(0, -1, -1), new Vector3I(0, -1, 1), new Vector3I(0, -1, 0), new Vector3I(-1, -1, 0), new Vector3I(-1, -1, -1), new Vector3I(-1, -1, 1), new Vector3I(-1, -1, 0), new Vector3I(1, -1, 0), new Vector3I(1, -1, -1), new Vector3I(1, -1, 1), new Vector3I(1, -1, 0), new Vector3I(0, -1, 0), new Vector3I(0, -1, -1), new Vector3I(0, -1, 1), new Vector3I(0, -1, 0),
            new Vector3I(0, 0, 0), new Vector3I(0, 0, -1), new Vector3I(0, 0, 1), new Vector3I(0, 0, 0), new Vector3I(-1, 0, 0), new Vector3I(-1, 0, -1), new Vector3I(-1, 0, 1), new Vector3I(-1, 0, 0), new Vector3I(1, 0, 0), new Vector3I(1, 0, -1), new Vector3I(1, 0, 1), new Vector3I(1, 0, 0), new Vector3I(0, 0, 0), new Vector3I(0, 0, -1), new Vector3I(0, 0, 1), new Vector3I(0, 0, 0)
        };
        private static readonly int[] ForwardBackward;
        private static readonly int[] LeftRight;
        private static readonly int[] UpDown;

        static Base27Directions()
        {
            int[] numArray = new int[3];
            numArray[0] = 1;
            numArray[2] = 2;
            ForwardBackward = numArray;
            int[] numArray2 = new int[3];
            numArray2[0] = 4;
            numArray2[2] = 8;
            LeftRight = numArray2;
            int[] numArray3 = new int[3];
            numArray3[0] = 0x20;
            numArray3[2] = 0x10;
            UpDown = numArray3;
        }

        public static Direction GetDirection(Vector3 vec) => 
            GetDirection(ref vec);

        public static Direction GetDirection(Vector3I vec) => 
            GetDirection(ref vec);

        public static Direction GetDirection(ref Vector3 vec)
        {
            int num = 0;
            num += ForwardBackward[(int) Math.Round((double) (vec.Z + 1f))];
            num += LeftRight[(int) Math.Round((double) (vec.X + 1f))];
            num += UpDown[(int) Math.Round((double) (vec.Y + 1f))];
            return (Direction) ((byte) num);
        }

        public static Direction GetDirection(ref Vector3I vec)
        {
            int num = 0;
            num += ForwardBackward[vec.Z + 1];
            num += LeftRight[vec.X + 1];
            num += UpDown[vec.Y + 1];
            return (Direction) ((byte) num);
        }

        public static Direction GetForward(ref Quaternion rot)
        {
            Vector3 vector;
            Vector3.Transform(ref Vector3.Forward, ref rot, out vector);
            return GetDirection(ref vector);
        }

        public static Direction GetUp(ref Quaternion rot)
        {
            Vector3 vector;
            Vector3.Transform(ref Vector3.Up, ref rot, out vector);
            return GetDirection(ref vector);
        }

        public static Vector3 GetVector(int direction) => 
            Directions[direction];

        public static Vector3 GetVector(Direction dir) => 
            Directions[(int) dir];

        public static Vector3I GetVectorInt(int direction) => 
            DirectionsInt[direction];

        public static Vector3I GetVectorInt(Direction dir) => 
            DirectionsInt[(int) dir];

        public static bool IsBaseDirection(ref Vector3 vec) => 
            (((((vec.X * vec.X) + (vec.Y * vec.Y)) + (vec.Z * vec.Z)) - 1f) < 1E-05f);

        public static bool IsBaseDirection(ref Vector3I vec) => 
            (((((vec.X >= -1) && (vec.X <= 1)) && ((vec.Y >= -1) && (vec.Y <= 1))) && (vec.Z >= -1)) && (vec.Z <= 1));

        public static bool IsBaseDirection(Vector3 vec) => 
            IsBaseDirection(ref vec);

        [Flags]
        public enum Direction : byte
        {
            Backward = 2,
            Down = 0x20,
            Forward = 1,
            Left = 4,
            Right = 8,
            Up = 0x10
        }
    }
}

