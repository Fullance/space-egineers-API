namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using VRage.Game.Utils;
    using VRage.Generics;
    using VRage.Utils;
    using VRageMath;
    using VRageRender;

    public class MyTransparentGeometry
    {
        private static readonly MyObjectsPool<MyAnimatedParticle> m_animatedParticles = new MyObjectsPool<MyAnimatedParticle>(0xaef, null);
        private static MyCamera m_camera;
        private const int MAX_NEW_PARTICLES_COUNT = 0xaef;
        private const int MAX_TRANSPARENT_GEOMETRY_COUNT = 0xfa0;

        public static MyAnimatedParticle AddAnimatedParticle()
        {
            MyAnimatedParticle item = null;
            m_animatedParticles.AllocateOrCreate(out item);
            return item;
        }

        public static bool AddAttachedQuad(MyStringId material, ref MyQuadD quad, Vector4 color, ref Vector3D vctPos, uint renderObjectID, MyBillboard.BlendTypeEnum blendType = 0, List<MyBillboard> persistentBillboards = null)
        {
            MyBillboard billboard;
            if (!IsEnabled)
            {
                return false;
            }
            if (persistentBillboards == null)
            {
                MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
            }
            else
            {
                billboard = MyRenderProxy.AddPersistentBillboard();
                persistentBillboards.Add(billboard);
            }
            CreateBillboard(billboard, ref quad, material, ref color, ref vctPos, -1, 0f);
            billboard.ParentID = renderObjectID;
            billboard.BlendType = blendType;
            MyRenderProxy.AddBillboard(billboard);
            return true;
        }

        public static MyBillboard AddBillboardEffect(MyParticleEffect effect)
        {
            MyBillboard billboard;
            MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
            if (billboard != null)
            {
                billboard.DistanceSquared = (float) Vector3D.DistanceSquared(Camera.Translation, effect.WorldMatrix.Translation);
                billboard.CustomViewProjection = -1;
            }
            return billboard;
        }

        public static void AddBillboardOriented(MyStringId material, Vector4 color, Vector3D origin, Vector3 leftVector, Vector3 upVector, float width, float height)
        {
            AddBillboardOriented(material, color, origin, leftVector, upVector, width, height, Vector2.Zero, MyBillboard.BlendTypeEnum.Standard, -1, 0f, null);
        }

        public static void AddBillboardOriented(MyStringId material, Vector4 color, Vector3D origin, Vector3 leftVector, Vector3 upVector, float radius, int customProjection, MyBillboard.BlendTypeEnum blendType = 0)
        {
            AddBillboardOriented(material, color, origin, leftVector, upVector, radius, blendType, customProjection, 0f);
        }

        public static void AddBillboardOriented(MyStringId material, Vector4 color, Vector3D origin, Vector3 leftVector, Vector3 upVector, float radius, MyBillboard.BlendTypeEnum blendType = 0, int customViewProjection = -1, float reflection = 0f)
        {
            if (IsEnabled)
            {
                AddBillboardOriented(material, color, origin, leftVector, upVector, radius, radius, Vector2.Zero, blendType, customViewProjection, reflection, null);
            }
        }

        public static void AddBillboardOriented(MyStringId material, Vector4 color, Vector3D origin, Vector3 leftVector, Vector3 upVector, float width, float height, Vector2 uvOffset, MyBillboard.BlendTypeEnum blendType = 0, int customViewProjection = -1, float reflection = 0f, List<MyBillboard> persistentBillboards = null)
        {
            if (IsEnabled)
            {
                MyBillboard billboard;
                MyQuadD dd;
                if (persistentBillboards == null)
                {
                    MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
                }
                else
                {
                    billboard = MyRenderProxy.AddPersistentBillboard();
                    persistentBillboards.Add(billboard);
                }
                MyUtils.GetBillboardQuadOriented(out dd, ref origin, width, height, ref leftVector, ref upVector);
                CreateBillboard(billboard, ref dd, material, ref color, ref origin, uvOffset, customViewProjection, 0f);
                billboard.BlendType = blendType;
                billboard.Reflectivity = reflection;
                MyRenderProxy.AddBillboard(billboard);
            }
        }

        public static void AddBillboardOrientedCull(Vector3 cameraPos, MyStringId material, Vector4 color, Vector3 origin, Vector3 leftVector, Vector3 upVector, float radius, int customViewProjection = -1, float reflection = 0f)
        {
            if (Vector3.Dot(Vector3.Cross(leftVector, upVector), origin - cameraPos) > 0f)
            {
                AddBillboardOriented(material, color, origin, leftVector, upVector, radius, MyBillboard.BlendTypeEnum.Standard, customViewProjection, reflection);
            }
        }

        public static MyBillboard AddBillboardParticle(MyAnimatedParticle particle)
        {
            MyBillboard billboard;
            MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
            if (billboard == null)
            {
                return billboard;
            }
            billboard.BlendType = MyBillboard.BlendTypeEnum.Standard;
            if (particle.Draw(billboard))
            {
                billboard.CustomViewProjection = -1;
                return billboard;
            }
            return null;
        }

        public static void AddLineBillboard(MyStringId material, Vector4 color, Vector3D origin, Vector3 directionNormalized, float length, float thickness, MyBillboard.BlendTypeEnum blendType = 0, int customViewProjection = -1, float intensity = 1f, List<MyBillboard> persistentBillboards = null)
        {
            AddLineBillboard(material, color, origin, uint.MaxValue, ref MatrixD.Identity, directionNormalized, length, thickness, blendType, customViewProjection, intensity, persistentBillboards);
        }

        public static void AddLineBillboard(MyStringId material, Vector4 color, Vector3D origin, uint renderObjectID, ref MatrixD worldToLocal, Vector3 directionNormalized, float length, float thickness, MyBillboard.BlendTypeEnum blendType = 0, int customViewProjection = -1, float intensity = 1f, List<MyBillboard> persistentBillboards = null)
        {
            if (IsEnabled)
            {
                MyBillboard billboard;
                MyPolyLineD ed;
                MyDebug.AssertIsValid((Vector3) origin);
                MyDebug.AssertIsValid(length);
                if (persistentBillboards == null)
                {
                    MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
                }
                else
                {
                    billboard = MyRenderProxy.AddPersistentBillboard();
                    persistentBillboards.Add(billboard);
                }
                billboard.BlendType = blendType;
                billboard.UVOffset = Vector2.Zero;
                billboard.UVSize = Vector2.One;
                billboard.LocalType = MyBillboard.LocalTypeEnum.Custom;
                ed.LineDirectionNormalized = directionNormalized;
                ed.Point0 = origin;
                ed.Point1 = origin + ((Vector3D) (directionNormalized * length));
                ed.Thickness = thickness;
                Vector3D cameraPosition = (customViewProjection == -1) ? Camera.Translation : MyRenderProxy.BillboardsViewProjectionWrite[customViewProjection].CameraPosition;
                Vector3D vectord2 = cameraPosition - ed.Point0;
                if (!Vector3D.IsZero(vectord2, 1E-06))
                {
                    MyQuadD dd;
                    MyUtils.GetPolyLineQuad(out dd, ref ed, cameraPosition);
                    CreateBillboard(billboard, ref dd, material, ref color, ref origin, customViewProjection, 0f);
                    if (renderObjectID != uint.MaxValue)
                    {
                        Vector3D.Transform(ref billboard.Position0, ref worldToLocal, out billboard.Position0);
                        Vector3D.Transform(ref billboard.Position1, ref worldToLocal, out billboard.Position1);
                        Vector3D.Transform(ref billboard.Position2, ref worldToLocal, out billboard.Position2);
                        Vector3D.Transform(ref billboard.Position3, ref worldToLocal, out billboard.Position3);
                        billboard.ParentID = renderObjectID;
                    }
                    billboard.ColorIntensity = intensity;
                    MyRenderProxy.AddBillboard(billboard);
                }
            }
        }

        public static void AddLocalLineBillboard(MyStringId material, Vector4 color, Vector3D origin, uint renderObjectID, Vector3 directionNormalized, float length, float thickness, MyBillboard.BlendTypeEnum blendType = 0, int customViewProjection = -1, float intensity = 1f, List<MyBillboard> persistentBillboards = null)
        {
            if (IsEnabled)
            {
                MyBillboard billboard;
                MyDebug.AssertIsValid((Vector3) origin);
                MyDebug.AssertIsValid(length);
                if (persistentBillboards == null)
                {
                    MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
                }
                else
                {
                    billboard = MyRenderProxy.AddPersistentBillboard();
                    persistentBillboards.Add(billboard);
                }
                billboard.BlendType = blendType;
                billboard.UVOffset = Vector2.Zero;
                billboard.UVSize = Vector2.One;
                MyQuadD quad = new MyQuadD();
                CreateBillboard(billboard, ref quad, material, ref color, ref origin, customViewProjection, 0f);
                billboard.Position0 = origin;
                billboard.Position1 = directionNormalized;
                billboard.Position2 = new Vector3D((double) length, (double) thickness, 0.0);
                billboard.ParentID = renderObjectID;
                billboard.LocalType = MyBillboard.LocalTypeEnum.Line;
                billboard.ColorIntensity = intensity;
                MyRenderProxy.AddBillboard(billboard);
            }
        }

        public static void AddLocalPointBillboard(MyStringId material, Vector4 color, Vector3D origin, uint renderObjectID, float radius, float angle, MyBillboard.BlendTypeEnum blendType = 0, int customViewProjection = -1, float intensity = 1f, List<MyBillboard> persistentBillboards = null)
        {
            if (IsEnabled)
            {
                MyBillboard billboard;
                MyDebug.AssertIsValid((Vector3) origin);
                MyDebug.AssertIsValid(radius);
                if (persistentBillboards == null)
                {
                    MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
                }
                else
                {
                    billboard = MyRenderProxy.AddPersistentBillboard();
                    persistentBillboards.Add(billboard);
                }
                billboard.BlendType = blendType;
                billboard.UVOffset = Vector2.Zero;
                billboard.UVSize = Vector2.One;
                MyQuadD quad = new MyQuadD();
                CreateBillboard(billboard, ref quad, material, ref color, ref origin, customViewProjection, 0f);
                billboard.ColorIntensity = intensity;
                billboard.Position0 = origin;
                billboard.Position2 = new Vector3D((double) radius, (double) angle, 0.0);
                billboard.ParentID = renderObjectID;
                billboard.LocalType = MyBillboard.LocalTypeEnum.Point;
                MyRenderProxy.AddBillboard(billboard);
            }
        }

        public static void AddPointBillboard(MyStringId material, Vector4 color, Vector3D origin, float radius, float angle, int customViewProjection = -1, MyBillboard.BlendTypeEnum blendType = 0)
        {
            AddPointBillboard(material, color, origin, uint.MaxValue, ref MatrixD.Identity, radius, angle, customViewProjection, blendType, 1f, null);
        }

        public static void AddPointBillboard(MyStringId material, Vector4 color, Vector3D origin, uint renderObjectID, ref MatrixD worldToLocal, float radius, float angle, int customViewProjection = -1, MyBillboard.BlendTypeEnum blendType = 0, float intensity = 1f, List<MyBillboard> persistentBillboards = null)
        {
            if (IsEnabled)
            {
                MyQuadD dd;
                MyDebug.AssertIsValid((Vector3) origin);
                MyDebug.AssertIsValid(angle);
                Vector3D vectord = Camera.Translation - origin;
                if (MyUtils.GetBillboardQuadAdvancedRotated(out dd, origin, radius, radius, angle, origin + vectord))
                {
                    MyBillboard billboard;
                    if (persistentBillboards == null)
                    {
                        MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
                    }
                    else
                    {
                        billboard = MyRenderProxy.AddPersistentBillboard();
                        persistentBillboards.Add(billboard);
                    }
                    CreateBillboard(billboard, ref dd, material, ref color, ref origin, customViewProjection, 0f);
                    billboard.BlendType = blendType;
                    if (renderObjectID != uint.MaxValue)
                    {
                        Vector3D.Transform(ref billboard.Position0, ref worldToLocal, out billboard.Position0);
                        Vector3D.Transform(ref billboard.Position1, ref worldToLocal, out billboard.Position1);
                        Vector3D.Transform(ref billboard.Position2, ref worldToLocal, out billboard.Position2);
                        Vector3D.Transform(ref billboard.Position3, ref worldToLocal, out billboard.Position3);
                        billboard.ParentID = renderObjectID;
                    }
                    billboard.ColorIntensity = intensity;
                    MyRenderProxy.AddBillboard(billboard);
                }
            }
        }

        public static bool AddQuad(MyStringId material, ref MyQuadD quad, Vector4 color, ref Vector3D vctPos, int customViewProjection = -1, MyBillboard.BlendTypeEnum blendType = 0, List<MyBillboard> persistentBillboards = null)
        {
            MyBillboard billboard;
            if (!IsEnabled)
            {
                return false;
            }
            if (persistentBillboards == null)
            {
                MyRenderProxy.BillboardsPoolWrite.AllocateOrCreate(out billboard);
            }
            else
            {
                billboard = MyRenderProxy.AddPersistentBillboard();
                persistentBillboards.Add(billboard);
            }
            CreateBillboard(billboard, ref quad, material, ref color, ref vctPos, customViewProjection, 0f);
            billboard.BlendType = blendType;
            MyRenderProxy.AddBillboard(billboard);
            return true;
        }

        public static void AddTriangleBillboard(Vector3D p0, Vector3D p1, Vector3D p2, Vector3 n0, Vector3 n1, Vector3 n2, Vector2 uv0, Vector2 uv1, Vector2 uv2, MyStringId material, uint parentID, Vector3D worldPosition)
        {
            MyTriangleBillboard billboard;
            MyRenderProxy.TriangleBillboardsPoolWrite.AllocateOrCreate(out billboard);
            MyTransparentMaterial material2 = MyTransparentMaterials.GetMaterial(material);
            billboard.BlendType = MyBillboard.BlendTypeEnum.Standard;
            billboard.Position0 = p0;
            billboard.Position1 = p1;
            billboard.Position2 = p2;
            billboard.Position3 = p0;
            billboard.UV0 = uv0;
            billboard.UV1 = uv1;
            billboard.UV2 = uv2;
            billboard.Normal0 = n0;
            billboard.Normal1 = n1;
            billboard.Normal2 = n2;
            billboard.DistanceSquared = (float) Vector3D.DistanceSquared(Camera.Translation, worldPosition);
            billboard.Material = material;
            billboard.Color = material2.Color;
            billboard.ColorIntensity = 1f;
            billboard.CustomViewProjection = -1;
            billboard.Reflectivity = material2.Reflectivity;
            billboard.LocalType = MyBillboard.LocalTypeEnum.Custom;
            billboard.ParentID = parentID;
            MyRenderProxy.AddBillboard(billboard);
        }

        public static void AddTriangleBillboard(Vector3D p0, Vector3D p1, Vector3D p2, Vector3 n0, Vector3 n1, Vector3 n2, Vector2 uv0, Vector2 uv1, Vector2 uv2, MyStringId material, uint parentID, Vector3D worldPosition, Vector4 color)
        {
            MyTriangleBillboard billboard;
            MyRenderProxy.TriangleBillboardsPoolWrite.AllocateOrCreate(out billboard);
            MyTransparentMaterial material2 = MyTransparentMaterials.GetMaterial(material);
            billboard.BlendType = MyBillboard.BlendTypeEnum.Standard;
            billboard.Position0 = p0;
            billboard.Position1 = p1;
            billboard.Position2 = p2;
            billboard.Position3 = p0;
            billboard.UV0 = uv0;
            billboard.UV1 = uv1;
            billboard.UV2 = uv2;
            billboard.Normal0 = n0;
            billboard.Normal1 = n1;
            billboard.Normal2 = n2;
            billboard.DistanceSquared = (float) Vector3D.DistanceSquared(Camera.Translation, worldPosition);
            billboard.Material = material;
            billboard.Color = color;
            billboard.ColorIntensity = 1f;
            billboard.CustomViewProjection = -1;
            billboard.Reflectivity = material2.Reflectivity;
            billboard.ParentID = parentID;
            MyRenderProxy.AddBillboard(billboard);
        }

        public static void CreateBillboard(MyBillboard billboard, ref MyQuadD quad, MyStringId material, ref Vector4 color, ref Vector3D origin, int customViewProjection = -1, float reflection = 0f)
        {
            CreateBillboard(billboard, ref quad, material, ref color, ref origin, Vector2.Zero, customViewProjection, reflection);
        }

        public static void CreateBillboard(MyBillboard billboard, ref MyQuadD quad, MyStringId material, ref Vector4 color, ref Vector3D origin, Vector2 uvOffset, int customViewProjection = -1, float reflectivity = 0f)
        {
            if (!MyTransparentMaterials.ContainsMaterial(material))
            {
                material = MyTransparentMaterials.ErrorMaterial.Id;
                color = Vector4.One;
            }
            billboard.Material = material;
            billboard.LocalType = MyBillboard.LocalTypeEnum.Custom;
            billboard.Position0 = quad.Point0;
            billboard.Position1 = quad.Point1;
            billboard.Position2 = quad.Point2;
            billboard.Position3 = quad.Point3;
            billboard.UVOffset = uvOffset;
            billboard.UVSize = Vector2.One;
            Vector3D vectord = (customViewProjection == -1) ? Camera.Translation : MyRenderProxy.BillboardsViewProjectionWrite[customViewProjection].CameraPosition;
            billboard.DistanceSquared = (float) Vector3D.DistanceSquared(vectord, origin);
            billboard.Color = color.ToLinearRGB();
            billboard.ColorIntensity = 1f;
            billboard.Reflectivity = reflectivity;
            billboard.CustomViewProjection = customViewProjection;
            billboard.ParentID = uint.MaxValue;
            billboard.SoftParticleDistanceScale = 1f;
            MyTransparentMaterial material2 = MyTransparentMaterials.GetMaterial(billboard.Material);
            if (material2.AlphaMistingEnable)
            {
                billboard.Color = (Vector4) (billboard.Color * MathHelper.Clamp((float) ((((float) Math.Sqrt((double) billboard.DistanceSquared)) - material2.AlphaMistingStart) / (material2.AlphaMistingEnd - material2.AlphaMistingStart)), (float) 0f, (float) 1f));
            }
            billboard.Color *= material2.Color;
        }

        public static void DeallocateAnimatedParticle(MyAnimatedParticle particle)
        {
            m_animatedParticles.Deallocate(particle);
        }

        [Conditional("PARTICLE_PROFILING")]
        public static void EndParticleProfilingBlock()
        {
        }

        public static void LoadData()
        {
            MyLog.Default.WriteLine(string.Format("MyTransparentGeometry.LoadData - START", new object[0]));
            m_animatedParticles.DeallocateAll();
        }

        public static void SetCamera(MyCamera camera)
        {
            m_camera = camera;
        }

        [Conditional("PARTICLE_PROFILING")]
        public static void StartParticleProfilingBlock(string name)
        {
        }

        public static MatrixD Camera =>
            m_camera.WorldMatrix;

        public static MatrixD CameraView =>
            m_camera.ViewMatrix;

        public static bool HasCamera =>
            (m_camera != null);

        private static bool IsEnabled =>
            MyRenderProxy.DebugOverrides.BillboardsStatic;
    }
}

