namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Utils;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ToolbarControlVisualStyle : MyObjectBuilder_Base
    {
        public Vector2 CenterPosition;
        public ColorStyle ColorPanelStyle;
        public ToolbarItemStyle ItemStyle;
        public MyGuiDrawAlignEnum OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_BOTTOM;
        public ToolbarPageStyle PageStyle;
        public Vector2 SelectedItemPosition;
        public float? SelectedItemTextScale;
        [XmlArrayItem("StatControl")]
        public MyObjectBuilder_StatControls[] StatControls;
        [XmlElement(typeof(MyAbstractXmlSerializer<ConditionBase>))]
        public ConditionBase VisibleCondition;

        public class ColorStyle
        {
            public Vector2 Offset;
            public Vector2 Size;
            public MyStringHash Texture;
            public Vector2 VoxelHandPosition;
        }

        public class ToolbarItemStyle
        {
            public string FontHighlight = "White";
            public string FontNormal = "Blue";
            public Vector2 ItemTextureScale = Vector2.Zero;
            public MyGuiOffset? Margin;
            public float TextScale = 0.75f;
            public MyStringHash Texture = MyStringHash.GetOrCompute(@"Textures\GUI\Controls\grid_item.dds");
            public MyStringHash TextureHighlight = MyStringHash.GetOrCompute(@"Textures\GUI\Controls\grid_item_highlight.dds");
            public Vector2? VariantOffset;
            public MyStringHash VariantTexture = MyStringHash.GetOrCompute(@"Textures\GUI\Icons\VariantsAvailable.dds");
        }

        public class ToolbarPageStyle
        {
            public float? NumberSize;
            public MyStringHash PageCompositeTexture;
            public MyStringHash PageHighlightCompositeTexture;
            public Vector2 PagesOffset;
        }
    }
}

