using UnityEngine;
using Tactical.Grid;

namespace Tactical.Unit {

	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class Unit : MonoBehaviour {

		public string firstName;
		public string lastName;
		public Vector3 gridPosition;

		/// <summary>
		/// Get the full name of the unit.
		/// </summary>
		///
		/// <returns>The full name of the unit.</returns>
		public string GetFullName () {
			return firstName + " " + lastName;
		}

		private void OnEnable () {
			CellCursorMovement.OnCursorMoved += CheckCursorPosition;
		}

		private void OnDisable () {
			CellCursorMovement.OnCursorMoved -= CheckCursorPosition;
		}

		private void Update () {
			UpdatePosition(gridPosition);
		}

		private void UpdatePosition (Vector3 targetPosition) {
			transform.position = GridController.GridToUnitPosition(targetPosition);
		}

		private void CheckCursorPosition (Vector3 position) {
			if (gridPosition == position) {
				UIManager.instance.informationController.title = GetFullName();
				UIManager.instance.informationController.visible = true;
			}
		}

	}

}
