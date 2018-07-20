namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ScriptStateMachineManager : MyObjectBuilder_Base
    {
        public List<CursorStruct> ActiveStateMachines;

        [StructLayout(LayoutKind.Sequential)]
        public struct CursorStruct
        {
            public string StateMachineName;
            public MyObjectBuilder_ScriptSMCursor[] Cursors;
        }
    }
}

