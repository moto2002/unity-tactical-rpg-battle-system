using UnityEngine;
using Tactical.Battle;
using Tactical.Unit;

namespace Tactical.Grid {

	public class CursorController : MonoBehaviour {

		public CellCursor mainCursor;

		private const string wrapperName = "Cursor";
		private GridController gridController;

		private void OnEnable () {
			PlayerTurnAction.OnMovementStarted += CreateMainCursor;
			PlayerActionManager.OnActionEnded += DeleteMainCursor;
		}

		private void OnDisable () {
			PlayerTurnAction.OnMovementStarted -= CreateMainCursor;
			PlayerActionManager.OnActionEnded -= DeleteMainCursor;
		}

		private void Start () {
			gridController = GameObject.Find("Grid").GetComponent<GridController>();
		}

		// private void CreateMainCursor (GameObject unit, PlayerControllable.Player player) {
		private void CreateMainCursor () {
			if (mainCursor != null) { return; }

			mainCursor = CreateCellCursor(
				"MainCursor",
				new Vector3()
			);
		}

		private void DeleteMainCursor () {
			Destroy(mainCursor.obj);
			mainCursor = null;
		}

		private CellCursor CreateCellCursor (string cursorName, Vector3 cursorPosition) {
			return new CellCursor(cursorName, cursorPosition, gameObject, gridController);
		}
	}

}
