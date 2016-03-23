using UnityEngine;
using Tactical.Terrain;
using Tactical.Grid;

namespace Tactical.Grid {

	public class Cell {

		public string name;
		public Vector3 position;
		public GameObject obj;

		private Vector3 objectOffset = new Vector3(0, 0, 0);

		public static Cell CreateInstance (int cellTerrainId, Vector3 position, GameObject wrapper) {

			var cell = new Cell {
				name = "Cell_" + position.x + "_" + position.z,
				position = position
			};
			cell.CreateObject(cellTerrainId, wrapper);

			return cell;
		}

		/// <summary>
		/// Create a cell game object and attach it to the obj property.
		/// </summary>
		///
		/// <param name="wrapper">The wrapper game object to create into.</param>
		///
		/// <returns>The cell game object.</returns>
		private void CreateObject (int cellTerrainId, GameObject wrapper) {
			// Create the object.
			obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.name = name;
			obj.transform.position = position + objectOffset;
			obj.transform.parent = wrapper.transform;

			// Add CellOverlay component.
			var cellOverlay = obj.AddComponent<CellOverlay>();

			// Add Terrain component.
			// CellTerrain.CreateComponent(obj);
		}

	}

}
