using UnityEngine;
using UnityEngine.UI;
using Tactical.Battle;
using Tactical.Unit;

namespace Tactical.UI {

	[DisallowMultipleComponent]
	[RequireComponent (typeof (Canvas))]
	public class ActionMenuController : MonoBehaviour {

		public bool visible;

		private Canvas canvas;
		public Button[] buttons;

		private void OnEnable () {
			TurnManager.OnPlayerActionStarted += ShowMenu;
			PlayerTurnAction.OnMovementStarted += HideMenu;
		}

		private void OnDisable () {
			TurnManager.OnPlayerActionStarted -= ShowMenu;
			PlayerTurnAction.OnMovementStarted -= HideMenu;
		}

		private void Start () {
			canvas = gameObject.GetComponent<Canvas>();
			buttons = transform.GetComponentsInChildren<Button>();
		}

		private void Update () {
			UpdateVisibility();
		}

		private void ShowMenu (GameObject unit, PlayerControllable.Player player) {
			visible = true;
		}

		private void HideMenu () {
			visible = false;
		}

		private void UpdateVisibility () {
			canvas.enabled = visible;
		}

	}

}
