using Godot;
using steeltowers.Entity;

namespace steeltowers.Enemy;

public partial class Enemy: Node2D, IEntity
{
    public AnimatedSprite2D AnimatedSprite2D { get; }
    public Area2D Area2D { get; }

    public Enemy()
    {
        AnimatedSprite2D = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
        Area2D = GetNode<Area2D>("%Area2D");
    }
}