using System.Linq;
using Godot;
using SteelTowers.Systems.Combat.Interfaces;

namespace SteelTowers.Systems.Combat.Components;

public partial class AutoAttackComponent: AttackComponent
{
	public override void Process(Area2D ownerArea2D)
	{
		Target ??= TryFindTarget(ownerArea2D);
		  
		Attack(Target);
	}
	
	private IHealth? TryFindTarget(Area2D ownerArea2D)
	{
		return ownerArea2D
				.GetOverlappingAreas()
				.Select(area2D => area2D.Owner as IHealth)
				.FirstOrDefault(iHealthOrNull => iHealthOrNull is not null);
	}
}
