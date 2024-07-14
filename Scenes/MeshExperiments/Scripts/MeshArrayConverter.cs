using Godot;
using System;

public partial class MeshArrayConverter : MeshInstance3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var surfaceTool = new SurfaceTool();
		
		GD.Print($"Mesh Surface Count: {Mesh.GetSurfaceCount()}");
		
		for (var i = 0; i < Mesh.GetSurfaceCount(); i++)
		{
			surfaceTool.AppendFrom(Mesh, i, Transform3D.Identity);
		}

		var arrayMesh = surfaceTool.Commit();

		var newMesh = new MeshInstance3D()
		{
			Mesh = arrayMesh,
			GlobalPosition = Vector3.One
		};
		
		AddChild(newMesh);

		return;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
