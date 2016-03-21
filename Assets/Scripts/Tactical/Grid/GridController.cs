using UnityEngine;
using System.Collections.Generic;

namespace Tactical.Grid {

	public class GridController : MonoBehaviour {

		public GridCollection grid;

		private const string wrapperName = "Grid";
		private GameObject gridWrapper;

		private void Start () {
			CreateGridWrapper();

			grid = new GridCollection {
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(0, 0, 0), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 1), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 2), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 3), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 4), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 5), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 6), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 7), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(0, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(1, 0, 0), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 1), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 2), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 3), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 4), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 5), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 6), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 7), gridWrapper),
					Cell.CreateInstance(1, new Vector3(1, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(1, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(2, 0, 0), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 1), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 2), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 3), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 4), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 5), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 6), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 7), gridWrapper),
					Cell.CreateInstance(1, new Vector3(2, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(2, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(3, 0, 0), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 1), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 2), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 3), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 4), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 5), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 6), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 7), gridWrapper),
					Cell.CreateInstance(1, new Vector3(3, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(3, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(4, 0, 0), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 1), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 2), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 3), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 4), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 5), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 6), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 7), gridWrapper),
					Cell.CreateInstance(1, new Vector3(4, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(4, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(5, 0, 0), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 1), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 2), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 3), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 4), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 5), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 6), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 7), gridWrapper),
					Cell.CreateInstance(1, new Vector3(5, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(5, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(6, 0, 0), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 1), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 2), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 3), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 4), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 5), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 6), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 7), gridWrapper),
					Cell.CreateInstance(1, new Vector3(6, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(6, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(7, 0, 0), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 1), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 2), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 3), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 4), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 5), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 6), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 7), gridWrapper),
					Cell.CreateInstance(1, new Vector3(7, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(7, 0, 9), gridWrapper)
				},
				new List<Cell> {
					Cell.CreateInstance(3, new Vector3(8, 0, 0), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 1), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 2), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 3), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 4), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 5), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 6), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 7), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 8), gridWrapper),
					Cell.CreateInstance(3, new Vector3(8, 0, 9), gridWrapper)
				}
			};
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
