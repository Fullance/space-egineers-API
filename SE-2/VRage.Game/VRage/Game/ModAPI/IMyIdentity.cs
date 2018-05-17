namespace VRage.Game.ModAPI
{
    using System;

    public interface IMyIdentity
    {
        event Action<IMyCharacter, IMyCharacter> CharacterChanged;

        Vector3? ColorMask { get; }

        string DisplayName { get; }

        long IdentityId { get; }

        bool IsDead { get; }

        string Model { get; }

        [Obsolete("Use IdentityId instead.")]
        long PlayerId { get; }
    }
}

