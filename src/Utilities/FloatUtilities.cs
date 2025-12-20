using System;

namespace SteelTowers.Utilities;

public static class FloatUtilities
{
    public static bool AreNearlyEqual(float a, float b, float tolerance)
    {
        return Math.Abs(a - b) <= tolerance;
    }
}