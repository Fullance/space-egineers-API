namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MatrixI
    {
        public Base6Directions.Direction Right;
        public Base6Directions.Direction Up;
        public Base6Directions.Direction Backward;
        public Vector3I Translation;
        public Base6Directions.Direction Left
        {
            get => 
                Base6Directions.GetFlippedDirection(this.Right);
            set
            {
                this.Right = Base6Directions.GetFlippedDirection(value);
            }
        }
        public Base6Directions.Direction Down
        {
            get => 
                Base6Directions.GetFlippedDirection(this.Up);
            set
            {
                this.Up = Base6Directions.GetFlippedDirection(value);
            }
        }
        public Base6Directions.Direction Forward
        {
            get => 
                Base6Directions.GetFlippedDirection(this.Backward);
            set
            {
                this.Backward = Base6Directions.GetFlippedDirection(value);
            }
        }
        public Base6Directions.Direction GetDirection(Base6Directions.Direction direction)
        {
            switch (direction)
            {
                case Base6Directions.Direction.Backward:
                    return this.Backward;

                case Base6Directions.Direction.Left:
                    return this.Left;

                case Base6Directions.Direction.Right:
                    return this.Right;

                case Base6Directions.Direction.Up:
                    return this.Up;

                case Base6Directions.Direction.Down:
                    return this.Down;
            }
            return this.Forward;
        }

        public void SetDirection(Base6Directions.Direction dirToSet, Base6Directions.Direction newDirection)
        {
            switch (dirToSet)
            {
                case Base6Directions.Direction.Forward:
                    this.Forward = newDirection;
                    return;

                case Base6Directions.Direction.Backward:
                    this.Backward = newDirection;
                    return;

                case Base6Directions.Direction.Left:
                    this.Left = newDirection;
                    return;

                case Base6Directions.Direction.Right:
                    this.Right = newDirection;
                    return;

                case Base6Directions.Direction.Up:
                    this.Up = newDirection;
                    return;

                case Base6Directions.Direction.Down:
                    this.Down = newDirection;
                    return;
            }
        }

        public Vector3I RightVector
        {
            get => 
                Base6Directions.GetIntVector(this.Right);
            set
            {
                this.Right = Base6Directions.GetDirection(value);
            }
        }
        public Vector3I LeftVector
        {
            get => 
                Base6Directions.GetIntVector(this.Left);
            set
            {
                this.Left = Base6Directions.GetDirection(value);
            }
        }
        public Vector3I UpVector
        {
            get => 
                Base6Directions.GetIntVector(this.Up);
            set
            {
                this.Up = Base6Directions.GetDirection(value);
            }
        }
        public Vector3I DownVector
        {
            get => 
                Base6Directions.GetIntVector(this.Down);
            set
            {
                this.Down = Base6Directions.GetDirection(value);
            }
        }
        public Vector3I BackwardVector
        {
            get => 
                Base6Directions.GetIntVector(this.Backward);
            set
            {
                this.Backward = Base6Directions.GetDirection(value);
            }
        }
        public Vector3I ForwardVector
        {
            get => 
                Base6Directions.GetIntVector(this.Forward);
            set
            {
                this.Forward = Base6Directions.GetDirection(value);
            }
        }
        public MatrixI(ref Vector3I position, Base6Directions.Direction forward, Base6Directions.Direction up)
        {
            this.Translation = position;
            this.Right = Base6Directions.GetFlippedDirection(Base6Directions.GetLeft(up, forward));
            this.Up = up;
            this.Backward = Base6Directions.GetFlippedDirection(forward);
        }

        public MatrixI(Vector3I position, Base6Directions.Direction forward, Base6Directions.Direction up)
        {
            this.Translation = position;
            this.Right = Base6Directions.GetFlippedDirection(Base6Directions.GetLeft(up, forward));
            this.Up = up;
            this.Backward = Base6Directions.GetFlippedDirection(forward);
        }

        public MatrixI(Base6Directions.Direction forward, Base6Directions.Direction up) : this(Vector3I.Zero, forward, up)
        {
        }

        public MatrixI(ref Vector3I position, ref Vector3I forward, ref Vector3I up) : this(ref position, Base6Directions.GetDirection(ref forward), Base6Directions.GetDirection(ref up))
        {
        }

        public MatrixI(ref Vector3I position, ref Vector3 forward, ref Vector3 up) : this(ref position, Base6Directions.GetDirection(ref forward), Base6Directions.GetDirection(ref up))
        {
        }

        public MatrixI(MyBlockOrientation orientation) : this(Vector3I.Zero, orientation.Forward, orientation.Up)
        {
        }

        public MyBlockOrientation GetBlockOrientation() => 
            new MyBlockOrientation(this.Forward, this.Up);

        public Matrix GetFloatMatrix() => 
            Matrix.CreateWorld(new Vector3(this.Translation), Base6Directions.GetVector(this.Forward), Base6Directions.GetVector(this.Up));

        public static MatrixI CreateRotation(Base6Directions.Direction oldA, Base6Directions.Direction oldB, Base6Directions.Direction newA, Base6Directions.Direction newB)
        {
            MatrixI xi = new MatrixI {
                Translation = Vector3I.Zero
            };
            Base6Directions.Direction cross = Base6Directions.GetCross(oldA, oldB);
            Base6Directions.Direction newDirection = Base6Directions.GetCross(newA, newB);
            xi.SetDirection(oldA, newA);
            xi.SetDirection(oldB, newB);
            xi.SetDirection(cross, newDirection);
            return xi;
        }

        public static void Invert(ref MatrixI matrix, out MatrixI result)
        {
            result = new MatrixI();
            switch (matrix.Right)
            {
                case Base6Directions.Direction.Forward:
                    result.Backward = Base6Directions.Direction.Left;
                    break;

                case Base6Directions.Direction.Backward:
                    result.Backward = Base6Directions.Direction.Right;
                    break;

                case Base6Directions.Direction.Up:
                    result.Up = Base6Directions.Direction.Right;
                    break;

                case Base6Directions.Direction.Down:
                    result.Up = Base6Directions.Direction.Left;
                    break;

                default:
                    result.Right = matrix.Right;
                    break;
            }
            switch (matrix.Up)
            {
                case Base6Directions.Direction.Forward:
                    result.Backward = Base6Directions.Direction.Down;
                    break;

                case Base6Directions.Direction.Backward:
                    result.Backward = Base6Directions.Direction.Up;
                    break;

                case Base6Directions.Direction.Left:
                    result.Right = Base6Directions.Direction.Down;
                    break;

                case Base6Directions.Direction.Right:
                    result.Right = Base6Directions.Direction.Up;
                    break;

                default:
                    result.Up = matrix.Up;
                    break;
            }
            switch (matrix.Backward)
            {
                case Base6Directions.Direction.Left:
                    result.Right = Base6Directions.Direction.Forward;
                    break;

                case Base6Directions.Direction.Right:
                    result.Right = Base6Directions.Direction.Backward;
                    break;

                case Base6Directions.Direction.Up:
                    result.Up = Base6Directions.Direction.Backward;
                    break;

                case Base6Directions.Direction.Down:
                    result.Up = Base6Directions.Direction.Forward;
                    break;

                default:
                    result.Backward = matrix.Backward;
                    break;
            }
            Vector3I.TransformNormal(ref matrix.Translation, ref result, out result.Translation);
            result.Translation = -result.Translation;
        }

        public static void Multiply(ref MatrixI leftMatrix, ref MatrixI rightMatrix, out MatrixI result)
        {
            Vector3I vectori4;
            Vector3I vectori5;
            Vector3I vectori6;
            result = new MatrixI();
            Vector3I rightVector = leftMatrix.RightVector;
            Vector3I upVector = leftMatrix.UpVector;
            Vector3I backwardVector = leftMatrix.BackwardVector;
            Vector3I.TransformNormal(ref rightVector, ref rightMatrix, out vectori4);
            Vector3I.TransformNormal(ref upVector, ref rightMatrix, out vectori5);
            Vector3I.TransformNormal(ref backwardVector, ref rightMatrix, out vectori6);
            Vector3I.Transform(ref leftMatrix.Translation, ref rightMatrix, out result.Translation);
            result.RightVector = vectori4;
            result.UpVector = vectori5;
            result.BackwardVector = vectori6;
        }

        public static MyBlockOrientation Transform(ref MyBlockOrientation orientation, ref MatrixI transform)
        {
            Base6Directions.Direction forward = transform.GetDirection(orientation.Forward);
            return new MyBlockOrientation(forward, transform.GetDirection(orientation.Up));
        }
    }
}

