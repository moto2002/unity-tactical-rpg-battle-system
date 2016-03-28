using UnityEngine;
using UnityEditor;
using Tactical.Core;
using Tactical.Battle;

namespace Tactical.Editor {

	public class BattleWindow : EditorWindow {

		private BattleManager battleManager;
		private TurnManager turnManager;

		[MenuItem("Window/Tactical/Battle")]
    private static void ShowWindow () {
      EditorWindow.GetWindow(typeof(BattleWindow), false, "Battle");
    }

		private void OnEnable () {
			PlayerInput.OnButton1Pressed += StartBattle;
		}

		private void OnDisable () {
			PlayerInput.OnButton1Pressed -= StartBattle;
		}

    private void OnInspectorUpdate () {
			UpdateManagers();
			Repaint();
    }

		private void OnGUI () {
			CreateBattleUI();
		}

		private void UpdateManagers () {
			if (
				GameManager.instance == null ||
				GameManager.instance.battleManager == null ||
				GameManager.instance.battleManager.turnManager == null
			) {
				return;
			}

			battleManager = GameManager.instance.battleManager;
			turnManager = GameManager.instance.battleManager.turnManager;
		}

		private void StartBattle () {
			if (battleManager != null) {
				battleManager.StartBattle();
			}
		}

		private void CreateBattleUI () {
			if (battleManager == null) {
				GUILayout.Label("BattleManager not initialized.");
				return;
			}
			if(turnManager == null) {
				GUILayout.Label("TurnManager not initialized.");
				return;
			}

			CreateBattleSection();
			if (battleManager.inProgress) {
				CreateTurnSection();
			}
		}

		private void CreateBattleSection () {
			GUILayout.Label("Battle");
			GUILayout.Label("Turns: " + battleManager.currentTurn + "/" + battleManager.maxTurns);
			CreateStartEndBattleButton();
		}

		private void CreateTurnSection () {
			GUILayout.Label("Turn #" + battleManager.currentTurn);
			CreateActionsList();
		}

		private void CreateActionsList () {
			for (var i = 0; i <= turnManager.actions.Count - 1; i++) {
				var isCurrent = turnManager.currentActionIndex == i;
				var isNPC = turnManager.actions[i].isNPC;

				GUILayout.BeginHorizontal();
				GUILayout.Toggle(isCurrent, string.Format(
					"Action #{0} ({1})", i,
					isNPC ? "NPC" : "PC"
				));

				if (isCurrent && !isNPC) {
					if (GUILayout.Button("End")) {
						PlayerActionManager.EndAction();
					}
				}
				GUILayout.EndHorizontal();
			}
		}

		private void CreateStartEndBattleButton () {
			var text = battleManager.inProgress ? "Stop" : "Start";

			if (GUILayout.Button(text)) {
				if (battleManager.inProgress) {
					battleManager.StopBattle();
				} else {
					battleManager.StartBattle();
				}
			}
		}

	}

}
