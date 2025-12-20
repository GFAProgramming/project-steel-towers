namespace SteelTowers.Utilities;

public static class Path2DUtilities
{
    private static float PROGRESS_RATIO_MAX = 1.0f;
    private static float PROGRESS_RATIO_EQUALITY_TOLERANCE = 0.001f;
    
    public static bool IsAtEndOfPath2D(float progressRatio)
    {
        return FloatUtilities.AreNearlyEqual(progressRatio, PROGRESS_RATIO_MAX, PROGRESS_RATIO_EQUALITY_TOLERANCE);
    }
}