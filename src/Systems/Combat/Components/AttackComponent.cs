using Godot;
using SteelTowers.Systems.Combat.Interfaces;

namespace SteelTowers.Systems.Combat.Components;

public partial class AttackComponent: Node
{
	[Export]
	public int Damage { get; private set; }
	
	public void Attack(IHealth? target)
	{
		target?.Health.Damage(Damage);
	}
}
