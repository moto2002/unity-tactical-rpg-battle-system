using UnityEngine;
using System.Collections;
using Tactical.Unit;

namespace Tactical.Battle {

	public class BattleManager : MonoBehaviour {

		[HideInInspector] public TurnManager turnManager;
		[HideInInspector] public UnitManager unitManager;
		public bool inProgress;
		public bool playerTurnInProgress;
		public int currentTurn;
		public int maxTurns = 2;

		/// <summary>
		/// Prepare everything needed and starts the battle.
		/// </summary>
		///
		/// @todo: Pass the battle options here ?
		public void StartBattle () {
			if (turnManager == null) {
				Debug.LogError("TurnManager not initialized.");
				return;
			}

			if (unitManager == null) {
				Debug.LogError("TurnManager not initialized.");
				return;
			}

			// If the battle has already inProgress, do nothing.
			if (inProgress) { return; }

			inProgress = true;

			StartCoroutine(ShowBattleStatus("Battle start", 1f));

			turnManager.StartTurn(unitManager.units);
		}

		public void StopBattle () {
			inProgress = false;
			currentTurn = 0;

			StartCoroutine(ShowBattleStatus("Battle end", 1f));
		}

		private void OnEnable () {
			TurnManager.OnTurnStarted += HandleTurnStarted;
			TurnManager.OnTurnEnded += HandleTurnEnded;
		}

		private void OnDisable () {
			TurnManager.OnTurnStarted -= HandleTurnStarted;
			TurnManager.OnTurnEnded -= HandleTurnEnded;
		}

		private void Update () {
      // Get the turn manager.
			if (turnManager == null) {
				turnManager = GetComponent<TurnManager>();
			}

			// Get the unit manager.
			if (unitManager == null) {
				unitManager = GetComponent<UnitManager>();
			}
		}

		private IEnumerator ShowBattleStatus (string message, float duration) {
			UIManager.instance.battleStatus.visible = true;
			UIManager.instance.battleStatus.title = message;
			yield return new WaitForSeconds(duration);
			UIManager.instance.battleStatus.visible = false;
		}

		private void HandleTurnStarted () {
			currentTurn += 1;
			playerTurnInProgress = true;
			Debug.Log(string.Format("Turn #{0} [start]", currentTurn));
		}

		private void HandleTurnEnded () {
			Debug.Log(string.Format("Turn #{0} [end]", currentTurn));
			playerTurnInProgress = false;

			// TODO: Handle battle end conditions here.
			if (currentTurn >= maxTurns) {
				StopBattle();
			} else {
				turnManager.NextTurn(unitManager.units);
			}
		}
	}

}
