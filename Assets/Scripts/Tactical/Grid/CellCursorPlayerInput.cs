using UnityEngine;

namespace Tactical.Grid {

	public class CellCursorPlayerInput : MonoBehaviour {

		public CellCursor cursor;

		private const float baseMovement = 1f;
		private const float movementCooldown = 0.06f;
		public bool movementOnCooldown;
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

			movementOnCooldown = Time.time > lastMovement + movementCooldown;
		}

		private void MoveTo (Vector3 position) {
			if (movementOnCooldown) {
				cursor.MoveRelative(position);
				lastMovement = Time.time;
			}
		}

		private void MoveUp () {
			MoveTo(new Vector3(baseMovement, 0, 0));
		}

		private void MoveRight () {
			MoveTo(new Vector3(0, 0, -baseMovement));
		}

		private void MoveDown () {
			MoveTo(new Vector3(-baseMovement, 0, 0));
		}

		private void MoveLeft () {
			MoveTo(new Vector3(0, 0, baseMovement));
		}

		/// <summary>
		/// Registers the input actions.
		/// </summary>
		private void RegisterInputsActions () {
			PlayerInput.OnButtonUpPressed += MoveUp;
			PlayerInput.OnButtonRightPressed += MoveRight;
			PlayerInput.OnButtonDownPressed += MoveDown;
			PlayerInput.OnButtonLeftPressed += MoveLeft;
		}

		/// <summary>
		/// Deregister the input actions.
		/// </summary>
		private void DeregisterInputsActions () {
			PlayerInput.OnButtonUpPressed -= MoveUp;
			PlayerInput.OnButtonRightPressed -= MoveRight;
			PlayerInput.OnButtonDownPressed -= MoveDown;
			PlayerInput.OnButtonLeftPressed -= MoveLeft;
		}

	}

}
