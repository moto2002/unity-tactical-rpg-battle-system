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

			Debug.Log("Battle [start]");
			turnManager.StartTurn(unitManager.units);
		}

		public void StopBattle () {
			inProgress = false;
			currentTurn = 0;

			Debug.Log("Battle [end]");
		}

		private void OnEnable () {
			TurnManager.OnTurnStarted += HandleTurnStarted;
			TurnManager.OnTurnEnded += HandleTurnEnded;
			TurnManager.OnPCActionStarted += HandlePCActionStarted;
		}

		private void OnDisable () {
			TurnManager.OnTurnStarted -= HandleTurnStarted;
			TurnManager.OnTurnEnded -= HandleTurnEnded;
			TurnManager.OnPCActionStarted -= HandlePCActionStarted;
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

		private IEnumerator HandlePCActionStarted (GameObject unit, PlayerControllable.Player player) {
			// TODO: Pass the control to the player.
			Debug.Log(string.Format("{0} action [start]", player));
      yield return new WaitForSeconds(1f);
			unit.GetComponent<UnitMovement>().Move(
        new Vector3(Mathf.Floor(Random.Range(0f, 4f)), 0, Mathf.Floor(Random.Range(0f, 4f)))
      );
      Debug.Log(string.Format("{0} action [end]", player));
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
			}
		}
	}

}
