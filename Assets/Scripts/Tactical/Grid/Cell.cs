using UnityEngine;
using Tactical.Terrain;

namespace Tactical.Grid {

	public class Cell {

		public string name;
		public Vector3 position;
		public GameObject obj;

		private Vector3 objectOffset = new Vector3(0, 0, 0);

		public static Cell CreateInstance (Vector3 position, GameObject wrapper, TerrainType terrainType) {

			var cell = new Cell {
				name = "Cell_" + position.x + "_" + position.z,
				position = position
			};
			cell.CreateObject(wrapper, terrainType);

			return cell;
		}


		/// <summary>
		/// Create a cell game object and attach it to the obj property.
		/// </summary>
		///
		/// <param name="wrapper">The wrapper game object to create into.</param>
		/// <param name="terrainType">Type of terrain to set the Terrain component.</param>
		///
		/// <returns>The cell game object.</returns>
		private void CreateObject (GameObject wrapper, TerrainType terrainType) {
			// Create the object.
			obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.name = name;
			obj.transform.position = position + objectOffset;
			obj.transform.parent = wrapper.transform;

			// Add CellOverlay component.
			var cellOverlay = obj.AddComponent<CellOverlay>();

			// Add Terrain component.
			var terrain = obj.AddComponent<Terrain.Terrain>();
			terrain.type = terrainType;
		}
	}

}
