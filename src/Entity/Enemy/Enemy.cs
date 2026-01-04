using Godot;
using SteelTowers.Toggles;
using SteelTowers.Utilities;

namespace SteelTowers.Entity.Enemy;

public partial class Enemy: Unit
{
    private Castle.Castle? _castle;

    public override void _Ready()
    {
        base._Ready();
        _castle = NodeUtilities.FindNodeByType<Castle.Castle>(GetTree().Root) as Castle.Castle;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        
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

        _castle?.Health.Damage(Attack.Damage);
    }
}