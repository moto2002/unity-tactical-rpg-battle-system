using UnityEngine;

namespace Tactical.Grid {

	public class CellCursor {

		public string name;
		public Vector3 position;
		public GameObject obj;

		private Vector3 objectOffset = new Vector3(0, 0.55f, 0);

		public CellCursor (string defaultName, Vector3 defaultPosition, GameObject defaultWrapper) {
			name = defaultName;
			position = defaultPosition;

			CreateObject(defaultWrapper);
		}

		public Vector3 MoveRelative (Vector3 movement) {
			position = position + movement;
			obj.transform.position = position + objectOffset;

			return position;
		}

		/// <summary>
		/// Create a cursor game object and attach it to the obj property.
		/// </summary>
		///
		/// <param name="wrapper">The wrapper game object to create into.</param>
		///
		/// <returns>The cursor game object.</returns>
		private void CreateObject (GameObject wrapper) {
			obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.name = name;
			obj.transform.position = position + objectOffset;
			obj.transform.parent = wrapper.transform;
			obj.transform.localScale = new Vector3(1f, 0.05f, 1f);
			obj.GetComponent<Renderer>().material.color = Color.red;
		}
	}
}
