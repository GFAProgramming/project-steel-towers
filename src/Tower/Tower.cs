using Godot;

namespace SteelTowers.Tower;

public partial class Tower: Node2D
{
    public AnimatedSprite2D AnimatedSprite2D { get; private set; } = null!;
    public Area2D Area2D { get; private set; } = null!;
    
    public override void _Ready()
    {
        AnimatedSprite2D = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
        Area2D = GetNode<Area2D>("%Area2D");
    }
}