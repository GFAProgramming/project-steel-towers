using Godot;
using SteelTowers.Systems.Combat.Components;
using SteelTowers.Systems.Combat.Interfaces;
using SteelTowers.Systems.Movement.Components;
using SteelTowers.Systems.Movement.Interfaces;
using SteelTowers.Toggles;
using SteelTowers.Utilities;

namespace SteelTowers.Entity.Enemy;

public partial class Enemy: PathFollow2D, IAttack, IHealth, IMovement {
	public AnimatedSprite2D AnimatedSprite2D { get; private set; } = null!;
	
	public Area2D Area2D { get; private set; } = null!;

	public HealthComponent Health { get; private set; } = null!;

	public AttackComponent Attack { get; private set; } = null!;

	public MovementComponent Movement { get; private set; } = null!;
	
	private Castle.Castle? _castle;

	public override void _Ready()
	{
		AnimatedSprite2D = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
		Area2D = GetNode<Area2D>("%Area2D");
		Health = GetNode<HealthComponent>("%HealthComponent");
		Attack = GetNode<AttackComponent>("%AttackComponent");
		Movement = GetNode<MovementComponent>("%MovementComponent");

		_castle = NodeUtilities.FindNodeByType<Castle.Castle>(GetTree().Root) as Castle.Castle;
		Loop = false;
	}

	public override void _Process(double delta)
	{
		Movement.Move(delta);
		
		if (Path2DUtilities.IsAtEndOfPath2D(ProgressRatio))
		{
			if (DebugToggles.LogReachedEndOfPath)
			{
				GD.Print($"Node {Name} reached the end of the path!");
			}

			DamageCastle();
			Health.Damage(Health.MaxHealth);
		}
	}

	private void DamageCastle()
	{
		if (DebugToggles.DebugEnabled)
		{
			GD.Print($"Damaging the castle {_castle}!");
		}

		Attack.Attack(_castle);
	}
}
