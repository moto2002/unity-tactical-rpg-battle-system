using UnityEngine;
using System.Collections.Generic;

namespace Tactical.Grid {

	public class CursorController : MonoBehaviour {

		public CellCursor mainCursor;
		public GridPerimeter cursorPerimeter = new GridPerimeter {
			x = new GridRange { min = 0f, max = 0f },
			y = new GridRange { min = 0f, max = 0f }
		};

		private List<Vector3> allowedPositions = new List<Vector3>();
		private const string wrapperName = "Cursor";
		private GameObject cursorWrapper;
		private GridController gridController;


		private void Start () {
			gridController = GetComponent<GridController>();
			CreateCursorWrapper();
		}

		private void Update () {
			// // TODO: Create the cursor when needed (player input).
			if (mainCursor == null && gridController != null) {
				mainCursor = CreateCellCursor("MainCursor", new Vector3());
			}
		}

		/// <summary>
		/// Creates an empty object as a child of the current object that will contain all grid cells later on.
		/// </summary>
		private void CreateCursorWrapper () {
			cursorWrapper = new GameObject(wrapperName);
			cursorWrapper.transform.parent = transform;
		}

		/// <summary>
		/// Create a grid cursor with its game object.
		/// </summary>
		///
		/// <param name="cursorName">The name of the cursor.</param>
		/// <param name="cursorPosition">The initial position of the cursor.</param>
		///
		/// <returns>The created cursor.</returns>
		private CellCursor CreateCellCursor (string cursorName, Vector3 cursorPosition) {
			var obj = new CellCursor(cursorName, cursorPosition, cursorWrapper);
			obj.allowedPositions = gridController.GetAllowedPositions();

			return obj;
		}
	}

}
