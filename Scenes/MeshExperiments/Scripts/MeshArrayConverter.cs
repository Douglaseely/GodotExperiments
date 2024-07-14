using Godot;
using System;

public partial class MeshArrayConverter : Node
{
	[Export] public MeshParent MeshParent;
	private Mesh Mesh => MeshParent.MeshInstance.Mesh;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var surfaceTool = new SurfaceTool();

		var arrayMesh = GenerateArrayMesh(Mesh);

		var newMesh = new MeshInstance3D()
		{
			Mesh = arrayMesh,
			GlobalPosition = Vector3.One
		};
		
		AddChild(newMesh);

		return;
	}
	
	public static ArrayMesh GenerateArrayMesh(Mesh mesh, SurfaceTool surfaceTool = null, MeshDataTool meshDataTool = null)
	{
		if (mesh.GetType().IsAssignableTo(typeof(ArrayMesh)))
		{
			return mesh as ArrayMesh;
		}
        
		// Needed tools for Mesh manipulation
		surfaceTool ??= new SurfaceTool();
		meshDataTool ??= new MeshDataTool();

		for (var i = 0; i < mesh.GetSurfaceCount(); i++)
		{
			surfaceTool.CreateFrom(mesh, i);
		}

		var arrayMesh = surfaceTool.Commit();

		return arrayMesh;
	}
}
