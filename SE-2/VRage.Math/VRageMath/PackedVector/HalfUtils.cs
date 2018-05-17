namespace VRageMath.PackedVector
{
    using System;

    public static class HalfUtils
    {
        private const uint BiasDiffo = 0xc8000000;
        private const int cExpBias = 15;
        private const int cExpBits = 5;
        private const int cFracBits = 10;
        private const int cFracBitsDiff = 13;
        private const uint cFracMask = 0x3ff;
        private const uint cRoundBit = 0x1000;
        private const int cSignBit = 15;
        private const uint cSignMask = 0x8000;
        private const uint eMax = 0x10;
        private const int eMin = -14;
        private const uint wMaxNormal = 0x47ffefff;
        private const uint wMinNormal = 0x38800000;

        public static unsafe ushort Pack(float value)
        {
            uint num = *((uint*) &value);
            uint num2 = (uint) ((num & -2147483648) >> 0x10);
            uint num3 = num & 0x7fffffff;
            if (num3 > 0x47ffefff)
            {
                return (ushort) (num2 | 0x7fff);
            }
            if (num3 < 0x38800000)
            {
                uint num5 = (num3 & 0x7fffff) | 0x800000;
                int num6 = 0x71 - ((int) (num3 >> 0x17));
                uint num7 = (num6 > 0x1f) ? 0 : (num5 >> num6);
                return (ushort) (num2 | (((num7 + 0xfff) + ((num7 >> 13) & 1)) >> 13));
            }
            return (ushort) (num2 | ((((num3 - 0x38000000) + 0xfff) + ((num3 >> 13) & 1)) >> 13));
        }

        public static unsafe float Unpack(ushort value)
        {
            uint num;
            if ((value & -33792) == 0)
            {
                if ((value & 0x3ff) != 0)
                {
                    uint num2 = 0xfffffff2;
                    uint num3 = (uint) (value & 0x3ff);
                    while ((num3 & 0x400) == 0)
                    {
                        num2--;
                        num3 = num3 << 1;
                    }
                    uint num4 = num3 & 0xfffffbff;
                    num = ((uint) (((value & 0x8000) << 0x10) | ((num2 + 0x7f) << 0x17))) | (num4 << 13);
                }
                else
                {
                    num = (uint) ((value & 0x8000) << 0x10);
                }
            }
            else
            {
                num = (uint) ((((value & 0x8000) << 0x10) | (((((value >> 10) & 0x1f) - 15) + 0x7f) << 0x17)) | ((value & 0x3ff) << 13));
            }
            return *(((float*) &num));
        }
    }
}

