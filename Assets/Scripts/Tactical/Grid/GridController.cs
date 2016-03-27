using UnityEngine;
using System.Collections.Generic;

namespace Tactical.Grid {

	public class GridController : MonoBehaviour {

		public List<GridCell> cells = new List<GridCell>();

		/// <summary>
		/// Get a list of allowed positions.
		/// </summary>
		///
		/// @todo Skip invalid cells that the player can't go to.
		///
		/// <returns>A list of positions.</returns>
		public List<Vector3> GetAllowedPositions () {

			var allowedPositions = new List<Vector3>();
			cells.ForEach(cell => allowedPositions.Add(cell.gridPosition));

			return allowedPositions;
		}

		/// <summary>
		/// Convert a transform position to a cell position.
		/// </summary>
		///
		/// <param name="cellPosition">The source position.</param>
		///
		/// <returns>The position of the cell in the grid.</returns>
		public static Vector3 CellToGridPosition (Vector3 cellPosition) {
			var gridPosition = cellPosition;
			return gridPosition;
		}

		/// <summary>
		/// Convert a transform position (unit) to a grid position.
		/// </summary>
		///
		/// <param name="unitPosition">The source position.</param>
		///
		/// <returns>The position of the unit in the grid.</returns>
		public static Vector3 UnitToGridPosition (Vector3 unitPosition) {
			var gridPosition = unitPosition + new Vector3(0f, -1f, 0f);
			return gridPosition;
		}

		/// <summary>
		/// Convert a grid position to a unit position.
		/// </summary>
		///
		/// <param name="gridPosition">The source position.</param>
		///
		/// <returns>The position of the unit in the grid.</returns>
		public static Vector3 GridToUnitPosition (Vector3 gridPosition) {
			var unitPosition = gridPosition + new Vector3(0f, 1f, 0f);
			return unitPosition;
		}

		private void Start () {
			foreach (Transform child in transform) {
				var gridCellComponent = child.GetComponent<GridCell>();

				if (gridCellComponent != null) {
					cells.Add(child.GetComponent<GridCell>());
				} else {
					Debug.LogWarning("Missing component: GridCell");
				}
			}
		}
	}

}
