namespace VRage.Game
{
    using System;
    using VRage;
    using VRage.Game.Definitions;
    using VRage.ObjectBuilders;
    using VRage.Utils;

    [MyDefinitionType(typeof(MyObjectBuilder_DefinitionBase), (Type) null)]
    public class MyDefinitionBase
    {
        public bool AvailableInSurvival;
        public MyModContext Context;
        public MyStringId? DescriptionEnum;
        public string DescriptionString;
        public MyStringId? DisplayNameEnum;
        public string DisplayNameString;
        public bool Enabled = true;
        public string[] Icons;
        public MyDefinitionId Id;
        public bool Public = true;

        public virtual MyObjectBuilder_DefinitionBase GetObjectBuilder()
        {
            MyObjectBuilder_DefinitionBase base2 = MyDefinitionManagerBase.GetObjectFactory().CreateObjectBuilder<MyObjectBuilder_DefinitionBase>(this);
            base2.Id = (SerializableDefinitionId) this.Id;
            base2.Description = this.DescriptionEnum.HasValue ? this.DescriptionEnum.Value.ToString() : this.DescriptionString?.ToString();
            base2.DisplayName = this.DisplayNameEnum.HasValue ? this.DisplayNameEnum.Value.ToString() : this.DisplayNameString?.ToString();
            base2.Icons = this.Icons;
            base2.Public = this.Public;
            base2.Enabled = this.Enabled;
            base2.AvailableInSurvival = this.AvailableInSurvival;
            return base2;
        }

        protected virtual void Init(MyObjectBuilder_DefinitionBase builder)
        {
            this.Id = builder.Id;
            this.Public = builder.Public;
            this.Enabled = builder.Enabled;
            this.AvailableInSurvival = builder.AvailableInSurvival;
            this.Icons = builder.Icons;
            if ((builder.DisplayName != null) && builder.DisplayName.StartsWith("DisplayName_"))
            {
                this.DisplayNameEnum = new MyStringId?(MyStringId.GetOrCompute(builder.DisplayName));
            }
            else
            {
                this.DisplayNameString = builder.DisplayName;
            }
            if ((builder.Description != null) && builder.Description.StartsWith("Description_"))
            {
                this.DescriptionEnum = new MyStringId?(MyStringId.GetOrCompute(builder.Description));
            }
            else
            {
                this.DescriptionString = builder.Description;
            }
        }

        public void Init(MyObjectBuilder_DefinitionBase builder, MyModContext modContext)
        {
            this.Context = modContext;
            this.Init(builder);
        }

        [Obsolete("Prefer to use MyDefinitionPostprocessor instead.")]
        public virtual void Postprocess()
        {
        }

        public void Save(string filepath)
        {
            this.GetObjectBuilder().Save(filepath);
        }

        public override string ToString() => 
            this.Id.ToString();

        public virtual string DescriptionText
        {
            get
            {
                if (!this.DescriptionEnum.HasValue)
                {
                    return this.DescriptionString;
                }
                return MyTexts.GetString(this.DescriptionEnum.Value);
            }
        }

        public virtual string DisplayNameText
        {
            get
            {
                if (!this.DisplayNameEnum.HasValue)
                {
                    return this.DisplayNameString;
                }
                return MyTexts.GetString(this.DisplayNameEnum.Value);
            }
        }
    }
}

