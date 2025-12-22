using Godot;
using SteelTowers.Systems.Combat.Components;

namespace SteelTowers.Systems.Combat.Interfaces;

public interface IHealth
{
    HealthComponent Health { get; }
}