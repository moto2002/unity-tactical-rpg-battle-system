using UnityEngine;
using System.Collections;
using Tactical.Unit;

namespace Tactical.Battle {

	public class PlayerActionManager : MonoBehaviour {

		public delegate void ActionEndedAction();
		public static event ActionEndedAction OnActionEnded;

		private TurnManager turnManager;

		private void OnEnable () {
			TurnManager.OnPlayerActionStarted += StartAction;
		}

		private void OnDisable () {
			TurnManager.OnPlayerActionStarted -= StartAction;
		}

		private void Update () {
      // Get the turn manager.
			if (turnManager == null) {
				turnManager = GetComponent<TurnManager>();
			}
		}

		public void StartAction (GameObject unit, PlayerControllable.Player player) {
			Debug.Log("Player action [start]");
			// TODO: make the UI appear and call EndAction when we are done.

			// StartCoroutine(EndAction());
		}

		public static void EndAction () {
			Debug.Log("Player action [end]");
			if (OnActionEnded != null) {
				OnActionEnded();
			}
		}

	}

}
