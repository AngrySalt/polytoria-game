using Polytoria.Attributes;

namespace Polytoria.Datamodel;

[Instantiable]
public partial class UIAspectRatioRestraint : Instance
{
	private DominantAxisEnum _dominantAxis = default;
	private float _aspectRatio = 1;

	[Editable, ScriptProperty]
	public DominantAxisEnum DominantAxis
	{
		get => _dominantAxis;
		set
		{
			if (_dominantAxis == value) return;
			_dominantAxis = value;
			UpdateParentSize();
		}
	}
	[Editable, ScriptProperty]
	public float AspectRatio
	{
		get => _aspectRatio;
		set
		{
			if (value == _aspectRatio) return;
			_aspectRatio = value;
			UpdateParentSize();
		}
	}

	private void UpdateParentSize()
	{
		if (IsHidden || Parent is not UIField field || field.NodeControl == null) return;
		field.RecomputeTransform();
	}

	public override void EnterTree()
	{
		UpdateParentSize();
		base.EnterTree();
	}

	public override void ExitTree()
	{
		UpdateParentSize();
		base.ExitTree();
	}
}

[ScriptEnum]
public enum DominantAxisEnum
{
	Width = 0,
	Height = 1
}
