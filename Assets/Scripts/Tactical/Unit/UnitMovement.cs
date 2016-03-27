using UnityEngine;

namespace Tactical.Unit {

	[DisallowMultipleComponent]
	public class UnitMovement : MonoBehaviour {

		private Unit unitComponent;

		/// <summary>
		/// Move the cursor relatively to its current position (except if it's
		/// going out of the perimeter).
		/// </summary>
		///
		/// <param name="offset">The offset to add to the current position.</param>
		///
		/// <returns>The new grid position of the cursor.</returns>
		public Vector3 MoveRelative (Vector3 offset) {
			var newPosition = unitComponent.gridPosition + offset;

			if (!CanMoveTo(newPosition)) {
				return unitComponent.gridPosition;
			}

			unitComponent.gridPosition = newPosition;

			return unitComponent.gridPosition;
		}

		private void Update () {
			if (unitComponent != null) {
				unitComponent = GetComponent<Unit>();
			}
		}

		private bool CanMoveTo (Vector3 targetPosition) {
			// TODO: Check if the player can move there.
			return true;
		}

	}

}
