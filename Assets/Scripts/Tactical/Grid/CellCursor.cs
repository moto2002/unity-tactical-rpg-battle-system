using UnityEngine;

namespace Tactical.Grid {

	public class CellCursor {

		public string name;
		public Vector3 position;
		public GameObject obj;
		public GridPerimeter perimeter;

		private Vector3 objectOffset = new Vector3(0, 0.55f, 0);

		public CellCursor (string _name, Vector3 _position, GameObject _wrapper) {
			name = _name;
			position = _position;

			// TODO: Destroy the game object in the destructor or something.
			CreateObject(_wrapper);
		}

		/// <summary>
		/// Move the cursor relatively to its current position (except if it's
		/// going out of the perimeter).
		/// </summary>
		///
		/// <param name="offset">The offset to add to the current position.</param>
		///
		/// <returns>The new grid position of the cursor.</returns>
		public Vector3 MoveRelative (Vector3 offset) {
			var newPosition = position + offset;

			if (
				newPosition.x < perimeter.x.min || newPosition.x >= perimeter.x.max ||
				newPosition.z < perimeter.y.min || newPosition.z >= perimeter.y.max
			) {
				return position;
			}

			position = newPosition;
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
