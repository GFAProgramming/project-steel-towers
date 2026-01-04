using Godot;
using SteelTowers.Systems.Combat.Interfaces;

namespace SteelTowers.Systems.Combat.Components;

public partial class AttackComponent: Node
{
	[Export]
	public int Damage { get; protected set; }
	
	public IHealth? Target { get; protected set; }

	public virtual void Process(Area2D ownerArea2D)
	{
		
	}

	public void Attack(IHealth? target)
	{
		if (!CanAttackTarget(target))
		{
			return;
		}
		
		target!.Health.Damage(Damage);
	}

	
	private bool CanAttackTarget(IHealth? target)
	{
		return target is not null;
	}
}
