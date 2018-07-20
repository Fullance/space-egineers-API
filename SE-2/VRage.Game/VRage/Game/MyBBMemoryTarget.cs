namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRageMath;

    [XmlType("MyBBMemoryTarget"), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyBBMemoryTarget : MyBBMemoryValue
    {
        [ProtoMember(0x17)]
        public ushort? CompoundId = null;
        [ProtoMember(14)]
        public long? EntityId = null;
        [ProtoMember(0x11)]
        public Vector3D? Position = null;
        [ProtoMember(11)]
        public MyAiTargetEnum TargetType;
        [ProtoMember(20)]
        public int? TreeId = null;

        public static void SetTargetCompoundBlock(ref MyBBMemoryTarget target, Vector3I blockPosition, long entityId, ushort compoundId)
        {
            if (target == null)
            {
                target = new MyBBMemoryTarget();
            }
            target.TargetType = MyAiTargetEnum.COMPOUND_BLOCK;
            target.EntityId = new long?(entityId);
            target.CompoundId = new ushort?(compoundId);
            target.Position = new Vector3D?((Vector3D) blockPosition);
        }

        public static void SetTargetCube(ref MyBBMemoryTarget target, Vector3I blockPosition, long gridEntityId)
        {
            if (target == null)
            {
                target = new MyBBMemoryTarget();
            }
            target.TargetType = MyAiTargetEnum.CUBE;
            target.EntityId = new long?(gridEntityId);
            target.TreeId = null;
            target.Position = new Vector3D(blockPosition);
        }

        public static void SetTargetEntity(ref MyBBMemoryTarget target, MyAiTargetEnum targetType, long entityId, Vector3D? position = new Vector3D?())
        {
            if (target == null)
            {
                target = new MyBBMemoryTarget();
            }
            target.TargetType = targetType;
            target.EntityId = new long?(entityId);
            target.TreeId = null;
            target.Position = position;
        }

        public static void SetTargetPosition(ref MyBBMemoryTarget target, Vector3D position)
        {
            if (target == null)
            {
                target = new MyBBMemoryTarget();
            }
            target.TargetType = MyAiTargetEnum.POSITION;
            target.EntityId = null;
            target.TreeId = null;
            target.Position = new Vector3D?(position);
        }

        public static void SetTargetTree(ref MyBBMemoryTarget target, Vector3D treePosition, long entityId, int treeId)
        {
            if (target == null)
            {
                target = new MyBBMemoryTarget();
            }
            target.TargetType = MyAiTargetEnum.ENVIRONMENT_ITEM;
            target.EntityId = new long?(entityId);
            target.TreeId = new int?(treeId);
            target.Position = new Vector3D?(treePosition);
        }

        public static void SetTargetVoxel(ref MyBBMemoryTarget target, Vector3I voxelPosition, long entityId)
        {
            if (target == null)
            {
                target = new MyBBMemoryTarget();
            }
            target.TargetType = MyAiTargetEnum.VOXEL;
            target.EntityId = new long?(entityId);
            target.TreeId = null;
            target.Position = new Vector3D(voxelPosition);
        }

        public static void UnsetTarget(ref MyBBMemoryTarget target)
        {
            if (target == null)
            {
                target = new MyBBMemoryTarget();
            }
            target.TargetType = MyAiTargetEnum.NO_TARGET;
        }

        public Vector3I BlockPosition =>
            Vector3I.Round(this.Position.Value);

        public Vector3I VoxelPosition =>
            Vector3I.Round(this.Position.Value);
    }
}

