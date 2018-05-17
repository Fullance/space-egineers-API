namespace VRageMath
{
    using System;

    public class MyCuboidSide
    {
        public Line[] Lines = new Line[4];
        public VRageMath.Plane Plane = new VRageMath.Plane();

        public MyCuboidSide()
        {
            this.Lines[0] = new Line();
            this.Lines[1] = new Line();
            this.Lines[2] = new Line();
            this.Lines[3] = new Line();
        }

        public void CreatePlaneFromLines()
        {
            this.Plane = new VRageMath.Plane(this.Lines[0].From, Vector3.Cross(this.Lines[1].Direction, this.Lines[0].Direction));
        }
    }
}

