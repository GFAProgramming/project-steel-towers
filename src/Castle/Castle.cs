using Godot;
using SteelTowers.Attribute_Component;
using SteelTowers.Systems.Combat.Components;
using SteelTowers.Toggles;
using SteelTowers.Systems.Combat.Interfaces;

namespace SteelTowers.Castle;

public partial class Castle: Node2D, IHealth
{
	public AnimatedSprite2D AnimatedSprite { get; private set; }
	public HealthComponent Health { get; private set;  }
	
	public override void _Ready()
	{
		AnimatedSprite = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
		Health = GetNode<HealthComponent>("%HealthComponent");
	}
}
