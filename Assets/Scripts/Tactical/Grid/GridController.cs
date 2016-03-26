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
			cells.ForEach(cell => allowedPositions.Add(cell.position));

			return allowedPositions;
		}

		private void Start () {
			foreach (Transform child in transform) {
				cells.Add(new GridCell {
					position = GridCell.PositionToGridPosition(child.position),
					obj = child.gameObject
				});
			}
		}
	}

}
