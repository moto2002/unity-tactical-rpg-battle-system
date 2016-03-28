using UnityEngine;
using System.Collections.Generic;

namespace Tactical.Grid {

	public class CellCursorMovement : MonoBehaviour {

		public Vector3 gridPosition;
		public GridController gridController;

		public delegate void CursorMoved(Vector3 position);
		public static event CursorMoved OnCursorMoved;

		private List<Vector3> allowedPositions;
		private Vector3 objectOffset = new Vector3(0, 0.55f, 0);

		/// <summary>
		/// Move the cursor relatively to its current position except if it is
		/// going out of range.
		/// </summary>
		///
		/// <param name="offset">The offset to add to the current position.</param>
		///
		/// <returns>The new grid position of the cursor.</returns>
		public Vector3 MoveRelative (Vector3 offset) {
			var newPosition = gridPosition + offset;

			return Move(newPosition);
		}

		/// <summary>
		/// Move the cursor to the destination expect if it is going out of range.
		/// </summary>
		///
		/// <param name="destination">The destination to move the cursor to.</param>
		///
		/// <returns>The new position of the cursor.</returns>
		public Vector3 Move (Vector3 destination) {
			if (!CanMoveTo(destination)) {
				return gridPosition;
			}

			gridPosition = destination;

			UIManager.instance.unitInfo.visible = false;

			if (OnCursorMoved != null) {
				OnCursorMoved(gridPosition);
			}

			return gridPosition;
		}

		private void Update () {
			if (gridController != null) {
				allowedPositions = gridController.GetAllowedPositions();
			}

			UpdatePosition(gridPosition);
		}

		private void UpdatePosition (Vector3 targetPosition) {
			transform.position = gridPosition + objectOffset;
		}

		private bool CanMoveTo (Vector3 targetPosition) {
			return allowedPositions != null && allowedPositions.Contains(targetPosition);
		}
	}
}
