using UnityEngine;
using UnityEngine.InputNew;

// GENERATED FILE - DO NOT EDIT MANUALLY
public class BattleControls : ActionMapInput {
	public BattleControls (ActionMap actionMap) : base (actionMap) { }
	
	public ButtonInputControl @confirm { get { return (ButtonInputControl)this[0]; } }
	public AxisInputControl @moveX { get { return (AxisInputControl)this[1]; } }
	public AxisInputControl @moveY { get { return (AxisInputControl)this[2]; } }
	public ButtonInputControl @cancel { get { return (ButtonInputControl)this[3]; } }
}
