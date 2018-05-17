namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    public class Base6Directions
    {
        private const float DIRECTION_EPSILON = 1E-05f;
        public static readonly Vector3[] Directions;
        public static readonly Direction[] EnumDirections;
        private static readonly int[] ForwardBackward;
        public static readonly Vector3I[] IntDirections;
        private static readonly Direction[] LeftDirections;
        private static readonly int[] LeftRight;
        private static readonly int[] UpDown;

        static Base6Directions()
        {
            Direction[] directionArray = new Direction[6];
            directionArray[1] = Direction.Backward;
            directionArray[2] = Direction.Left;
            directionArray[3] = Direction.Right;
            directionArray[4] = Direction.Up;
            directionArray[5] = Direction.Down;
            EnumDirections = directionArray;
            Directions = new Vector3[] { Vector3.Forward, Vector3.Backward, Vector3.Left, Vector3.Right, Vector3.Up, Vector3.Down };
            IntDirections = new Vector3I[] { Vector3I.Forward, Vector3I.Backward, Vector3I.Left, Vector3I.Right, Vector3I.Up, Vector3I.Down };
            Direction[] directionArray2 = new Direction[0x24];
            directionArray2[2] = Direction.Down;
            directionArray2[3] = Direction.Up;
            directionArray2[4] = Direction.Left;
            directionArray2[5] = Direction.Right;
            directionArray2[8] = Direction.Up;
            directionArray2[9] = Direction.Down;
            directionArray2[10] = Direction.Right;
            directionArray2[11] = Direction.Left;
            directionArray2[12] = Direction.Up;
            directionArray2[13] = Direction.Down;
            directionArray2[14] = Direction.Left;
            directionArray2[15] = Direction.Left;
            directionArray2[0x10] = Direction.Backward;
            directionArray2[0x12] = Direction.Down;
            directionArray2[0x13] = Direction.Up;
            directionArray2[20] = Direction.Left;
            directionArray2[0x15] = Direction.Left;
            directionArray2[0x17] = Direction.Backward;
            directionArray2[0x18] = Direction.Right;
            directionArray2[0x19] = Direction.Left;
            directionArray2[0x1b] = Direction.Backward;
            directionArray2[0x1c] = Direction.Left;
            directionArray2[0x1d] = Direction.Right;
            directionArray2[30] = Direction.Left;
            directionArray2[0x1f] = Direction.Right;
            directionArray2[0x20] = Direction.Backward;
            directionArray2[0x22] = Direction.Left;
            directionArray2[0x23] = Direction.Right;
            LeftDirections = directionArray2;
            int[] numArray = new int[3];
            numArray[2] = 1;
            ForwardBackward = numArray;
            int[] numArray2 = new int[3];
            numArray2[0] = 2;
            numArray2[2] = 3;
            LeftRight = numArray2;
            int[] numArray3 = new int[3];
            numArray3[0] = 5;
            numArray3[2] = 4;
            UpDown = numArray3;
        }

        private Base6Directions()
        {
        }

        public static Axis GetAxis(Direction direction) => 
            ((Axis) ((byte) (((byte) direction) >> 1)));

        public static Direction GetBaseAxisDirection(Axis axis) => 
            ((Direction) ((byte) (((byte) axis) << 1)));

        public static Direction GetClosestDirection(Vector3 vec) => 
            GetClosestDirection(ref vec);

        public static Direction GetClosestDirection(ref Vector3 vec) => 
            GetDirection(ref Vector3.Sign(Vector3.DominantAxisProjection(vec)));

        public static Direction GetCross(Direction dir1, Direction dir2) => 
            GetLeft(dir1, dir2);

        public static Direction GetDirection(Vector3 vec) => 
            GetDirection(ref vec);

        public static Direction GetDirection(ref Vector3 vec)
        {
            int num = 0;
            num += ForwardBackward[(int) Math.Round((double) (vec.Z + 1f))];
            num += LeftRight[(int) Math.Round((double) (vec.X + 1f))];
            num += UpDown[(int) Math.Round((double) (vec.Y + 1f))];
            return (Direction) ((byte) num);
        }

        public static Direction GetDirection(Vector3I vec) => 
            GetDirection(ref vec);

        public static Direction GetDirection(ref Vector3I vec)
        {
            int num = 0;
            num += ForwardBackward[vec.Z + 1];
            num += LeftRight[vec.X + 1];
            num += UpDown[vec.Y + 1];
            return (Direction) ((byte) num);
        }

        public static DirectionFlags GetDirectionFlag(Direction dir) => 
            ((DirectionFlags) ((byte) (((int) 1) << dir)));

        public static Direction GetDirectionInAxis(Vector3 vec, Axis axis) => 
            GetDirectionInAxis(ref vec, axis);

        public static unsafe Direction GetDirectionInAxis(ref Vector3 vec, Axis axis)
        {
            Direction baseAxisDirection = GetBaseAxisDirection(axis);
            Vector3 vector = *((Vector3*) &(IntDirections[(int) baseAxisDirection]));
            vector *= vec;
            if (((vector.X + vector.Y) + vector.Z) >= 1f)
            {
                return baseAxisDirection;
            }
            return GetFlippedDirection(baseAxisDirection);
        }

        public static Direction GetFlippedDirection(Direction toFlip) => 
            ((Direction) ((byte) (toFlip ^ Direction.Backward)));

        public static Direction GetForward(Quaternion rot)
        {
            Vector3 vector;
            Vector3.Transform(ref Vector3.Forward, ref rot, out vector);
            return GetDirection(ref vector);
        }

        public static Direction GetForward(ref Matrix rotation)
        {
            Vector3 vector;
            Vector3.TransformNormal(ref Vector3.Forward, ref rotation, out vector);
            return GetDirection(ref vector);
        }

        public static Direction GetForward(ref Quaternion rot)
        {
            Vector3 vector;
            Vector3.Transform(ref Vector3.Forward, ref rot, out vector);
            return GetDirection(ref vector);
        }

        public static Vector3I GetIntVector(int direction)
        {
            direction = direction % 6;
            return IntDirections[direction];
        }

        public static Vector3I GetIntVector(Direction dir)
        {
            int index = (int) (dir % (Direction.Forward | Direction.Left | Direction.Up));
            return IntDirections[index];
        }

        public static Direction GetLeft(Direction up, Direction forward) => 
            LeftDirections[(int) ((forward * (Direction.Forward | Direction.Left | Direction.Up)) + up)];

        public static Direction GetOppositeDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.Backward:
                    return Direction.Forward;

                case Direction.Left:
                    return Direction.Right;

                case Direction.Right:
                    return Direction.Left;

                case Direction.Up:
                    return Direction.Down;

                case Direction.Down:
                    return Direction.Up;
            }
            return Direction.Backward;
        }

        public static Quaternion GetOrientation(Direction forward, Direction up)
        {
            Vector3 vector = GetVector(forward);
            Vector3 vector2 = GetVector(up);
            return Quaternion.CreateFromForwardUp(vector, vector2);
        }

        public static Direction GetPerpendicular(Direction dir)
        {
            if (GetAxis(dir) == Axis.UpDown)
            {
                return Direction.Right;
            }
            return Direction.Up;
        }

        public static Direction GetUp(Quaternion rot)
        {
            Vector3 vector;
            Vector3.Transform(ref Vector3.Up, ref rot, out vector);
            return GetDirection(ref vector);
        }

        public static Direction GetUp(ref Matrix rotation)
        {
            Vector3 vector;
            Vector3.TransformNormal(ref Vector3.Up, ref rotation, out vector);
            return GetDirection(ref vector);
        }

        public static Direction GetUp(ref Quaternion rot)
        {
            Vector3 vector;
            Vector3.Transform(ref Vector3.Up, ref rot, out vector);
            return GetDirection(ref vector);
        }

        public static Vector3 GetVector(int direction)
        {
            direction = direction % 6;
            return Directions[direction];
        }

        public static Vector3 GetVector(Direction dir) => 
            GetVector((int) dir);

        public static void GetVector(Direction dir, out Vector3 result)
        {
            int index = (int) (dir % (Direction.Forward | Direction.Left | Direction.Up));
            result = Directions[index];
        }

        public static bool IsBaseDirection(ref Vector3 vec) => 
            (((((vec.X * vec.X) + (vec.Y * vec.Y)) + (vec.Z * vec.Z)) - 1f) < 1E-05f);

        public static bool IsBaseDirection(Vector3 vec) => 
            IsBaseDirection(ref vec);

        public static bool IsBaseDirection(ref Vector3I vec) => 
            (((((vec.X * vec.X) + (vec.Y * vec.Y)) + (vec.Z * vec.Z)) - 1) == 0);

        public static bool IsValidBlockOrientation(Direction forward, Direction up) => 
            (((forward <= Direction.Down) && (up <= Direction.Down)) && (Vector3.Dot(GetVector(forward), GetVector(up)) == 0f));

        public enum Axis : byte
        {
            ForwardBackward = 0,
            LeftRight = 1,
            UpDown = 2
        }

        public enum Direction : byte
        {
            Backward = 1,
            Down = 5,
            Forward = 0,
            Left = 2,
            Right = 3,
            Up = 4
        }

        [Flags]
        public enum DirectionFlags : byte
        {
            All = 0x3f,
            Backward = 2,
            Down = 0x20,
            Forward = 1,
            Left = 4,
            Right = 8,
            Up = 0x10
        }
    }
}

