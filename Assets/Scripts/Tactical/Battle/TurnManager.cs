using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tactical.Unit;

namespace Tactical.Battle {

	public class TurnManager : MonoBehaviour {

		public List<TurnAction> actions = new List<TurnAction>();
		public int currentActionIndex;

		public delegate void TurnStartedAction();
		public static event TurnStartedAction OnTurnStarted;

		public delegate void TurnEndedAction();
		public static event TurnEndedAction OnTurnEnded;

		public delegate void PlayerActionStartedAction(GameObject unit, PlayerControllable.Player player);
		public static event PlayerActionStartedAction OnPlayerActionStarted;

		public delegate IEnumerator NPCActionStartedAction(GameObject unit);
		public static event NPCActionStartedAction OnNPCActionStarted;

		public bool CurrentActionIsPlayer () {
			return !actions[currentActionIndex].isNPC;
		}

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
			StartCoroutine(StartAction(0));
		}

		public void EndTurn () {
			if (OnTurnEnded != null) { OnTurnEnded(); }
			currentActionIndex = 0;
		}

		public void NextTurn (List<GameObject> units) {
			StartTurn(units);
		}

		private void OnEnable () {
			PlayerActionManager.OnActionEnded += EndCurrentAction;
		}

		private void OnDisable () {
			PlayerActionManager.OnActionEnded -= EndCurrentAction;
		}

		private void Update () {

		}

		private void PrepareActions (List<GameObject> units) {
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

		private IEnumerator StartAction (int actionIndex) {
			if (actionIndex >= actions.Count) {
				EndTurn();
				yield break;
			}

			var action = actions[actionIndex];

			if (OnNPCActionStarted == null) {
				throw new UnityException("OnNPCActionStarted handler missing.");
			}
			if (OnPlayerActionStarted == null) {
				throw new UnityException("OnPlayerActionStarted handler missing.");
			}

			if (action.isNPC) {
				// TODO: Convert OnNPCActionStarted to be a void method like OnPlayerActionStarted
				yield return OnNPCActionStarted(action.unit);
			} else {
				OnPlayerActionStarted(action.unit, action.player);
				// TODO: Send an event to start the player action (UI, etc).
				yield break;
			}

			yield return NextAction();
		}

		private IEnumerator NextAction () {
			currentActionIndex += 1;
			yield return StartAction(currentActionIndex);
		}

		private void EndCurrentAction () {
			StartCoroutine(NextAction());
		}

	}

}
