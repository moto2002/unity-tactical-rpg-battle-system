using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tactical.Unit;

namespace Tactical.Battle {

	public class TurnManager : MonoBehaviour {

		public List<TurnAction> actions = new List<TurnAction>();

		public delegate void TurnStartedAction();
		public static event TurnStartedAction OnTurnStarted;

		public delegate void TurnEndedAction();
		public static event TurnEndedAction OnTurnEnded;

		public delegate IEnumerator PCActionStartedAction(GameObject unit, PlayerControllable.Player player);
		public static event PCActionStartedAction OnPCActionStarted;

		public delegate IEnumerator NPCActionStartedAction(GameObject unit);
		public static event NPCActionStartedAction OnNPCActionStarted;

		private int currentActionIndex;

		/// <summary>
		/// Start the current turn with the given units.
		/// </summary>
		///
		/// <param name="units">The units to create the actions for.</param>
		public void StartTurn (List<GameObject> units) {
			if (OnTurnStarted != null) { OnTurnStarted(); }

			// Prepare the actions of this turn.
			PrepareActions(units);
			// Execute all actions in order.
			StartCoroutine(NextAction());
		}

		private void PrepareActions (List<GameObject> units) {
			currentActionIndex = 0;
			actions.Clear();

			foreach (GameObject unit in units) {
				var action = new TurnAction { unit = unit };
				var playerControllable = unit.GetComponent<PlayerControllable>();

				if (playerControllable != null) {
					action.isNPC = false;
					action.player = playerControllable.player;
				} else {
					action.isNPC = true;
				}

				actions.Add(action);
			}
		}

		public void EndTurn () {
			if (OnTurnEnded != null) { OnTurnEnded(); }
		}

		public void NextTurn (List<GameObject> units) {
			StartTurn(units);
		}

		private IEnumerator NextAction () {
			if (currentActionIndex >= actions.Count - 1) {
				EndTurn();
				yield break;
			}

			var action = actions[currentActionIndex];

			if (OnNPCActionStarted == null) {
				throw new UnityException("OnNPCActionStarted handler missing.");
			}
			if (OnPCActionStarted == null) {
				throw new UnityException("OnPCActionStarted handler missing.");
			}

			if (action.isNPC) {
				yield return OnNPCActionStarted(action.unit);
			} else {
				yield return OnPCActionStarted(action.unit, action.player);
			}

			currentActionIndex += 1;

			yield return NextAction();
		}

	}

}
