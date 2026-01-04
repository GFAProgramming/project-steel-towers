using Godot;
using SteelTowers.Systems.Combat.Components;
using SteelTowers.Systems.Combat.Interfaces;

namespace SteelTowers.Tower;

public partial class Tower: Node2D, IHealth, IAttack
{
    public AnimatedSprite2D AnimatedSprite2D { get; private set; } = null!;
    public Area2D Area2D { get; private set; } = null!;
    public HealthComponent Health { get; private set; } = null!;
    public AttackComponent Attack { get; private set; } = null!;
    
    public override void _Ready()
    {
        AnimatedSprite2D = GetNode<AnimatedSprite2D>(nameof(AnimatedSprite2D));
        Area2D = GetNode<Area2D>(nameof(Area2D));
        Health = GetNode<HealthComponent>(nameof(HealthComponent));
        Attack = GetNode<AttackComponent>(nameof(AttackComponent));
    }
}