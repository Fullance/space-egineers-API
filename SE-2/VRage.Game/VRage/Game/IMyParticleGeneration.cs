namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using VRageMath;
    using VRageRender.Animations;

    public interface IMyParticleGeneration
    {
        void Clear();
        void Close();
        IMyParticleGeneration CreateInstance(MyParticleEffect effect);
        void Deallocate();
        void Deserialize(XmlReader reader);
        void Done();
        void Draw(List<MyBillboard> collectedBillboards);
        IMyParticleGeneration Duplicate(MyParticleEffect effect);
        MyParticleEffect GetEffect();
        MyParticleEmitter GetEmitter();
        IEnumerable<IMyConstProperty> GetProperties();
        void MergeAABB(ref BoundingBoxD aabb);
        void Serialize(XmlWriter writer);
        void SetAnimDirty();
        void SetDirty();
        void Update();

        MyConstPropertyBool Enabled { get; }

        string Name { get; set; }

        bool Show { get; set; }
    }
}

