using Godot;
using SteelTowers.Attribute_Component;
using SteelTowers.Systems.Combat.Interfaces;
using SteelTowers.Utilities;

namespace SteelTowers.Enemy;

public partial class Enemy: PathFollow2D, IDamageable {
    [Signal] 
    public delegate void OnDeathEventHandler();

    [Signal]
    public delegate void OnDamageAppliedEventHandler();
    
    public AnimatedSprite2D AnimatedSprite2D { get; private set; }
    public Area2D Area2D { get; private set; }
    public AttributeComponent HealthComponent { get; private set; }

    public override void _Ready()
    {
        AnimatedSprite2D = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
        Area2D = GetNode<Area2D>("%Area2D");
        HealthComponent = GetNode<AttributeComponent>("%HealthComponent");
    }

    public override void _Process(double delta)
    {
        GD.Print($"Progress ratio = {ProgressRatio}");
        if (Path2DUtilities.IsAtEndOfPath2D(ProgressRatio))
        {
            GD.Print($"Node {Name} reached the end of the path!");
            DamageCastle();
            Die();
        }
    }

    private void DamageCastle()
    {
        GD.Print("Damaging the castle!");
        // If Castle has health
        // {
        //      Apply N damage to the castle
        // }
    }

    public void ApplyDamage(double amount)
    {
        HealthComponent.Value -= amount;
        EmitSignalOnDamageApplied();
        
        if (HealthComponent.Value <= HealthComponent.Min)
        {
            Die();
        }
    }

    private void Die()
    {
        GD.Print($"Enemy {Name} has died");
        
        EmitSignalOnDeath();
        CallDeferred("QueueFree");
    }
}