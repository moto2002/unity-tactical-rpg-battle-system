using System.Collections.Generic;

namespace Tactical.Battle.BattleState {

	public class ActionSelectionState : BaseActionMenuState {

		public static int category;
		string[] whiteMagicOptions = { "Cure", "Raise", "Holy" };
		string[] blackMagicOptions = { "Fire", "Ice", "Lightning" };

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
				menuOptions = new List<string>(3);
			}

			if (category == 0) {
				menuTitle = "White Magic";
				SetOptions(whiteMagicOptions);
			} else {
				menuTitle = "Black Magic";
				SetOptions(blackMagicOptions);
			}

			actionMenuPanelController.Show(menuTitle, menuOptions);
		}

		protected override void Confirm () {
			turn.hasUnitActed = true;
			if (turn.hasUnitMoved) {
				turn.lockMove = true;
			}
			owner.ChangeState<CommandSelectionState>();
		}

		protected override void Cancel () {
			owner.ChangeState<CommandCategorySelectionState>();
		}

		void SetOptions (string[] options) {
			menuOptions.Clear();
			for (int i = 0; i < options.Length; ++i) {
				menuOptions.Add(options[i]);
			}
		}

	}

}
