namespace VRage.Game
{
    using System;

    public sealed class GameRelationAttribute : Attribute
    {
        public VRage.Game.Game RelatedTo;

        public GameRelationAttribute(VRage.Game.Game relatedTo)
        {
            this.RelatedTo = relatedTo;
        }
    }
}

