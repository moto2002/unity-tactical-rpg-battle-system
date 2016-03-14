using UnityEngine;

public class GridCursor {

	public string name;
	public Vector3 position;
	public GameObject obj;

	public GridCursor (string _name) {
		name = _name;
	}
}

public class GridCursorController : MonoBehaviour {

	private const string wrapperName = "Cursor";

	private GameObject cursorWrapper;

	public GridCursor mainCursor;
	public Grid grid = new Grid();

	private void Start () {
		CreateCursorWrapper();
	}

	private void Update () {
		if (grid.Count == 0) {
			grid = GetComponent<GridController>().grid;
		}

		// TODO: Create the cursor when needed (player input).
		if (grid.Count > 0 && mainCursor == null) {
			mainCursor = CreateGridCursor("MainCursor", grid[2][4].position);
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
	private GridCursor CreateGridCursor (string cursorName, Vector3 cursorPosition) {
		var newCursor = new GridCursor(cursorName);
		newCursor.position = cursorPosition;
		newCursor.obj = CreateCursorObject(newCursor);

		return newCursor;
	}

	/// <summary>
	/// Create a cursor game object from cell data.
	/// </summary>
	///
	/// <param name="cursor">The cursor to create the game object.</param>
	///
	/// <returns>The cursor game object.</returns>
	private GameObject CreateCursorObject (GridCursor cursor) {
		var offset = new Vector3(0, 0.1f, 0);
		var cursorObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cursorObject.name = cursor.name;
		cursorObject.transform.position = cursor.position + offset;
		cursorObject.transform.parent = cursorWrapper.transform;

		cursorObject.GetComponent<Renderer>().material.color = Color.red;

		return cursorObject;
	}
}
