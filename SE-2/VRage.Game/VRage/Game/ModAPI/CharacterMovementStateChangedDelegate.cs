namespace VRage.Game.ModAPI
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.Game;

    public delegate void CharacterMovementStateChangedDelegate(IMyCharacter character, MyCharacterMovementEnum oldState, MyCharacterMovementEnum newState);
}

