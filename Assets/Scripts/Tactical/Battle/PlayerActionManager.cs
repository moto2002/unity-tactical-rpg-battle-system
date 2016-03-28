using UnityEngine;
using System.Collections;
using Tactical.Unit;
using Tactical.Grid;

namespace Tactical.Battle {

	public class PlayerActionManager : MonoBehaviour {

		public delegate void ActionEndedAction();
		public static event ActionEndedAction OnActionEnded;

		private TurnManager turnManager;
		private GameObject unit;

		private void OnEnable () {
			TurnManager.OnPlayerActionStarted += StartAction;
			CellCursorPlayerInput.OnCellSelected += MoveTo;
		}

		private void OnDisable () {
			TurnManager.OnPlayerActionStarted -= StartAction;
			CellCursorPlayerInput.OnCellSelected -= MoveTo;
		}

		private void Update () {
      // Get the turn manager.
			if (turnManager == null) {
				turnManager = GetComponent<TurnManager>();
			}
		}

		private void MoveTo (Vector3 gridPosition) {
			unit.GetComponent<UnitMovement>().Move(gridPosition);
			EndAction();
		}

		public void StartAction (GameObject actionUnit, PlayerControllable.Player player) {
			unit = actionUnit;
			Debug.Log("Player action [start]");
		}

		public static void EndAction () {
			Debug.Log("Player action [end]");
			if (OnActionEnded != null) { OnActionEnded(); }
		}

	}

}
