using Godot;
using System;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;

public partial class Player : Area2D
{	
	[Signal]
	public delegate void HitEventHandler();
	[Export]
	public int SpeedCap {get; set;} = 500;
	[Export]
	public int SpeedUp {get; set;} = 10;
	public int Speed = 0;
	public const float rad = 0.0174532925f;
	public float angle = 0f;
	public bool flag = false;
	public Vector2 SSize;
	private void OnBodyEntered(Node2D body)
	{
		Hide();
		EmitSignal(SignalName.Hit);
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
	}
	public void Start(Vector2 position)
	{
		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
    public override void _Ready()
    {
		Hide();
		SSize = GetViewportRect().Size;
    }
    
	public override void _PhysicsProcess(double delta)
	{
		flag = false;
		if (Input.IsActionPressed("turn_clock"))
		{
			angle += 2f;
		}
		if (Input.IsActionPressed("turn_cnt_clock"))
		{
			angle -= 2f;
		}
		if (Input.IsActionPressed("accelerate"))
		{
			flag = true;
		}
		AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite2D.Rotation = angle*rad;
		Vector2 velocity = Vector2.FromAngle((angle+270)*rad);
		if (flag)
		{
			Speed = Math.Min(SpeedCap, Speed+SpeedUp); 
			velocity *= Speed;
			animatedSprite2D.Animation = "up";
			animatedSprite2D.Play();
		}
		else 
		{
			Speed = Math.Max(0, Speed-(int)Math.Round(SpeedUp/2d));
			velocity *= Speed;
			animatedSprite2D.Animation = "default";
			animatedSprite2D.Stop();
		}

		Position += velocity * (float)delta;
		int pix = 10;
		if (Position.X+pix < 0) {Position += new Vector2(SSize.X+2*pix, 0);}
		if (Position.X > SSize.X+pix) {Position -= new Vector2(SSize.X-2*pix, 0);}
		if (Position.Y+pix < 0) {Position += new Vector2(0, SSize.Y+2*pix);}
		if (Position.Y > SSize.Y+pix) {Position -= new Vector2(0, SSize.Y+2*pix);}
	}
}

