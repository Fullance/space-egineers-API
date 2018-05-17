namespace VRageMath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class MyCuboid
    {
        public MyCuboidSide[] Sides = new MyCuboidSide[6];

        public MyCuboid()
        {
            this.Sides[0] = new MyCuboidSide();
            this.Sides[1] = new MyCuboidSide();
            this.Sides[2] = new MyCuboidSide();
            this.Sides[3] = new MyCuboidSide();
            this.Sides[4] = new MyCuboidSide();
            this.Sides[5] = new MyCuboidSide();
        }

        public void CreateFromSizes(float width1, float depth1, float width2, float depth2, float length)
        {
            float y = length * 0.5f;
            float x = width1 * 0.5f;
            float num3 = width2 * 0.5f;
            float z = depth1 * 0.5f;
            float num5 = depth2 * 0.5f;
            Vector3[] vertices = new Vector3[] { new Vector3(-num3, -y, -num5), new Vector3(num3, -y, -num5), new Vector3(-num3, -y, num5), new Vector3(num3, -y, num5), new Vector3(-x, y, -z), new Vector3(x, y, -z), new Vector3(-x, y, z), new Vector3(x, y, z) };
            this.CreateFromVertices(vertices);
        }

        public void CreateFromVertices(Vector3[] vertices)
        {
            Vector3 vector = new Vector3(float.MaxValue);
            Vector3 vector2 = new Vector3(float.MinValue);
            foreach (Vector3 vector3 in vertices)
            {
                vector = Vector3.Min(vector3, vector);
                vector2 = Vector3.Min(vector3, vector2);
            }
            Line line = new Line(vertices[0], vertices[2], false);
            Line line2 = new Line(vertices[2], vertices[3], false);
            Line line3 = new Line(vertices[3], vertices[1], false);
            Line line4 = new Line(vertices[1], vertices[0], false);
            Line line5 = new Line(vertices[7], vertices[6], false);
            Line line6 = new Line(vertices[6], vertices[4], false);
            Line line7 = new Line(vertices[4], vertices[5], false);
            Line line8 = new Line(vertices[5], vertices[7], false);
            Line line9 = new Line(vertices[4], vertices[0], false);
            Line line10 = new Line(vertices[0], vertices[1], false);
            Line line11 = new Line(vertices[1], vertices[5], false);
            Line line12 = new Line(vertices[5], vertices[4], false);
            Line line13 = new Line(vertices[3], vertices[2], false);
            Line line14 = new Line(vertices[2], vertices[6], false);
            Line line15 = new Line(vertices[6], vertices[7], false);
            Line line16 = new Line(vertices[7], vertices[3], false);
            Line line17 = new Line(vertices[1], vertices[3], false);
            Line line18 = new Line(vertices[3], vertices[7], false);
            Line line19 = new Line(vertices[7], vertices[5], false);
            Line line20 = new Line(vertices[5], vertices[1], false);
            Line line21 = new Line(vertices[0], vertices[4], false);
            Line line22 = new Line(vertices[4], vertices[6], false);
            Line line23 = new Line(vertices[6], vertices[2], false);
            Line line24 = new Line(vertices[2], vertices[0], false);
            this.Sides[0].Lines[0] = line;
            this.Sides[0].Lines[1] = line2;
            this.Sides[0].Lines[2] = line3;
            this.Sides[0].Lines[3] = line4;
            this.Sides[0].CreatePlaneFromLines();
            this.Sides[1].Lines[0] = line5;
            this.Sides[1].Lines[1] = line6;
            this.Sides[1].Lines[2] = line7;
            this.Sides[1].Lines[3] = line8;
            this.Sides[1].CreatePlaneFromLines();
            this.Sides[2].Lines[0] = line9;
            this.Sides[2].Lines[1] = line10;
            this.Sides[2].Lines[2] = line11;
            this.Sides[2].Lines[3] = line12;
            this.Sides[2].CreatePlaneFromLines();
            this.Sides[3].Lines[0] = line13;
            this.Sides[3].Lines[1] = line14;
            this.Sides[3].Lines[2] = line15;
            this.Sides[3].Lines[3] = line16;
            this.Sides[3].CreatePlaneFromLines();
            this.Sides[4].Lines[0] = line17;
            this.Sides[4].Lines[1] = line18;
            this.Sides[4].Lines[2] = line19;
            this.Sides[4].Lines[3] = line20;
            this.Sides[4].CreatePlaneFromLines();
            this.Sides[5].Lines[0] = line21;
            this.Sides[5].Lines[1] = line22;
            this.Sides[5].Lines[2] = line23;
            this.Sides[5].Lines[3] = line24;
            this.Sides[5].CreatePlaneFromLines();
        }

        public MyCuboid CreateTransformed(ref Matrix worldMatrix)
        {
            Vector3[] vertices = new Vector3[8];
            int index = 0;
            foreach (Vector3 vector in this.Vertices)
            {
                vertices[index] = Vector3.Transform(vector, (Matrix) worldMatrix);
                index++;
            }
            MyCuboid cuboid = new MyCuboid();
            cuboid.CreateFromVertices(vertices);
            return cuboid;
        }

        public BoundingBox GetAABB()
        {
            BoundingBox box = BoundingBox.CreateInvalid();
            foreach (Line line in this.UniqueLines)
            {
                Vector3 from = line.From;
                Vector3 to = line.To;
                box = box.Include(ref from);
                box = box.Include(ref to);
            }
            return box;
        }

        public BoundingBox GetLocalAABB()
        {
            BoundingBox aABB = this.GetAABB();
            Vector3 center = aABB.Center;
            aABB.Min -= center;
            aABB.Max -= center;
            return aABB;
        }

        public IEnumerable<Line> UniqueLines
        {
            get
            {
                yield return this.Sides[0].Lines[0];
                yield return this.Sides[0].Lines[1];
                yield return this.Sides[0].Lines[2];
                yield return this.Sides[0].Lines[3];
                yield return this.Sides[1].Lines[0];
                yield return this.Sides[1].Lines[1];
                yield return this.Sides[1].Lines[2];
                yield return this.Sides[1].Lines[3];
                yield return this.Sides[2].Lines[0];
                yield return this.Sides[2].Lines[2];
                yield return this.Sides[4].Lines[1];
                yield return this.Sides[5].Lines[2];
            }
        }

        public IEnumerable<Vector3> Vertices
        {
            get
            {
                yield return this.Sides[2].Lines[1].From;
                yield return this.Sides[2].Lines[1].To;
                yield return this.Sides[0].Lines[1].From;
                yield return this.Sides[0].Lines[1].To;
                yield return this.Sides[1].Lines[2].From;
                yield return this.Sides[1].Lines[2].To;
                yield return this.Sides[3].Lines[2].From;
                yield return this.Sides[3].Lines[2].To;
            }
        }


    }
}

