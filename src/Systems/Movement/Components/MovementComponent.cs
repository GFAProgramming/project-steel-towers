using System;
using Godot;

namespace SteelTowers.Systems.Movement.Components;

public partial class MovementComponent: Node
{
	[Export]
	public float Speed { get; private set; }

	public void Move(double delta)
	{
		PathFollow2D owner = Owner as PathFollow2D ?? throw new InvalidOperationException("MovementComponent doesn't yet support movement on nodes that do not inherit from PathFollow2D");

		owner.Progress += (float) (Speed * delta);
	}
}
