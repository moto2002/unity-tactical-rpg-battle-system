using UnityEngine;

namespace Tactical {

	public class PlayerInput: MonoBehaviour {

		public enum AxisState {
			Idle,
			Down,
			Held,
			Up
		}

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

		public delegate void DirectionButtonReleasedAction();
		public static event DirectionButtonReleasedAction OnDirectionButtonReleased;

		private float horizontal;
		private float vertical;
		private bool button1;
		private bool button2;
		private bool isPressingDirection;
		private const float deadZone = 0.02f;

		private void Update () {
			GetInputs();
			HandleInputs();
		}

		private void GetInputs () {
			horizontal = Input.GetAxisRaw("Horizontal");
			vertical = Input.GetAxisRaw("Vertical");
			button1 = Input.GetButtonDown("Fire1");
			button2 = Input.GetButtonDown("Jump");
		}

		private void HandleInputs () {
			// If the directional buttons are released (with a 0.2f margin).
			if (Mathf.Approximately(horizontal, 0f) && Mathf.Approximately(vertical, 0f)) {
				if (isPressingDirection && OnDirectionButtonReleased != null) {
					OnDirectionButtonReleased();
					isPressingDirection = false;
				}
			} else {
				isPressingDirection = true;

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
			}

			if (button1 && OnButton1Pressed != null) { OnButton1Pressed(); }
			if (button2 && OnButton2Pressed != null) { OnButton2Pressed(); }
		}

	}

}
