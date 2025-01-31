using Godot;
using System;

public partial class Player : Area2D
{	
	[Export]
	public int Speed {get; set;} = 400;
	public double rad = 0.0174532925;
	public Vector2 SSize;
    public override void _Ready()
    {
		SSize = GetViewportRect().Size;
    }
    
	public override void _Process(double delta)
	{
		var movement = Vector2.Zero;
		// идея для мумента:
		// был неправ
		// 
		// просто у меня корабль это вектор у которого изначаль
		// опять неправ
		//корабля не существует это просто точка на ненго забить
		// когда поворот то англе меняется и от этого будет всегда строится вектор перемещзения
		// то есть когда у меня он прямо то постеепенно разганяется но если прямо смотрит то (1, 0)
		// а если не прям то вектор фром англе умножить на скорость которая постепенно увеличивается
		// воттак вот

		if (Input.IsActionPressed("turn_clock"))		
		{
			movement.X += 1;
		}
		if (I)
	}
}
