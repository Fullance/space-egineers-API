namespace VRage.Game
{
    using ProtoBuf;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition(typeof(MyObjectBuilder_DestroyableItems), null), MyEnvironmentItems(typeof(MyObjectBuilder_DestroyableItem)), ProtoContract]
    public class MyObjectBuilder_Bushes : MyObjectBuilder_EnvironmentItems
    {
    }
}

