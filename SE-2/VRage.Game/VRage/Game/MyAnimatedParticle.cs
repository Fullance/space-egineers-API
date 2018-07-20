namespace VRage.Game
{
    using System;
    using VRage.Utils;
    using VRageMath;
    using VRageRender;
    using VRageRender.Animations;
    using VRageRender.Utils;

    public class MyAnimatedParticle
    {
        public MyAnimatedPropertyVector3 Acceleration;
        public MyAnimatedPropertyFloat AlphaCutout;
        public Vector3 Angle;
        public MyAnimatedPropertyInt ArrayIndex;
        public MyBillboard.BlendTypeEnum BlendType;
        public MyAnimatedPropertyVector4 Color = new MyAnimatedPropertyVector4();
        public float ColorIntensity;
        public float Life;
        private Vector3 m_actualAcceleration = Vector3.Zero;
        private Vector3 m_actualAngle;
        private Vector3 m_actualPivot = Vector3.Zero;
        private Vector3 m_actualPivotRotation;
        private Vector3D m_actualPosition;
        private int m_arrayIndex = -1;
        private float m_elapsedTime;
        private float m_elapsedTimeDivider;
        private MyParticleGeneration m_generation;
        private float m_normalizedTime;
        private Vector3D m_previousPosition;
        private Vector3 m_velocity;
        public MyAnimatedPropertyTransparentMaterial Material = new MyAnimatedPropertyTransparentMaterial();
        public MyAnimatedPropertyVector3 Pivot;
        public MyAnimatedPropertyVector3 PivotRotation;
        public MyQuadD Quad = new MyQuadD();
        public MyAnimatedPropertyFloat Radius = new MyAnimatedPropertyFloat();
        public MyAnimatedPropertyVector3 RotationSpeed;
        public float SoftParticleDistanceScale;
        public Vector3D StartPosition;
        public float Thickness;
        public MyParticleTypeEnum Type;

        public void AddMotionInheritance(ref float motionInheritance, ref MatrixD deltaMatrix)
        {
            Vector3D vectord = Vector3D.Transform(this.m_actualPosition, (MatrixD) deltaMatrix);
            this.m_actualPosition += (Vector3D) ((vectord - this.m_actualPosition) * ((double) motionInheritance));
            this.Velocity = Vector3.TransformNormal(this.Velocity, deltaMatrix);
        }

        public bool Draw(MyBillboard billboard)
        {
            if ((this.Pivot != null) && !MyParticlesManager.Paused)
            {
                if (this.PivotRotation != null)
                {
                    Matrix introduced56 = Matrix.CreateRotationX(MathHelper.ToRadians(this.m_actualPivotRotation.X) * 0.01666667f);
                    Matrix matrix = (introduced56 * Matrix.CreateRotationY(MathHelper.ToRadians(this.m_actualPivotRotation.Y) * 0.01666667f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(this.m_actualPivotRotation.Z) * 0.01666667f);
                    this.m_actualPivot = Vector3.TransformNormal(this.m_actualPivot, matrix);
                }
                this.m_actualPivot = (Vector3) Vector3D.TransformNormal(this.m_actualPivot, this.m_generation.GetEffect().WorldMatrix);
            }
            Vector3D vectord = this.m_actualPosition + this.m_actualPivot;
            billboard.DistanceSquared = (float) Vector3D.DistanceSquared(MyTransparentGeometry.Camera.Translation, vectord);
            if (billboard.DistanceSquared <= 0.1f)
            {
                return false;
            }
            float num = 1f;
            this.Radius.GetInterpolatedValue<float>(this.m_normalizedTime, out num);
            float num2 = 0f;
            if (this.AlphaCutout != null)
            {
                this.AlphaCutout.GetInterpolatedValue<float>(this.m_normalizedTime, out num2);
            }
            billboard.CustomViewProjection = -1;
            billboard.ParentID = uint.MaxValue;
            billboard.AlphaCutout = num2;
            billboard.UVOffset = Vector2.Zero;
            billboard.UVSize = Vector2.One;
            billboard.LocalType = MyBillboard.LocalTypeEnum.Custom;
            billboard.BlendType = this.BlendType;
            float num3 = 1f;
            Matrix identity = Matrix.Identity;
            Vector3 forward = Vector3.Forward;
            Vector3 vector2 = (Vector3) (this.m_actualPosition - this.m_previousPosition);
            float radiusBySpeed = (float) this.m_generation.RadiusBySpeed;
            if (radiusBySpeed > 0f)
            {
                float num5 = vector2.Length();
                num = Math.Max(num, (num * ((float) this.m_generation.RadiusBySpeed)) * num5);
            }
            if (this.Type == MyParticleTypeEnum.Point)
            {
                Vector2 radius = new Vector2(num, num);
                if (this.Thickness > 0f)
                {
                    radius.Y = this.Thickness;
                }
                if (this.m_generation.RotationReference == VRage.Game.MyRotationReference.Camera)
                {
                    identity = (Matrix.CreateFromAxisAngle((Vector3) MyTransparentGeometry.Camera.Right, this.m_actualAngle.X) * Matrix.CreateFromAxisAngle((Vector3) MyTransparentGeometry.Camera.Up, this.m_actualAngle.Y)) * Matrix.CreateFromAxisAngle((Vector3) MyTransparentGeometry.Camera.Forward, this.m_actualAngle.Z);
                    GetBillboardQuadRotated(billboard, ref vectord, radius, ref identity, (Vector3) MyTransparentGeometry.Camera.Left, (Vector3) MyTransparentGeometry.Camera.Up);
                }
                else if (this.m_generation.RotationReference == VRage.Game.MyRotationReference.Local)
                {
                    identity = (Matrix.CreateFromAxisAngle((Vector3) this.m_generation.GetEffect().WorldMatrix.Right, this.m_actualAngle.X) * Matrix.CreateFromAxisAngle((Vector3) this.m_generation.GetEffect().WorldMatrix.Up, this.m_actualAngle.Y)) * Matrix.CreateFromAxisAngle((Vector3) this.m_generation.GetEffect().WorldMatrix.Forward, this.m_actualAngle.Z);
                    GetBillboardQuadRotated(billboard, ref vectord, radius, ref identity, (Vector3) this.m_generation.GetEffect().WorldMatrix.Left, (Vector3) this.m_generation.GetEffect().WorldMatrix.Up);
                }
                else if (this.m_generation.RotationReference == VRage.Game.MyRotationReference.Velocity)
                {
                    if (vector2.LengthSquared() < 1E-05f)
                    {
                        return false;
                    }
                    Matrix matrix3 = Matrix.CreateFromDir(Vector3.Normalize(vector2));
                    Matrix introduced57 = Matrix.CreateFromAxisAngle(matrix3.Right, this.m_actualAngle.X);
                    identity = (introduced57 * Matrix.CreateFromAxisAngle(matrix3.Up, this.m_actualAngle.Y)) * Matrix.CreateFromAxisAngle(matrix3.Forward, this.m_actualAngle.Z);
                    GetBillboardQuadRotated(billboard, ref vectord, radius, ref identity, matrix3.Left, matrix3.Up);
                }
                else if (this.m_generation.RotationReference == VRage.Game.MyRotationReference.VelocityAndCamera)
                {
                    if (vector2.LengthSquared() < 0.0001f)
                    {
                        return false;
                    }
                    Vector3 vector4 = Vector3.Normalize(this.m_actualPosition - MyTransparentGeometry.Camera.Translation);
                    Vector3 vector5 = Vector3.Normalize(vector2);
                    Vector3 up = Vector3.Cross(Vector3.Cross(vector4, vector5), vector5);
                    Matrix matrix4 = Matrix.CreateWorld((Vector3) this.m_actualPosition, vector5, up);
                    Matrix introduced58 = Matrix.CreateFromAxisAngle(matrix4.Right, this.m_actualAngle.X);
                    identity = (introduced58 * Matrix.CreateFromAxisAngle(matrix4.Up, this.m_actualAngle.Y)) * Matrix.CreateFromAxisAngle(matrix4.Forward, this.m_actualAngle.Z);
                    GetBillboardQuadRotated(billboard, ref vectord, radius, ref identity, matrix4.Left, matrix4.Up);
                }
                else if (this.m_generation.RotationReference == VRage.Game.MyRotationReference.LocalAndCamera)
                {
                    Matrix matrix5;
                    Vector3 vector8 = Vector3.Normalize(this.m_actualPosition - MyTransparentGeometry.Camera.Translation);
                    Vector3 v = (Vector3) this.m_generation.GetEffect().WorldMatrix.Forward;
                    if (vector8.Dot(v) >= 0.9999f)
                    {
                        matrix5 = Matrix.CreateTranslation((Vector3) this.m_actualPosition);
                    }
                    else
                    {
                        Vector3 vector11 = Vector3.Cross(Vector3.Cross(vector8, v), v);
                        matrix5 = Matrix.CreateWorld((Vector3) this.m_actualPosition, v, vector11);
                    }
                    Matrix introduced59 = Matrix.CreateFromAxisAngle(matrix5.Right, this.m_actualAngle.X);
                    identity = (introduced59 * Matrix.CreateFromAxisAngle(matrix5.Up, this.m_actualAngle.Y)) * Matrix.CreateFromAxisAngle(matrix5.Forward, this.m_actualAngle.Z);
                    GetBillboardQuadRotated(billboard, ref vectord, radius, ref identity, matrix5.Left, matrix5.Up);
                }
            }
            else if (this.Type == MyParticleTypeEnum.Line)
            {
                if (MyUtils.IsZero(this.Velocity.LengthSquared(), 1E-05f))
                {
                    this.Velocity = MyUtils.GetRandomVector3Normalized();
                }
                MyQuadD retQuad = new MyQuadD();
                MyPolyLineD polyLine = new MyPolyLineD();
                if (vector2.LengthSquared() > 0f)
                {
                    polyLine.LineDirectionNormalized = MyUtils.Normalize(vector2);
                }
                else
                {
                    polyLine.LineDirectionNormalized = MyUtils.Normalize(this.Velocity);
                }
                if (this.m_actualAngle.Z != 0f)
                {
                    polyLine.LineDirectionNormalized = Vector3.TransformNormal(polyLine.LineDirectionNormalized, Matrix.CreateRotationY(this.m_actualAngle.Z));
                }
                polyLine.Point0 = vectord;
                polyLine.Point1.X = vectord.X - (polyLine.LineDirectionNormalized.X * num);
                polyLine.Point1.Y = vectord.Y - (polyLine.LineDirectionNormalized.Y * num);
                polyLine.Point1.Z = vectord.Z - (polyLine.LineDirectionNormalized.Z * num);
                if (this.m_actualAngle.LengthSquared() > 0f)
                {
                    polyLine.Point0.X -= (polyLine.LineDirectionNormalized.X * num) * 0.5f;
                    polyLine.Point0.Y -= (polyLine.LineDirectionNormalized.Y * num) * 0.5f;
                    polyLine.Point0.Z -= (polyLine.LineDirectionNormalized.Z * num) * 0.5f;
                    polyLine.Point1.X -= (polyLine.LineDirectionNormalized.X * num) * 0.5f;
                    polyLine.Point1.Y -= (polyLine.LineDirectionNormalized.Y * num) * 0.5f;
                    polyLine.Point1.Z -= (polyLine.LineDirectionNormalized.Z * num) * 0.5f;
                }
                polyLine.Thickness = this.Thickness;
                Vector3D translation = MyTransparentGeometry.Camera.Translation;
                MyUtils.GetPolyLineQuad(out retQuad, ref polyLine, translation);
                identity.Forward = polyLine.LineDirectionNormalized;
                billboard.Position0 = retQuad.Point0;
                billboard.Position1 = retQuad.Point1;
                billboard.Position2 = retQuad.Point2;
                billboard.Position3 = retQuad.Point3;
            }
            else
            {
                if (this.Type != MyParticleTypeEnum.Trail)
                {
                    throw new NotSupportedException(this.Type + " is not supported particle type");
                }
                if (this.Quad.Point0 == this.Quad.Point2)
                {
                    return false;
                }
                if (this.Quad.Point1 == this.Quad.Point3)
                {
                    return false;
                }
                if (this.Quad.Point0 == this.Quad.Point3)
                {
                    return false;
                }
                billboard.Position0 = this.Quad.Point0;
                billboard.Position1 = this.Quad.Point1;
                billboard.Position2 = this.Quad.Point2;
                billboard.Position3 = this.Quad.Point3;
            }
            if (this.m_generation.AlphaAnisotropic != null)
            {
                forward = Vector3.Normalize(Vector3.Cross((Vector3) (billboard.Position0 - billboard.Position1), (Vector3) (billboard.Position0 - billboard.Position2)));
                Vector3 vector12 = (Vector3) ((((billboard.Position0 + billboard.Position1) + billboard.Position2) + billboard.Position3) / 4.0);
                Vector3 vector13 = vector12 - MyTransparentGeometry.Camera.Translation;
                float num7 = Math.Abs(Vector3.Dot(Vector3.Normalize(vector13), forward)) * 2f;
                num7 *= num7;
                num7 *= num7;
                num3 = Math.Min(num7, 1f);
            }
            Vector4 one = Vector4.One;
            if (this.Color.GetKeysCount() > 0)
            {
                this.Color.GetInterpolatedValue<Vector4>(this.m_normalizedTime, out one);
            }
            if (this.m_arrayIndex != -1)
            {
                Vector3 arraySize = (Vector3) this.m_generation.ArraySize;
                if ((arraySize.X > 0f) && (arraySize.Y > 0f))
                {
                    int arrayOffset = (int) this.m_generation.ArrayOffset;
                    int num10 = (this.m_generation.ArrayModulo == null) ? (((int) arraySize.X) * ((int) arraySize.Y)) : ((int) this.m_generation.ArrayModulo);
                    this.m_arrayIndex = (this.m_arrayIndex % num10) + arrayOffset;
                    float x = 1f / arraySize.X;
                    float y = 1f / arraySize.Y;
                    int num13 = this.m_arrayIndex % ((int) arraySize.X);
                    int num14 = this.m_arrayIndex / ((int) arraySize.X);
                    billboard.UVOffset = new Vector2(x * num13, y * num14);
                    billboard.UVSize = new Vector2(x, y);
                }
            }
            MyTransparentMaterial errorMaterial = MyTransparentMaterials.ErrorMaterial;
            this.Material.GetInterpolatedValue<MyTransparentMaterial>(this.m_normalizedTime, out errorMaterial);
            if (errorMaterial != null)
            {
                billboard.Material = errorMaterial.Id;
            }
            billboard.Color = (Vector4) ((one * num3) * this.m_generation.GetEffect().UserColorMultiplier);
            billboard.ColorIntensity = this.ColorIntensity;
            billboard.SoftParticleDistanceScale = this.SoftParticleDistanceScale;
            return true;
        }

        private static void GetBillboardQuadRotated(MyBillboard billboard, ref Vector3D position, float radius, float angle)
        {
            float num = radius * ((float) Math.Cos((double) angle));
            float num2 = radius * ((float) Math.Sin((double) angle));
            Vector3D vectord = new Vector3D {
                X = (num * MyTransparentGeometry.Camera.Left.X) + (num2 * MyTransparentGeometry.Camera.Up.X),
                Y = (num * MyTransparentGeometry.Camera.Left.Y) + (num2 * MyTransparentGeometry.Camera.Up.Y),
                Z = (num * MyTransparentGeometry.Camera.Left.Z) + (num2 * MyTransparentGeometry.Camera.Up.Z)
            };
            Vector3D vectord2 = new Vector3D {
                X = (-num2 * MyTransparentGeometry.Camera.Left.X) + (num * MyTransparentGeometry.Camera.Up.X),
                Y = (-num2 * MyTransparentGeometry.Camera.Left.Y) + (num * MyTransparentGeometry.Camera.Up.Y),
                Z = (-num2 * MyTransparentGeometry.Camera.Left.Z) + (num * MyTransparentGeometry.Camera.Up.Z)
            };
            billboard.Position0.X = (position.X + vectord.X) + vectord2.X;
            billboard.Position0.Y = (position.Y + vectord.Y) + vectord2.Y;
            billboard.Position0.Z = (position.Z + vectord.Z) + vectord2.Z;
            billboard.Position1.X = (position.X - vectord.X) + vectord2.X;
            billboard.Position1.Y = (position.Y - vectord.Y) + vectord2.Y;
            billboard.Position1.Z = (position.Z - vectord.Z) + vectord2.Z;
            billboard.Position2.X = (position.X - vectord.X) - vectord2.X;
            billboard.Position2.Y = (position.Y - vectord.Y) - vectord2.Y;
            billboard.Position2.Z = (position.Z - vectord.Z) - vectord2.Z;
            billboard.Position3.X = (position.X + vectord.X) - vectord2.X;
            billboard.Position3.Y = (position.Y + vectord.Y) - vectord2.Y;
            billboard.Position3.Z = (position.Z + vectord.Z) - vectord2.Z;
        }

        private static void GetBillboardQuadRotated(MyBillboard billboard, ref Vector3D position, Vector2 radius, ref Matrix transform)
        {
            GetBillboardQuadRotated(billboard, ref position, radius, ref transform, (Vector3) MyTransparentGeometry.Camera.Left, (Vector3) MyTransparentGeometry.Camera.Up);
        }

        private static void GetBillboardQuadRotated(MyBillboard billboard, ref Vector3D position, Vector2 radius, ref Matrix transform, Vector3 left, Vector3 up)
        {
            Vector3 vector = new Vector3 {
                X = radius.X * left.X,
                Y = radius.X * left.Y,
                Z = radius.X * left.Z
            };
            Vector3 vector2 = new Vector3 {
                X = radius.Y * up.X,
                Y = radius.Y * up.Y,
                Z = radius.Y * up.Z
            };
            Vector3D vectord = Vector3.TransformNormal(vector + vector2, (Matrix) transform);
            Vector3D vectord2 = Vector3.TransformNormal(vector - vector2, (Matrix) transform);
            billboard.Position0.X = position.X + vectord.X;
            billboard.Position0.Y = position.Y + vectord.Y;
            billboard.Position0.Z = position.Z + vectord.Z;
            billboard.Position1.X = position.X - vectord2.X;
            billboard.Position1.Y = position.Y - vectord2.Y;
            billboard.Position1.Z = position.Z - vectord2.Z;
            billboard.Position2.X = position.X - vectord.X;
            billboard.Position2.Y = position.Y - vectord.Y;
            billboard.Position2.Z = position.Z - vectord.Z;
            billboard.Position3.X = position.X + vectord2.X;
            billboard.Position3.Y = position.Y + vectord2.Y;
            billboard.Position3.Z = position.Z + vectord2.Z;
        }

        public bool IsValid()
        {
            if (this.Life <= 0f)
            {
                return false;
            }
            return (((MyUtils.IsValid(this.StartPosition) && MyUtils.IsValid(this.Angle)) && (MyUtils.IsValid(this.Velocity) && MyUtils.IsValid(this.m_actualPosition))) && MyUtils.IsValid(this.m_actualAngle));
        }

        public void Start(MyParticleGeneration generation)
        {
            this.m_elapsedTime = 0f;
            this.m_normalizedTime = 0f;
            this.m_elapsedTimeDivider = 0.01666667f / this.Life;
            this.m_generation = generation;
            this.m_actualPosition = this.StartPosition;
            this.m_previousPosition = this.m_actualPosition;
            float x = MathHelper.ToRadians(this.Angle.X);
            float y = MathHelper.ToRadians(this.Angle.Y);
            this.m_actualAngle = new Vector3(x, y, MathHelper.ToRadians(this.Angle.Z));
            if (this.Pivot != null)
            {
                this.Pivot.GetInterpolatedValue<Vector3>(0f, out this.m_actualPivot);
            }
            if (this.PivotRotation != null)
            {
                this.PivotRotation.GetInterpolatedValue<Vector3>(0f, out this.m_actualPivotRotation);
            }
            this.m_arrayIndex = -1;
            if (this.ArrayIndex != null)
            {
                this.ArrayIndex.GetInterpolatedValue<int>(this.m_normalizedTime, out this.m_arrayIndex);
                int arrayOffset = (int) this.m_generation.ArrayOffset;
                Vector3 arraySize = (Vector3) this.m_generation.ArraySize;
                if ((arraySize.X > 0f) && (arraySize.Y > 0f))
                {
                    int num2 = (this.m_generation.ArrayModulo == null) ? (((int) arraySize.X) * ((int) arraySize.Y)) : ((int) this.m_generation.ArrayModulo);
                    this.m_arrayIndex = arrayOffset + (this.m_arrayIndex % num2);
                }
            }
        }

        public bool Update()
        {
            this.m_elapsedTime += 0.01666667f;
            if (this.m_elapsedTime >= this.Life)
            {
                return false;
            }
            this.m_normalizedTime += this.m_elapsedTimeDivider;
            this.m_velocity += (Vector3) ((this.m_generation.GetEffect().Gravity * ((float) this.m_generation.Gravity)) * 0.01666667f);
            this.m_previousPosition = this.m_actualPosition;
            this.m_actualPosition.X += this.Velocity.X * 0.01666667f;
            this.m_actualPosition.Y += this.Velocity.Y * 0.01666667f;
            this.m_actualPosition.Z += this.Velocity.Z * 0.01666667f;
            if (this.Pivot != null)
            {
                this.Pivot.GetInterpolatedValue<Vector3>(this.m_normalizedTime, out this.m_actualPivot);
            }
            if (this.Acceleration != null)
            {
                this.Acceleration.GetInterpolatedValue<Vector3>(this.m_normalizedTime, out this.m_actualAcceleration);
                Matrix identity = Matrix.Identity;
                if (this.m_generation.AccelerationReference == MyAccelerationReference.Camera)
                {
                    identity = (Matrix) MyTransparentGeometry.Camera;
                }
                else if (this.m_generation.AccelerationReference != MyAccelerationReference.Local)
                {
                    if (this.m_generation.AccelerationReference == MyAccelerationReference.Velocity)
                    {
                        Vector3 vector = (Vector3) (this.m_actualPosition - this.m_previousPosition);
                        if (vector.LengthSquared() < 1E-05f)
                        {
                            this.m_actualAcceleration = Vector3.Zero;
                        }
                        else
                        {
                            identity = Matrix.CreateFromDir(Vector3.Normalize(vector));
                        }
                    }
                    else if (this.m_generation.AccelerationReference == MyAccelerationReference.Gravity)
                    {
                        if (this.m_generation.GetEffect().Gravity.LengthSquared() < 1E-05f)
                        {
                            this.m_actualAcceleration = Vector3.Zero;
                        }
                        else
                        {
                            identity = Matrix.CreateFromDir(Vector3.Normalize(this.m_generation.GetEffect().Gravity));
                        }
                    }
                }
                this.m_actualAcceleration = Vector3.TransformNormal(this.m_actualAcceleration, identity);
                this.Velocity += (Vector3) (this.m_actualAcceleration * 0.01666667f);
            }
            if (this.RotationSpeed != null)
            {
                Vector3 vector2;
                this.RotationSpeed.GetInterpolatedValue<Vector3>(this.m_normalizedTime, out vector2);
                float x = MathHelper.ToRadians(vector2.X);
                float y = MathHelper.ToRadians(vector2.Y);
                this.m_actualAngle += (Vector3) (new Vector3(x, y, MathHelper.ToRadians(vector2.Z)) * 0.01666667f);
            }
            if (this.PivotRotation != null)
            {
                Vector3 vector3;
                this.PivotRotation.GetInterpolatedValue<Vector3>(this.m_normalizedTime, out vector3);
                this.m_actualPivotRotation += vector3;
            }
            if (this.ArrayIndex != null)
            {
                this.ArrayIndex.GetInterpolatedValue<int>(this.m_normalizedTime, out this.m_arrayIndex);
            }
            return true;
        }

        public Vector3D ActualPosition =>
            this.m_actualPosition;

        public float NormalizedTime =>
            this.m_normalizedTime;

        public Vector3 Velocity
        {
            get => 
                this.m_velocity;
            set
            {
                this.m_velocity = value;
            }
        }
    }
}

