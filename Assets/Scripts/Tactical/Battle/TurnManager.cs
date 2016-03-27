using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Tactical.Battle {

	[Serializable]
	public class TurnAction {
		public GameObject obj;
	}

	public class TurnManager : MonoBehaviour {

		public List<TurnAction> actions;

		public delegate void TurnStartedAction();
		public static event TurnStartedAction OnTurnStarted;

		public delegate void TurnEndedAction();
		public static event TurnEndedAction OnTurnEnded;

		public void StartTurn (List<GameObject> units) {
			if (OnTurnStarted != null) { OnTurnStarted(); }

			// Prepare the actions of this turn.
			PrepareActions(units);

			StartCoroutine(HandleTurn());
		}

		private void PrepareActions (List<GameObject> units) {
			foreach (GameObject unit in units) {
				Debug.Log("---- Adding unit action: " + unit.GetComponent<Unit.Unit>().GetFullName());

				actions.Add(new TurnAction {
					obj = unit
				});
			}
		}

		private IEnumerator HandleTurn () {
			yield return new WaitForSeconds(3f);

			// TODO: End the turn when everything is over.
			EndTurn();
		}

		public void EndTurn () {
			if (OnTurnEnded != null) { OnTurnEnded(); }
		}

		public void NextTurn (List<GameObject> units) {
			StartTurn(units);
		}

	}

}
