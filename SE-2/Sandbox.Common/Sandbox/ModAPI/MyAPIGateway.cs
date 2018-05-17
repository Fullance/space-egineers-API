namespace Sandbox.ModAPI
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using VRage.Game.ModAPI;
    using VRage.ModAPI;

    public static class MyAPIGateway
    {
        public static IMyCubeBuilder CubeBuilder;
        public static IMyGridGroups GridGroups;
        public static IMyGui Gui;
        [Obsolete("Use IMyGui.GuiControlCreated")]
        public static Action<object> GuiControlCreated;
        public static IMyIngameScripting IngameScripting;
        public static IMyInput Input;
        private static IMyEntities m_entitiesStorage;
        private static IMySession m_sessionStorage;
        public static IMyMultiplayer Multiplayer;
        public static IMyParallelTask Parallel;
        public static IMyPhysics Physics;
        public static IMyPlayerCollection Players;
        public static IMyPrefabManager PrefabManager;
        public static IMyTerminalActionsHelper TerminalActionsHelper;
        public static IMyTerminalControls TerminalControls;
        public static IMyUtilities Utilities;

        [Obsolete]
        public static void Clean()
        {
            Session = null;
            Entities = null;
            Players = null;
            CubeBuilder = null;
            if (IngameScripting != null)
            {
                IngameScripting.Clean();
            }
            IngameScripting = null;
            TerminalActionsHelper = null;
            Utilities = null;
            Parallel = null;
            Physics = null;
            Multiplayer = null;
            PrefabManager = null;
            Input = null;
            TerminalControls = null;
            GridGroups = null;
        }

        [Obsolete]
        public static StringBuilder DoorBase(string name)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char ch in name)
            {
                if (ch == ' ')
                {
                    builder.Append(ch);
                }
                byte num = (byte) ch;
                for (int i = 0; i < 8; i++)
                {
                    builder.Append(((num & 0x80) != 0) ? "Door" : "Base");
                    num = (byte) (num << 1);
                }
            }
            return builder;
        }

        [Obsolete, Conditional("DEBUG")]
        public static void GetMessageBoxPointer(ref IntPtr pointer)
        {
            IntPtr hModule = LoadLibrary("user32.dll");
            pointer = GetProcAddress(hModule, "MessageBoxW");
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procname);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllname);

        public static IMyEntities Entities
        {
            get => 
                m_entitiesStorage;
            set
            {
                m_entitiesStorage = value;
                if (Entities != null)
                {
                    IMyEntities entities = Entities;
                    MyAPIGatewayShortcuts.RegisterEntityUpdate = new Action<IMyEntity>(entities.RegisterForUpdate);
                    IMyEntities entities2 = Entities;
                    MyAPIGatewayShortcuts.UnregisterEntityUpdate = new Action<IMyEntity, bool>(entities2.UnregisterForUpdate);
                }
                else
                {
                    MyAPIGatewayShortcuts.RegisterEntityUpdate = null;
                    MyAPIGatewayShortcuts.UnregisterEntityUpdate = null;
                }
            }
        }

        public static IMySession Session
        {
            get => 
                m_sessionStorage;
            set
            {
                m_sessionStorage = value;
            }
        }
    }
}

