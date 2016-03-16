using UnityEngine;

namespace Tactical.Grid {

	public class CellCursorPlayerInput : MonoBehaviour {

		public CellCursor cursor;

		private const float baseMovement = 1f;
		private const float movementCooldown = 0.15f;
		private float lastMovement;

		private void OnEnable () {
			RegisterInputsActions();
		}

		private void OnDisable () {
			DeregisterInputsActions();
		}

		private void Update () {
			if (cursor == null) {
				cursor = GetComponent<CursorController>().mainCursor;
			}
		}

		/// <summary>
		/// Registers the input actions.
		/// </summary>
		private void RegisterInputsActions () {
			PlayerInput.OnButton1Pressed += SelectCell;
			PlayerInput.OnButton2Pressed += DeselectCell;
			PlayerInput.OnButtonUpPressed += MoveUp;
			PlayerInput.OnButtonRightPressed += MoveRight;
			PlayerInput.OnButtonDownPressed += MoveDown;
			PlayerInput.OnButtonLeftPressed += MoveLeft;
		}

		/// <summary>
		/// Deregister the input actions.
		/// </summary>
		private void DeregisterInputsActions () {
			PlayerInput.OnButton1Pressed -= SelectCell;
			PlayerInput.OnButton2Pressed -= DeselectCell;
			PlayerInput.OnButtonUpPressed -= MoveUp;
			PlayerInput.OnButtonRightPressed -= MoveRight;
			PlayerInput.OnButtonDownPressed -= MoveDown;
			PlayerInput.OnButtonLeftPressed -= MoveLeft;
		}

		private void MoveUp () {
			Move(new Vector3(baseMovement, 0, 0));
		}

		private void MoveRight () {
			Move(new Vector3(0, 0, -baseMovement));
		}

		private void MoveDown () {
			Move(new Vector3(-baseMovement, 0, 0));
		}

		private void MoveLeft () {
			Move(new Vector3(0, 0, baseMovement));
		}

		private void Move (Vector3 position) {
			if (Time.time > lastMovement + movementCooldown) {
				cursor.MoveRelative(position);
				lastMovement = Time.time;
			}
		}

		private void SelectCell () {
			Debug.Log("[x] " + cursor.position);
			cursor.obj.GetComponent<Renderer>().material.color = Color.yellow;
		}

		private void DeselectCell () {
			Debug.Log("[ ] " + cursor.position);
			cursor.obj.GetComponent<Renderer>().material.color = Color.red;
		}
	}

}
