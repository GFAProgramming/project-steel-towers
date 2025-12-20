using Godot;
using SteelTowers.Attribute_Component;
using SteelTowers.Toggles;
using SteelTowers.Systems.Combat.Interfaces;

namespace SteelTowers.Castle;

public partial class Castle: Node2D, IDamageable
{
	public static NodePath NODE_PATH = new NodePath();
	
	[Signal]
	public delegate void OnDamageAppliedEventHandler();
	
	[Signal]
	public delegate void OnDeathEventHandler();

	public AnimatedSprite2D AnimatedSprite { get; private set; }
	public AttributeComponent HealthComponent { get; private set; }
	
	public override void _Ready()
	{
		AnimatedSprite = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
		HealthComponent = GetNode<AttributeComponent>("%HealthComponent");
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
			GD.Print($"Castle {this} has been destroyed!");
		}

		EmitSignalOnDeath();
		CallDeferred(Node.MethodName.QueueFree);
	}
}
