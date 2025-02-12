using Godot;
using System;
using System.Collections.Generic;

public partial class Asteroid : RigidBody2D
{
	int type;
	public override void _Ready()
	{
		AnimatedSprite2D sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		string[]  asteroidTypes = sprite.SpriteFrames.GetAnimationNames();
		int rng = (int)GD.Randi() % 100;
		if (rng <= 70)
		{
			type = 0;
		}
		if (rng > 70 && rng <= 90)
		{
			type = 4;
		}
		if (rng > 90 && rng <= 94)
		{
			type = 2;
		}
		if (rng > 94 && rng <= 98)
		{
			type = 3;
		}
		if (rng == 99)
		{
			type = 1;
		}

	}
	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
	public override void _Process(double delta)
	{
	}
}
