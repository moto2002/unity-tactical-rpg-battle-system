using UnityEngine;
using System.Collections.Generic;

namespace Tactical.Grid {

	public class CursorController : MonoBehaviour {

		private const string wrapperName = "Cursor";

		private GameObject cursorWrapper;

		public CellCursor mainCursor;
		public GridCollection grid = new GridCollection();

		private void Start () {
			CreateCursorWrapper();
		}

		private void Update () {
			if (grid.Count == 0) {
				grid = GetComponent<GridController>().grid;
			}

			// TODO: Create the cursor when needed (player input).
			if (grid.Count > 0 && mainCursor == null) {
				mainCursor = CreateCellCursor("MainCursor", grid[2][4].position);
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
			obj.perimeter = new GridPerimeter {
				x = new GridRange { min = 0f, max = grid.Count },
				y = new GridRange { min = 0f, max = grid[0].Count }
			};

			return obj;
		}
	}

}
