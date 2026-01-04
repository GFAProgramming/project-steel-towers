using GdUnit4;
using SteelTowers;

namespace SteelTowers.Test.Integration;

using static Assertions;

[TestSuite]
public class UnitIT
{
    [TestCase]
    [RequireGodotRuntime]
    void _Ready_shouldInitialtizeNodes()
    {
        Entity.Unit unit = new();

        AssertObject(unit.AnimatedSprite2D).IsNotNull();
        AssertObject(unit.Area2D).IsNotNull();
        AssertObject(unit.Health).IsNotNull();
        AssertObject(unit.Attack).IsNotNull();
        AssertObject(unit.Movement).IsNotNull();
    }
}