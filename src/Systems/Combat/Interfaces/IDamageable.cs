using Godot;

namespace SteelTowers.Systems.Combat.Interfaces;

public interface IDamageable
{
    [Signal]
    public delegate void OnDamageAppliedEventHandler();
    
    [Signal]
    public delegate void OnDeathEventHandler();
    
    public void ApplyDamage(double amount);
}