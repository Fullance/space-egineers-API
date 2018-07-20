namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [ProtoContract]
    public class CutsceneSequenceNode
    {
        [ProtoMember(0x4e), XmlAttribute]
        public string AttachPositionTo;
        [XmlAttribute, ProtoMember(0x52)]
        public string AttachRotationTo;
        [ProtoMember(0x4a), XmlAttribute]
        public string AttachTo;
        [XmlAttribute, ProtoMember(0x5e)]
        public float ChangeFOVTo;
        [XmlAttribute, ProtoMember(0x3e)]
        public string Event;
        [ProtoMember(0x42), XmlAttribute]
        public float EventDelay;
        [XmlAttribute, ProtoMember(70)]
        public string LockRotationTo;
        [XmlAttribute, ProtoMember(0x3a)]
        public string LookAt;
        [ProtoMember(0x56), XmlAttribute]
        public string MoveTo;
        [ProtoMember(0x6a), XmlAttribute]
        public string RotateLike;
        [XmlAttribute, ProtoMember(0x62)]
        public string RotateTowards;
        [ProtoMember(90), XmlAttribute]
        public string SetPositionTo;
        [XmlAttribute, ProtoMember(0x66)]
        public string SetRorationLike;
        [ProtoMember(0x36), XmlAttribute]
        public float Time;
        [XmlArrayItem("Waypoint"), ProtoMember(110)]
        public List<CutsceneSequenceNodeWaypoint> Waypoints;

        public string GetNodeDescription()
        {
            StringBuilder builder = new StringBuilder(this.Time.ToString() + "s");
            if (!string.IsNullOrEmpty(this.Event))
            {
                builder.Append(", \"" + this.Event + "\" event" + ((this.EventDelay > 0f) ? (" (" + this.EventDelay.ToString() + "s delay)") : ""));
            }
            if (this.ChangeFOVTo > 0f)
            {
                builder.Append(", change FOV to " + this.ChangeFOVTo.ToString() + " over time");
            }
            if (!string.IsNullOrEmpty(this.SetPositionTo))
            {
                builder.Append(", set position to \"" + this.SetPositionTo + "\"");
            }
            if (!string.IsNullOrEmpty(this.MoveTo))
            {
                builder.Append(", move over time to \"" + this.MoveTo + "\"");
            }
            if (!string.IsNullOrEmpty(this.LookAt))
            {
                builder.Append(", look at \"" + this.LookAt + "\" instantly");
            }
            if (!string.IsNullOrEmpty(this.RotateTowards))
            {
                builder.Append(", look at \"" + this.RotateTowards + "\" over time");
            }
            if (!string.IsNullOrEmpty(this.SetRorationLike))
            {
                builder.Append(", set rotation like \"" + this.SetRorationLike + "\" instantly");
            }
            if (!string.IsNullOrEmpty(this.RotateLike))
            {
                builder.Append(", change rotation like \"" + this.RotateLike + "\" over time");
            }
            if (this.LockRotationTo != null)
            {
                if (string.IsNullOrEmpty(this.LockRotationTo))
                {
                    builder.Append(", stop looking at target");
                }
                else
                {
                    builder.Append(", look at \"" + this.LockRotationTo + "\" until disabled");
                }
            }
            if (this.AttachTo != null)
            {
                if (string.IsNullOrEmpty(this.AttachTo))
                {
                    builder.Append(", stop attachment");
                }
                else
                {
                    builder.Append(", attach to \"" + this.AttachTo + "\"");
                }
            }
            else
            {
                if (this.AttachPositionTo != null)
                {
                    if (string.IsNullOrEmpty(this.AttachPositionTo))
                    {
                        builder.Append(", stop position attachment");
                    }
                    else
                    {
                        builder.Append(", attach position to \"" + this.AttachPositionTo + "\"");
                    }
                }
                if (this.AttachRotationTo != null)
                {
                    if (string.IsNullOrEmpty(this.AttachRotationTo))
                    {
                        builder.Append(", stop rotation attachment");
                    }
                    else
                    {
                        builder.Append(", attach rotation to \"" + this.AttachRotationTo + "\"");
                    }
                }
            }
            if ((this.Waypoints != null) && (this.Waypoints.Count > 1))
            {
                builder.Append(", movement spline over " + this.Waypoints.Count.ToString() + " points");
            }
            return builder.ToString();
        }

        public string GetNodeSummary()
        {
            string str = string.IsNullOrEmpty(this.Event) ? "" : (" - \"" + this.Event + "\" event" + ((this.EventDelay > 0f) ? (" (" + this.EventDelay.ToString() + "s delay)") : ""));
            return (this.Time.ToString() + "s" + str);
        }
    }
}

