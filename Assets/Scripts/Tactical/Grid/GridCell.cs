using UnityEngine;
using System;
using Tactical.Grid;

namespace Tactical.Grid {

	[Serializable]
	public class GridCell {

		public Vector3 position;
		public GameObject obj;

		private Vector3 objectOffset = new Vector3(0, 0, 0);

		/// <summary>
		/// Convert a position to a position in the grid.
		/// </summary>
		///
		/// <param name="position">The source position.</param>
		///
		/// <returns>The position of the cell in the grid.</returns>
		public static Vector3 PositionToGridPosition (Vector3 position) {
			var gridPosition = position;
			return gridPosition;
		}

		/// <summary>
		/// Create a cell game object and attach it to the obj property.
		/// </summary>
		///
		/// <param name="wrapper">The wrapper game object to create into.</param>
		///
		/// <returns>The cell game object.</returns>
		private void CreateGameObject (GameObject wrapper) {
			// Create the object.
			obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.position = position + objectOffset;
			obj.transform.parent = wrapper.transform;

			// Add CellOverlay component.
			obj.AddComponent<CellOverlay>();

			// Add Terrain component.
			// CellTerrain.CreateComponent(obj);
		}

	}

}
