using UnityEngine;
using System.Collections.Generic;

public class GridController : MonoBehaviour {

  private const int gridWidth = 10;
  private const int gridHeight = 10;

  private const string wrapperName = "Grid";
  private GameObject gridWrapper;

  public Grid grid;

  private void Start () {
    grid = GenerateGrid(gridWidth, gridHeight);

    CreateGridWrapper();
    CreateGridCells();
  }

  /// <summary>
  /// Generate the grid variable that will hold the the logic of the cells.
  /// </summary>
  ///
  /// <param name="width">The width of the grid.</param>
  /// <param name="height">The height of the grid.</param>
  ///
  /// <returns>The generated grid.</returns>
  private Grid GenerateGrid (int width, int height)
  {
    var newGrid = new Grid();

    for (int x = 0; x < width; x++) {
      var row = new List<GridCell>();

      for (int y = 0; y < height; y++) {
        var cellPosition = new Vector3(x, 0, y);
        var cell = new GridCell(cellPosition);

        row.Add(cell);
      }

      newGrid.Add(row);
    }

    return newGrid;
  }

  /// <summary>
  /// Creates an empty object as a child of the current object that will contain all grid cells later on.
  /// </summary>
  private void CreateGridWrapper ()
  {
    gridWrapper = new GameObject(wrapperName);
    gridWrapper.transform.parent = transform;
  }

  /// <summary>
  /// Create the grid cell objects inside the wrapper.
  /// </summary>
  private void CreateGridCells ()
  {
    for (int x = 0; x < grid.Count; x++) {
      for (int y = 0; y < grid[x].Count; y++) {
        GameObject cellObject = CreateGridCell(grid[x][y], new Vector3(x, 0, y));
        cellObject.transform.parent = gridWrapper.transform;

        // currentSkills.Add(cellObject);
      }
    }
  }

  /// <summary>
  /// Create a cell game object from cell data.
  /// </summary>
  ///
  /// <param name="cell">The cell to create the game object.</param>
  /// <param name="position">Initial position of the cell.</param>
  ///
  /// <returns>The created cell.</returns>
  private GameObject CreateGridCell (GridCell cell, Vector3 position)
  {
    var cellObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
    cellObject.name = cell.name;
    cellObject.transform.position = position;
    cell.obj = cellObject;

    return cellObject;
  }
}
