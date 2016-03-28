using UnityEngine;
using Tactical.Battle;
using Tactical.Unit;

namespace Tactical.Grid {

	public class CursorController : MonoBehaviour {

		public CellCursor mainCursor;

		private const string wrapperName = "Cursor";
		private GridController gridController;

		private void OnEnable () {
			TurnManager.OnPlayerActionStarted += CreateMainCursor;
			PlayerActionManager.OnActionEnded += DeleteMainCursor;
		}

		private void OnDisable () {
			TurnManager.OnPlayerActionStarted -= CreateMainCursor;
			PlayerActionManager.OnActionEnded -= DeleteMainCursor;
		}

		private void Start () {
			gridController = GameObject.Find("Grid").GetComponent<GridController>();
		}

		private void CreateMainCursor (GameObject unit, PlayerControllable.Player player) {
			if (mainCursor != null) { return; }

			mainCursor = CreateCellCursor(
				"MainCursor",
				unit.GetComponent<UnitCore>().gridPosition
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
