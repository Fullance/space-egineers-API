namespace VRage.Game
{
    using System;
    using System.Runtime.CompilerServices;

    public static class MyCharacterMovement
    {
        public const ushort Backward = 0x20;
        public const ushort Crouching = 2;
        public const ushort Died = 6;
        public const ushort Down = 0x200;
        public const ushort Falling = 4;
        public const ushort Fast = 0x400;
        public const ushort Flying = 3;
        public const ushort Forward = 0x10;
        public const ushort Jump = 5;
        public const ushort Ladder = 7;
        public const ushort Left = 0x40;
        public const ushort MovementDirectionMask = 0x3f0;
        public const ushort MovementSpeedMask = 0xc00;
        public const ushort MovementTypeMask = 15;
        public const ushort NoDirection = 0;
        public const ushort NormalSpeed = 0;
        public const ushort NotRotating = 0;
        public const ushort Right = 0x80;
        public const ushort RotatingLeft = 0x1000;
        public const ushort RotatingRight = 0x2000;
        public const ushort RotationMask = 0x3000;
        public const ushort Sitting = 1;
        public const ushort Standing = 0;
        public const ushort Up = 0x100;
        public const ushort VeryFast = 0x800;

        public static ushort GetDirection(this MyCharacterMovementEnum value) => 
            ((ushort) (value & ((MyCharacterMovementEnum) 0x3f0)));

        public static ushort GetMode(this MyCharacterMovementEnum value) => 
            ((ushort) (value & ((MyCharacterMovementEnum) 15)));

        public static ushort GetSpeed(this MyCharacterMovementEnum value) => 
            ((ushort) (value & ((MyCharacterMovementEnum) 0xc00)));
    }
}

