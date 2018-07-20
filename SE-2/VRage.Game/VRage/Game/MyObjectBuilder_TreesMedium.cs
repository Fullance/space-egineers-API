namespace VRage.Game
{
    using ProtoBuf;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition(typeof(MyObjectBuilder_Trees), null), MyEnvironmentItems(typeof(MyObjectBuilder_Tree))]
    public class MyObjectBuilder_TreesMedium : MyObjectBuilder_Trees
    {
    }
}

