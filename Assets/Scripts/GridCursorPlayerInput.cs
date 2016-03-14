using UnityEngine;

// TODO: Put this into a Grid namespace.
public class GridCursorPlayerInput : MonoBehaviour {

	public GridCursor cursor;

	private void OnEnable () {
		RegisterInputsActions();
	}

	private void OnDisable () {
		DeregisterInputsActions();
	}

	private void Update () {
		if (cursor == null) {
			cursor = GetComponent<GridCursorController>().mainCursor;
		}
	}

	/// <summary>
	/// Registers the input actions.
	/// </summary>
	private void RegisterInputsActions () {
		PlayerInput.OnButton1Pressed += SelectCell;
		PlayerInput.OnButton2Pressed += DeselectCell;
	}

	/// <summary>
	/// Deregister the input actions.
	/// </summary>
	private void DeregisterInputsActions () {
		PlayerInput.OnButton1Pressed -= SelectCell;
		PlayerInput.OnButton2Pressed -= DeselectCell;
	}

	private void SelectCell () {
		Debug.Log("[x] " + cursor.position);
		cursor.obj.GetComponent<Renderer>().material.color = Color.yellow;
	}

	private void DeselectCell () {
		Debug.Log("[ ] " + cursor.position);
		cursor.obj.GetComponent<Renderer>().material.color = Color.red;
	}
}
