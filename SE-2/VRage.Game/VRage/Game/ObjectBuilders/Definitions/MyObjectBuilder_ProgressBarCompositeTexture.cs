namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using VRage.ObjectBuilders;
    using VRage.Utils;

    [MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ProgressBarCompositeTexture : MyObjectBuilder_CompositeTexture
    {
        public MyStringHash ProgressCenter;
        public MyStringHash ProgressLeft;
        public MyStringHash ProgressOverlay;
        public MyStringHash ProgressRight;

        public override bool IsValid()
        {
            if ((!base.IsValid() && !(this.ProgressCenter != MyStringHash.NullOrEmpty)) && (!(this.ProgressLeft != MyStringHash.NullOrEmpty) && !(this.ProgressRight != MyStringHash.NullOrEmpty)))
            {
                return (this.ProgressOverlay != MyStringHash.NullOrEmpty);
            }
            return true;
        }
    }
}

