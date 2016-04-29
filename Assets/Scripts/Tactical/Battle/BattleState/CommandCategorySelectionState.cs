using System.Collections.Generic;

namespace Tactical.Battle.BattleState {

	public class CommandCategorySelectionState : BaseActionMenuState {

		public override void Enter () {
			base.Enter();
			statPanelController.ShowPrimary(turn.actor.gameObject);
		}

		public override void Exit () {
			base.Exit();
			statPanelController.HidePrimary();
		}

		protected override void LoadMenu () {
			if (menuOptions == null) {
				menuTitle = "Action";
				menuOptions = new List<string>(3);
				menuOptions.Add("Attack");
				menuOptions.Add("White Magic");
				menuOptions.Add("Black Magic");
			}

			actionMenuPanelController.Show(menuTitle, menuOptions);
		}

		protected override void Confirm () {
			switch (actionMenuPanelController.selection) {
			case 0:
				Attack();
				break;
			case 1:
				SetCategory(0);
				break;
			case 2:
				SetCategory(1);
				break;
			}
		}

		protected override void Cancel () {
			owner.ChangeState<CommandSelectionState>();
		}

		void Attack () {
			turn.hasUnitActed = true;
			if (turn.hasUnitMoved) {
				turn.lockMove = true;
			}
			owner.ChangeState<CommandSelectionState>();
		}

		void SetCategory (int index) {
			ActionSelectionState.category = index;
			owner.ChangeState<ActionSelectionState>();
		}

	}

}
