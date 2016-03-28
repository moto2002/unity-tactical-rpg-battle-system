using UnityEngine;

namespace Tactical.Unit {

	[DisallowMultipleComponent]
	public class UnitMovement : MonoBehaviour {

		private UnitCore unitComponent;

		/// <summary>
		/// Move the unit relatively to its current position except if it is
		/// going out of range.
		/// </summary>
		///
		/// <param name="offset">The offset to add to the current position.</param>
		///
		/// <returns>The new grid position of the cursor.</returns>
		public Vector3 MoveRelative (Vector3 offset) {
			var newPosition = unitComponent.gridPosition + offset;

			return Move(newPosition);
		}

		/// <summary>
		/// Move the unit to the destination expect if it is going out of range.
		/// </summary>
		///
		/// <param name="destination">The destination to move the unit to.</param>
		///
		/// <returns>The new position of the unit.</returns>
		public Vector3 Move (Vector3 destination) {
			if (!CanMoveTo(destination)) {
				return unitComponent.gridPosition;
			}

			unitComponent.gridPosition = destination;

			// TODO: Trigger an event when the unit is moved.

			return unitComponent.gridPosition;
		}

		private void Update () {
			if (unitComponent == null) {
				unitComponent = GetComponent<UnitCore>();
			}
		}

		private bool CanMoveTo (Vector3 targetPosition) {
			// TODO: Check if the player can move there.
			return true;
		}

	}

}
