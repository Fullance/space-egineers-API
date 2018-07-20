namespace VRage.Game
{
    using System;

    public enum MyCharacterMovementEnum : ushort
    {
        Backrunning = 0x420,
        BackWalking = 0x20,
        CrouchBackWalking = 0x22,
        Crouching = 2,
        CrouchRotatingLeft = 0x1002,
        CrouchRotatingRight = 0x2002,
        CrouchStrafingLeft = 0x42,
        CrouchStrafingRight = 130,
        CrouchWalking = 0x12,
        CrouchWalkingLeftBack = 0x62,
        CrouchWalkingLeftFront = 0x52,
        CrouchWalkingRightBack = 0xa2,
        CrouchWalkingRightFront = 0x92,
        Died = 6,
        Falling = 4,
        Flying = 3,
        Jump = 5,
        Ladder = 7,
        LadderDown = 0x207,
        LadderUp = 0x107,
        RotatingLeft = 0x1000,
        RotatingRight = 0x2000,
        Running = 0x410,
        RunningLeftBack = 0x460,
        RunningLeftFront = 0x450,
        RunningRightBack = 0x4a0,
        RunningRightFront = 0x490,
        RunStrafingLeft = 0x440,
        RunStrafingRight = 0x480,
        Sitting = 1,
        Sprinting = 0x810,
        Standing = 0,
        Walking = 0x10,
        WalkingLeftBack = 0x60,
        WalkingLeftFront = 80,
        WalkingRightBack = 160,
        WalkingRightFront = 0x90,
        WalkStrafingLeft = 0x40,
        WalkStrafingRight = 0x80
    }
}

