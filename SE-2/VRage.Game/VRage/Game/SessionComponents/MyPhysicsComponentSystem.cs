namespace VRage.Game.SessionComponents
{
    using System;
    using System.Collections.Generic;
    using VRage.Game.Components;

    [MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
    internal class MyPhysicsComponentSystem : MySessionComponentBase
    {
        private List<MyPhysicsComponentBase> m_physicsComponents = new List<MyPhysicsComponentBase>();
        public static MyPhysicsComponentSystem Static;

        public override void LoadData()
        {
            base.LoadData();
            Static = this;
        }

        public void Register(MyPhysicsComponentBase component)
        {
            this.m_physicsComponents.Add(component);
        }

        protected override void UnloadData()
        {
            base.UnloadData();
            Static = null;
        }

        public void Unregister(MyPhysicsComponentBase component)
        {
            this.m_physicsComponents.Remove(component);
        }

        public override void UpdateAfterSimulation()
        {
            base.UpdateAfterSimulation();
            foreach (MyPhysicsComponentBase base2 in this.m_physicsComponents)
            {
                if ((base2.Definition != null) && (base2.Definition.UpdateFlags != 0))
                {
                    base2.UpdateFromSystem();
                }
            }
        }
    }
}

