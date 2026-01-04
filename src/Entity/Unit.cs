using Godot;
using SteelTowers.Systems.Combat.Components;
using SteelTowers.Systems.Combat.Interfaces;
using SteelTowers.Systems.Movement.Components;
using SteelTowers.Systems.Movement.Interfaces;

namespace SteelTowers.Entity;

public partial class Unit: PathFollow2D, IAttack, IHealth, IMovement {
	public AnimatedSprite2D AnimatedSprite2D { get; private set; } = null!;
	public Area2D Area2D { get; private set; } = null!;
	public HealthComponent Health { get; private set; } = null!;
	public AttackComponent Attack { get; private set; } = null!;
	public MovementComponent Movement { get; private set; } = null!;

	public override void _Ready()
	{
		AnimatedSprite2D = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
		Area2D = GetNode<Area2D>("%Area2D");
		Health = GetNode<HealthComponent>("%HealthComponent");
		Attack = GetNode<AttackComponent>("%AttackComponent");
		Movement = GetNode<MovementComponent>("%MovementComponent");

		Loop = false;
	}
}
