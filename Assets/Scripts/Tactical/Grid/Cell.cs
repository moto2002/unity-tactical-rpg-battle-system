using UnityEngine;

namespace Tactical.Grid {

	public class Cell {

		public string name;
		public Vector3 position;
		public GameObject obj;

		private Vector3 objectOffset = new Vector3(0, 0, 0);

		public Cell (Vector3 defaultPosition, GameObject defaultWrapper) {
			position = defaultPosition;
			name = "Cell_" + position.x + "_" + position.z;

			CreateObject(defaultWrapper);
		}

		/// <summary>
		/// Create a cell game object and attach it to the obj property.
		/// </summary>
		///
		/// <param name="wrapper">The wrapper game object to create into.</param>
		///
		/// <returns>The cell game object.</returns>
		private void CreateObject (GameObject wrapper) {
			// Create the object.
			obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.name = name;
			obj.transform.position = position + objectOffset;
			obj.transform.parent = wrapper.transform;

			// Add CellColor component.
			var cellColor = obj.AddComponent<CellColor>();
			cellColor.color = new Color(0.5f, 0.5f, 0.5f, 1f);

			// Add CellOverlay component.
			var cellOverlay = obj.AddComponent<CellOverlay>();
		}
	}

}
