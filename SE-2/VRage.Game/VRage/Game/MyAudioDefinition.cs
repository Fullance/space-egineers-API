namespace VRage.Game
{
    using System;
    using VRage.Data.Audio;
    using VRage.Game.Definitions;

    [MyDefinitionType(typeof(MyObjectBuilder_AudioDefinition), (Type) null)]
    public class MyAudioDefinition : MyDefinitionBase
    {
        public MySoundData SoundData;

        public override MyObjectBuilder_DefinitionBase GetObjectBuilder()
        {
            MyObjectBuilder_AudioDefinition objectBuilder = (MyObjectBuilder_AudioDefinition) base.GetObjectBuilder();
            objectBuilder.SoundData = this.SoundData;
            return objectBuilder;
        }

        protected override void Init(MyObjectBuilder_DefinitionBase builder)
        {
            base.Init(builder);
            MyObjectBuilder_AudioDefinition definition = builder as MyObjectBuilder_AudioDefinition;
            this.SoundData = definition.SoundData;
            this.SoundData.SubtypeId = base.Id.SubtypeId;
            if (this.SoundData.Loopable)
            {
                bool flag = true;
                for (int i = 0; i < this.SoundData.Waves.Count; i++)
                {
                    flag &= this.SoundData.Waves[i].Loop != null;
                }
            }
        }
    }
}

