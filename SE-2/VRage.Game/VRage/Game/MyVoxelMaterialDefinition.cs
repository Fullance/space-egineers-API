namespace VRage.Game
{
    using Medieval.ObjectBuilders.Definitions;
    using System;
    using System.Runtime.CompilerServices;
    using VRage;
    using VRage.Game.Definitions;
    using VRage.Utils;
    using VRageMath;
    using VRageRender;

    [MyDefinitionType(typeof(MyObjectBuilder_VoxelMaterialDefinition), (Type) null)]
    public class MyVoxelMaterialDefinition : MyDefinitionBase
    {
        public bool CanBeHarvested;
        public Vector3? ColorKey;
        public MyStringHash DamagedMaterial;
        public float DamageRatio;
        public string DiffuseXZ;
        public string DiffuseY;
        public float Friction;
        public bool IsRare;
        public string LandingEffect;
        private static byte m_indexCounter;
        private MyStringHash m_materialTypeNameHashCache;
        private MyStringId m_materialTypeNameIdCache;
        public string MaterialTypeName;
        public string MinedOre;
        public float MinedOreRatio;
        public int MinVersion;
        public string NormalXZ;
        public string NormalY;
        public string ParticleEffect;
        public MyRenderVoxelMaterialData RenderParams;
        public float Restitution;
        public bool SpawnsFromMeteorites;
        public bool SpawnsInAsteroids;
        public float SpecularPower;
        public float SpecularShininess;
        public string VoxelHandPreview;

        public void AssignIndex()
        {
            m_indexCounter = (byte) (m_indexCounter + 1);
            this.Index = m_indexCounter;
            this.RenderParams.Index = this.Index;
        }

        public override MyObjectBuilder_DefinitionBase GetObjectBuilder() => 
            null;

        protected override void Init(MyObjectBuilder_DefinitionBase ob)
        {
            base.Init(ob);
            MyObjectBuilder_Dx11VoxelMaterialDefinition definition = ob as MyObjectBuilder_Dx11VoxelMaterialDefinition;
            this.MaterialTypeName = definition.MaterialTypeName;
            this.MinedOre = definition.MinedOre;
            this.MinedOreRatio = definition.MinedOreRatio;
            this.CanBeHarvested = definition.CanBeHarvested;
            this.IsRare = definition.IsRare;
            this.SpawnsInAsteroids = definition.SpawnsInAsteroids;
            this.SpawnsFromMeteorites = definition.SpawnsFromMeteorites;
            this.DamageRatio = definition.DamageRatio;
            this.VoxelHandPreview = definition.VoxelHandPreview;
            this.DiffuseXZ = definition.DiffuseXZ;
            this.DiffuseY = definition.DiffuseY;
            this.NormalXZ = definition.NormalXZ;
            this.NormalY = definition.NormalY;
            this.SpecularPower = definition.SpecularPower;
            this.SpecularShininess = definition.SpecularShininess;
            this.MinVersion = definition.MinVersion;
            if (!string.IsNullOrEmpty(definition.ParticleEffect))
            {
                this.ParticleEffect = definition.ParticleEffect;
            }
            else
            {
                this.ParticleEffect = "";
            }
            this.DamagedMaterial = MyStringHash.GetOrCompute(definition.DamagedMaterial);
            this.Friction = definition.Friction;
            this.Restitution = definition.Restitution;
            this.LandingEffect = definition.LandingEffect;
            if (definition.ColorKey.HasValue)
            {
                this.ColorKey = new Vector3?(definition.ColorKey.Value.ColorToHSV());
            }
            this.RenderParams.Index = this.Index;
            this.RenderParams.TextureSets = new MyRenderVoxelMaterialData.TextureSet[3];
            this.RenderParams.TextureSets[0].ColorMetalXZnY = definition.ColorMetalXZnY;
            this.RenderParams.TextureSets[0].ColorMetalY = definition.ColorMetalY;
            this.RenderParams.TextureSets[0].NormalGlossXZnY = definition.NormalGlossXZnY;
            this.RenderParams.TextureSets[0].NormalGlossY = definition.NormalGlossY;
            this.RenderParams.TextureSets[0].ExtXZnY = definition.ExtXZnY;
            this.RenderParams.TextureSets[0].ExtY = definition.ExtY;
            this.RenderParams.TextureSets[0].Check();
            this.RenderParams.TextureSets[1].ColorMetalXZnY = definition.ColorMetalXZnYFar1 ?? this.RenderParams.TextureSets[0].ColorMetalXZnY;
            this.RenderParams.TextureSets[1].ColorMetalY = definition.ColorMetalYFar1 ?? this.RenderParams.TextureSets[1].ColorMetalXZnY;
            this.RenderParams.TextureSets[1].NormalGlossXZnY = definition.NormalGlossXZnYFar1 ?? this.RenderParams.TextureSets[0].NormalGlossXZnY;
            this.RenderParams.TextureSets[1].NormalGlossY = definition.NormalGlossYFar1 ?? this.RenderParams.TextureSets[1].NormalGlossXZnY;
            this.RenderParams.TextureSets[1].ExtXZnY = definition.ExtXZnYFar1 ?? this.RenderParams.TextureSets[0].ExtXZnY;
            this.RenderParams.TextureSets[1].ExtY = definition.ExtYFar1 ?? this.RenderParams.TextureSets[1].ExtXZnY;
            this.RenderParams.TextureSets[2].ColorMetalXZnY = definition.ColorMetalXZnYFar2 ?? this.RenderParams.TextureSets[1].ColorMetalXZnY;
            this.RenderParams.TextureSets[2].ColorMetalY = definition.ColorMetalYFar2 ?? this.RenderParams.TextureSets[2].ColorMetalXZnY;
            this.RenderParams.TextureSets[2].NormalGlossXZnY = definition.NormalGlossXZnYFar2 ?? this.RenderParams.TextureSets[1].NormalGlossXZnY;
            this.RenderParams.TextureSets[2].NormalGlossY = definition.NormalGlossYFar2 ?? this.RenderParams.TextureSets[2].NormalGlossXZnY;
            this.RenderParams.TextureSets[2].ExtXZnY = definition.ExtXZnYFar2 ?? this.RenderParams.TextureSets[1].ExtXZnY;
            this.RenderParams.TextureSets[2].ExtY = definition.ExtYFar2 ?? this.RenderParams.TextureSets[2].ExtXZnY;
            this.RenderParams.InitialScale = definition.InitialScale;
            this.RenderParams.ScaleMultiplier = definition.ScaleMultiplier;
            this.RenderParams.InitialDistance = definition.InitialDistance;
            this.RenderParams.DistanceMultiplier = definition.DistanceMultiplier;
            this.RenderParams.Far1Distance = definition.Far1Distance;
            this.RenderParams.Far2Distance = definition.Far2Distance;
            this.RenderParams.Far3Distance = definition.Far3Distance;
            this.RenderParams.Far1Scale = definition.Far1Scale;
            this.RenderParams.Far2Scale = definition.Far2Scale;
            this.RenderParams.Far3Scale = definition.Far3Scale;
            this.RenderParams.Far3Color = definition.Far3Color;
            this.RenderParams.ExtensionDetailScale = definition.ExtDetailScale;
            MyRenderFoliageData data = new MyRenderFoliageData();
            if (definition.FoliageColorTextureArray != null)
            {
                int length;
                data.Type = (MyFoliageType) definition.FoliageType;
                data.Density = definition.FoliageDensity;
                string[] foliageColorTextureArray = definition.FoliageColorTextureArray;
                string[] foliageNormalTextureArray = definition.FoliageNormalTextureArray;
                if (foliageNormalTextureArray != null)
                {
                    if (foliageColorTextureArray.Length != foliageNormalTextureArray.Length)
                    {
                        MyLog.Default.Warning("Legacy foliage format has different size normal and color arrays, only the minimum length will be used.", new object[0]);
                    }
                    length = Math.Min(foliageColorTextureArray.Length, foliageNormalTextureArray.Length);
                }
                else
                {
                    length = foliageColorTextureArray.Length;
                }
                length = Math.Min(length, 0x10);
                data.Entries = new MyRenderFoliageData.FoliageEntry[length];
                for (int i = 0; i < length; i++)
                {
                    data.Entries[i] = new MyRenderFoliageData.FoliageEntry { 
                        ColorAlphaTexture = foliageColorTextureArray[i],
                        NormalGlossTexture = (foliageNormalTextureArray != null) ? foliageNormalTextureArray[i] : null,
                        Probability = 1f,
                        Size = definition.FoliageScale,
                        SizeVariation = definition.FoliageRandomRescaleMult
                    };
                }
            }
            if (data.Density > 0f)
            {
                this.RenderParams.Foliage = new MyRenderFoliageData?(data);
            }
        }

        public static void ResetIndexing()
        {
            m_indexCounter = 0;
        }

        public void UpdateVoxelMaterial()
        {
            MyRenderVoxelMaterialData[] materials = new MyRenderVoxelMaterialData[] { this.RenderParams };
            MyRenderProxy.UpdateRenderVoxelMaterials(materials);
        }

        public bool HasDamageMaterial =>
            (this.DamagedMaterial != MyStringHash.NullOrEmpty);

        public string Icon
        {
            get
            {
                if ((base.Icons != null) && (base.Icons.Length > 0))
                {
                    return base.Icons[0];
                }
                return this.RenderParams.TextureSets[0].ColorMetalXZnY;
            }
        }

        public byte Index { get; set; }

        public MyStringHash MaterialTypeNameHash
        {
            get
            {
                if (this.m_materialTypeNameHashCache == new MyStringHash())
                {
                    this.m_materialTypeNameHashCache = MyStringHash.GetOrCompute(this.MaterialTypeName);
                }
                return this.m_materialTypeNameHashCache;
            }
        }

        public MyStringId MaterialTypeNameId
        {
            get
            {
                if (this.m_materialTypeNameIdCache == new MyStringId())
                {
                    this.m_materialTypeNameIdCache = MyStringId.GetOrCompute(this.MaterialTypeName);
                }
                return this.m_materialTypeNameIdCache;
            }
        }
    }
}

