using Godot;
using System;

public partial class MeshParent : Node
{
	[Export]
	public MeshInstance3D MeshInstance;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (!IsInstanceValid(MeshInstance))
			MeshInstance = GetChild<MeshInstance3D>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
