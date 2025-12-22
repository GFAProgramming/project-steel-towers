using System;
using Godot;
using SteelTowers.Toggles;

namespace SteelTowers.Systems.Combat.Components;

public partial class HealthComponent: Node
{
    [Export]
    public int MaxHealth { get; private set; }
    
    [Export]
    public int MinHealth { get; private set; }
    
    [Export]
    public int CurrentHealth { get; private set; }
    
    public bool IsAlive => CurrentHealth > 0;

    public void Damage(int amount)
    {
        if (!IsAlive)
        {
            return;
        }
        
        CurrentHealth -= Math.Min(CurrentHealth, amount);
        if (DebugToggles.LogDamage)
        {
            GD.Print($"{Owner}.Health =  {CurrentHealth}");
        }

        if (CurrentHealth <= MinHealth)
        {
            Die();
        }
    }

    private void Die()
    {
        if (DebugToggles.LogEntityDeaths)
        {
            GD.Print($"Entity {Owner} has died");
        }

        Owner.QueueFree();
    }
}