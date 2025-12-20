using Godot;
using JetBrains.Annotations;
using SteelTowers.Attribute_Component;
using SteelTowers.Systems.Combat.Interfaces;
using SteelTowers.Toggles;
using SteelTowers.Utilities;

namespace SteelTowers.Entity.Enemy;

public partial class Enemy: PathFollow2D, IDamageable {
	[Signal] 
	public delegate void OnDeathEventHandler();

	[Signal]
	public delegate void OnDamageAppliedEventHandler();
	
	[NotNull]
	public AnimatedSprite2D AnimatedSprite2D { get; private set; }
	
	[NotNull]
	public Area2D Area2D { get; private set; }
	
	[NotNull]
	public AttributeComponent HealthComponent { get; private set; }

	[Export] public float AttackDamage { get; private set; }

	[Export]
	public float Speed { get; private set; }
	
	[CanBeNull] 
	private Castle.Castle _castle;

	public override void _Ready()
	{
		AnimatedSprite2D = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
		Area2D = GetNode<Area2D>("%Area2D");
		HealthComponent = GetNode<AttributeComponent>("%HealthComponent");

		_castle = NodeUtilities.FindNodeByType<Castle.Castle>(GetTree().Root) as Castle.Castle;
		Loop = false;
	}

	public override void _Process(double delta)
	{
		Progress += (float) (Speed * delta);
		
		if (Path2DUtilities.IsAtEndOfPath2D(ProgressRatio))
		{
			if (DebugToggles.LogReachedEndOfPath)
			{
				GD.Print($"Node {Name} reached the end of the path!");
			}

			DamageCastle();
			Die();
		}
	}

	private void DamageCastle()
	{
		if (DebugToggles.DebugEnabled)
		{
			GD.Print($"Damaging the castle {_castle}!");
		}

		_castle?.ApplyDamage(AttackDamage);
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
		if (DebugToggles.LogEntityDeaths)
		{
			GD.Print($"Enemy {Name} has died.");
		}

		EmitSignalOnDeath();
		QueueFree();
	}
}
