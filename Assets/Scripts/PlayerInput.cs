using UnityEngine;
using System.Collections;

public class PlayerInput: MonoBehaviour {

	public float horizontal;
	public float vertical;
	public bool button1;
	public bool button2;

	public delegate void Button1Action();
	public static event Button1Action OnButton1Pressed;

	public delegate void Button2Action();
	public static event Button2Action OnButton2Pressed;

	public delegate void ButtonUpAction();
	public static event ButtonUpAction OnButtonUpPressed;

	public delegate void ButtonRightAction();
	public static event ButtonRightAction OnButtonRightPressed;

	public delegate void ButtonDownAction();
	public static event ButtonDownAction OnButtonDownPressed;

	public delegate void ButtonLeftAction();
	public static event ButtonLeftAction OnButtonLeftPressed;

	private void Update () {
		GetInputs();
		HandleInputs();
	}

	private void GetInputs () {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		button1 = GetInput("Fire1");
		button2 = GetInput("Jump");
	}

	private void HandleInputs () {
		if (vertical > 0f) {
			if (OnButtonUpPressed != null) { OnButtonUpPressed(); }
		} else if (vertical < 0f) {
			if (OnButtonDownPressed != null) { OnButtonDownPressed(); }
		}
		if (horizontal > 0f) {
			if (OnButtonRightPressed != null) { OnButtonRightPressed(); }
		} else if (horizontal < 0f) {
			if (OnButtonLeftPressed != null) { OnButtonLeftPressed(); }
		}

		if (button1 && OnButton1Pressed != null) { OnButton1Pressed(); }
		if (button2 && OnButton2Pressed != null) { OnButton2Pressed(); }
	}

	public static bool GetInput (string buttonName) {
		return Input.GetButtonDown(buttonName);
	}
}
