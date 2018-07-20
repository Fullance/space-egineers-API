namespace VRage.Game.ObjectBuilders.Definitions.SessionComponents
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyPlacementSettings
    {
        public MyGridPlacementSettings SmallGrid;
        public MyGridPlacementSettings SmallStaticGrid;
        public MyGridPlacementSettings LargeGrid;
        public MyGridPlacementSettings LargeStaticGrid;
        public bool StaticGridAlignToCenter;
        public MyGridPlacementSettings GetGridPlacementSettings(MyCubeSize cubeSize, bool isStatic)
        {
            switch (cubeSize)
            {
                case MyCubeSize.Large:
                    if (isStatic)
                    {
                        return this.LargeStaticGrid;
                    }
                    return this.LargeGrid;

                case MyCubeSize.Small:
                    if (isStatic)
                    {
                        return this.SmallStaticGrid;
                    }
                    return this.SmallGrid;
            }
            return this.LargeGrid;
        }

        public MyGridPlacementSettings GetGridPlacementSettings(MyCubeSize cubeSize)
        {
            switch (cubeSize)
            {
                case MyCubeSize.Large:
                    return this.LargeGrid;

                case MyCubeSize.Small:
                    return this.SmallGrid;
            }
            return this.LargeGrid;
        }
    }
}

