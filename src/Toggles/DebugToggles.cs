using Godot;

namespace SteelTowers.Toggles;

public static class DebugToggles
{
    public static readonly bool DebugEnabled = OS.IsDebugBuild();

    public static bool LogNodeInitialization => DebugEnabled && true;
    public static bool LogDamage => DebugEnabled && true;
    public static bool LogEntityDeaths => DebugEnabled && true;
    public static bool LogReachedEndOfPath => DebugEnabled && true;
    public static bool LogFindNodeByType => DebugEnabled && true;
}