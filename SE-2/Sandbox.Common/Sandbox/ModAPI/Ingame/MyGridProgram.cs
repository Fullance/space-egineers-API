namespace Sandbox.ModAPI.Ingame
{
    using Sandbox.ModAPI;
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public abstract class MyGridProgram : IMyGridProgram
    {
        private readonly Action<string, UpdateType> m_main;
        private readonly Action m_save;
        private string m_storage;

        protected MyGridProgram()
        {
            Type type = base.GetType();
            MethodInfo method = type.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(string), typeof(UpdateType) }, null);
            if (method != null)
            {
                this.m_main = method.CreateDelegate<Action<string, UpdateType>>(this);
            }
            else
            {
                method = type.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
                if (method != null)
                {
                    Action<string> main = method.CreateDelegate<Action<string>>(this);
                    this.m_main = (arg, source) => main(arg);
                }
                else
                {
                    method = type.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);
                    if (method != null)
                    {
                        Action mainWithoutArgument = method.CreateDelegate<Action>(this);
                        this.m_main = (arg, source) => mainWithoutArgument();
                    }
                }
            }
            MethodInfo info2 = type.GetMethod("Save", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (info2 != null)
            {
                this.m_save = info2.CreateDelegate<Action>(this);
            }
        }

        [Obsolete]
        void IMyGridProgram.Main(string argument)
        {
            if (this.m_main == null)
            {
                throw new InvalidOperationException("No Main method available");
            }
            this.m_main(argument ?? string.Empty, UpdateType.Mod);
        }

        void IMyGridProgram.Main(string argument, UpdateType updateSource)
        {
            if (this.m_main == null)
            {
                throw new InvalidOperationException("No Main method available");
            }
            this.m_main(argument ?? string.Empty, updateSource);
        }

        void IMyGridProgram.Save()
        {
            if (this.m_save != null)
            {
                this.m_save();
            }
        }

        public Action<string> Echo { get; protected set; }

        [Obsolete("Use Runtime.TimeSinceLastRun instead")]
        public virtual TimeSpan ElapsedTime { get; protected set; }

        public virtual Sandbox.ModAPI.Ingame.IMyGridTerminalSystem GridTerminalSystem { get; protected set; }

        public virtual Sandbox.ModAPI.Ingame.IMyProgrammableBlock Me { get; protected set; }

        public virtual IMyGridProgramRuntimeInfo Runtime { get; protected set; }

        Action<string> IMyGridProgram.Echo
        {
            get => 
                this.Echo;
            set
            {
                this.Echo = value;
            }
        }

        TimeSpan IMyGridProgram.ElapsedTime
        {
            get => 
                this.ElapsedTime;
            set
            {
                this.ElapsedTime = value;
            }
        }

        Sandbox.ModAPI.Ingame.IMyGridTerminalSystem IMyGridProgram.GridTerminalSystem
        {
            get => 
                this.GridTerminalSystem;
            set
            {
                this.GridTerminalSystem = value;
            }
        }

        bool IMyGridProgram.HasMainMethod =>
            (this.m_main != null);

        bool IMyGridProgram.HasSaveMethod =>
            (this.m_save != null);

        Sandbox.ModAPI.Ingame.IMyProgrammableBlock IMyGridProgram.Me
        {
            get => 
                this.Me;
            set
            {
                this.Me = value;
            }
        }

        IMyGridProgramRuntimeInfo IMyGridProgram.Runtime
        {
            get => 
                this.Runtime;
            set
            {
                this.Runtime = value;
            }
        }

        string IMyGridProgram.Storage
        {
            get => 
                this.Storage;
            set
            {
                this.Storage = value;
            }
        }

        public virtual string Storage
        {
            get => 
                (this.m_storage ?? "");
            protected set
            {
                this.m_storage = value ?? "";
            }
        }
    }
}

