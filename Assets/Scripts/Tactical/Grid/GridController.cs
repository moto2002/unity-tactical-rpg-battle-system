using UnityEngine;
using System.Collections.Generic;

namespace Tactical.Grid {

	public class GridController : MonoBehaviour {

		private const int gridWidth = 10;
		private const int gridHeight = 10;

		private const string wrapperName = "Grid";
		private GameObject gridWrapper;

		public GridCollection grid;

		private void Start () {
			CreateGridWrapper();
			grid = GenerateGrid(gridWidth, gridHeight);
		}

		/// <summary>
		/// Generate the grid variable that will hold the the logic of the cells.
		/// </summary>
		///
		/// <param name="width">The width of the grid.</param>
		/// <param name="height">The height of the grid.</param>
		///
		/// <returns>The generated grid.</returns>
		private GridCollection GenerateGrid (int width, int height) {
			var newGrid = new GridCollection();

			for (int x = 0; x < width; x++) {
				var row = new List<Cell>();

				for (int y = 0; y < height; y++) {
					var cellPosition = new Vector3(x, 0, y);
					var cell = new Cell(cellPosition, gridWrapper);

					row.Add(cell);
				}

				newGrid.Add(row);
			}

			return newGrid;
		}

		/// <summary>
		/// Creates an empty object as a child of the current object that will wrap all grid cells later on.
		/// </summary>
		private void CreateGridWrapper () {
			gridWrapper = new GameObject(wrapperName);
			gridWrapper.transform.parent = transform;
		}
	}

}
