using UnityEngine;
using Tactical.Core;

namespace Tactical.Grid {

	public class CellCursorPlayerInput : MonoBehaviour {

		public CellCursorMovement movementComponent;
		public bool movementOnCooldown;

		public delegate void CellSelectedAction(Vector3 gridPosition);
		public static event CellSelectedAction OnCellSelected;

		private const float baseMovement = 1f;
		private const float movementCooldown = 0.1f;
		private float lastMovement;

		private void OnEnable () {
			RegisterInputsActions();
		}

		private void OnDisable () {
			DeregisterInputsActions();
		}

		private void Update () {
			if (movementComponent == null) {
				movementComponent = GetComponent<CellCursorMovement>();
			}

			movementOnCooldown = Time.time > lastMovement + movementCooldown;
		}

		private void MoveRelative (Vector3 position) {
			if (movementOnCooldown) {
				movementComponent.MoveRelative(position);
				lastMovement = Time.time;
			}
		}

		private void MoveUp () {
			MoveRelative(new Vector3(baseMovement, 0, 0));
		}

		private void MoveRight () {
			MoveRelative(new Vector3(0, 0, -baseMovement));
		}

		private void MoveDown () {
			MoveRelative(new Vector3(-baseMovement, 0, 0));
		}

		private void MoveLeft () {
			MoveRelative(new Vector3(0, 0, baseMovement));
		}

		private void SelectCell () {
			if (OnCellSelected != null && movementComponent != null) {
				OnCellSelected(movementComponent.gridPosition);
			}
		}

		/// <summary>
		/// Register the input actions.
		/// </summary>
		private void RegisterInputsActions () {
			PlayerInput.OnButtonUpPressed += MoveUp;
			PlayerInput.OnButtonRightPressed += MoveRight;
			PlayerInput.OnButtonDownPressed += MoveDown;
			PlayerInput.OnButtonLeftPressed += MoveLeft;
			PlayerInput.OnButton1Pressed += SelectCell;
		}

		/// <summary>
		/// Deregister the input actions.
		/// </summary>
		private void DeregisterInputsActions () {
			PlayerInput.OnButtonUpPressed -= MoveUp;
			PlayerInput.OnButtonRightPressed -= MoveRight;
			PlayerInput.OnButtonDownPressed -= MoveDown;
			PlayerInput.OnButtonLeftPressed -= MoveLeft;
			PlayerInput.OnButton1Pressed -= SelectCell;
		}

	}

}
