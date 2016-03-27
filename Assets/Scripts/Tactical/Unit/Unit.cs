using UnityEngine;

namespace Tactical.Unit {

	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class Unit : MonoBehaviour {

		public string firstName;
		public string lastName;
		public Vector3 gridPosition;

		/// <summary>
		/// Move the cursor relatively to its current position (except if it's
		/// going out of the perimeter).
		/// </summary>
		///
		/// <param name="offset">The offset to add to the current position.</param>
		///
		/// <returns>The new grid position of the cursor.</returns>
		public Vector3 MoveRelative (Vector3 offset) {
			var newPosition = gridPosition + offset;

			if (!CanMoveTo(newPosition)) {
				return gridPosition;
			}

			gridPosition = newPosition;

			return gridPosition;
		}

		private bool CanMoveTo (Vector3 targetPosition) {
			// TODO: Check if the player can move there.
			return true;
		}

		/// <summary>
		/// Get the full name of the unit.
		/// </summary>
		///
		/// <returns>The full name of the unit.</returns>
		public string GetFullName () {
			return firstName + " " + lastName;
		}

		private void Update () {
			UpdatePosition(gridPosition);
		}

		private void UpdatePosition (Vector3 targetPosition) {
			transform.position = Grid.GridController.GridToUnitPosition(targetPosition);
		}

	}

}
