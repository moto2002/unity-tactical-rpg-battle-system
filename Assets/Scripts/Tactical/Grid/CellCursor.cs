using UnityEngine;
using System.Collections.Generic;

namespace Tactical.Grid {

	public class CellCursor {

		public string name;
		public Vector3 gridPosition;
		public List<Vector3> allowedPositions;
		public GameObject obj;

		private Vector3 objectOffset = new Vector3(0, 0.55f, 0);

		public CellCursor (
			string cursorName,
			Vector3 cursorPosition,
			GameObject cursorWrapper,
			GridController gridController
		) {
			name = cursorName;
			gridPosition = cursorPosition;

			// TODO: Destroy the game object in the destructor or something.
			CreateGameObject(cursorWrapper, gridController);
		}

		/// <summary>
		/// Create a cursor game object and attach it to the obj property.
		/// </summary>
		///
		/// <param name="wrapper">The wrapper game object to create into.</param>
		/// <param name="gridController">The grid controller to use inside the components.</param>
		///
		/// <returns>The cursor game object.</returns>
		private void CreateGameObject (GameObject wrapper, GridController gridController) {
			obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.name = name;
			obj.transform.parent = wrapper.transform;
			obj.transform.localScale = new Vector3(1f, 0.05f, 1f);

			// Set a basic material.
			obj.GetComponent<Renderer>().material.color = Color.red;

			// Add the movement component.
			var cellCursorPlayerInput = obj.AddComponent<CellCursorMovement>();
			cellCursorPlayerInput.gridController = gridController;

			// Add the player input component.
			obj.AddComponent<CellCursorPlayerInput>();
		}
	}
}
