using System.Collections.Generic;
using Tactical.Core.Enums;
using Tactical.Core.EventArgs;
using Tactical.Grid.Model;

namespace Tactical.Battle.BattleState {

	public abstract class BaseActionMenuState : BattleState {

		protected string menuTitle;
		protected List<string> menuOptions;

		public override void Enter () {
			base.Enter();
			SelectTile(turn.actor.tile.pos);

			if (driver.Current == Drivers.Human) {
				LoadMenu();
			}
		}

		public override void Exit () {
			base.Exit();
			actionMenuPanelController.Hide();
		}

		protected override void OnFire (object sender, InfoEventArgs<int> e) {
			if (e.info == 0) {
				Confirm();
			} else {
				Cancel();
			}
		}

		protected override void OnMove (object sender, InfoEventArgs<Point> e) {
			if (e.info.x > 0 || e.info.y < 0) {
				actionMenuPanelController.Next();
			} else {
				actionMenuPanelController.Previous();
			}
		}

		protected abstract void LoadMenu ();
		protected abstract void Confirm ();
		protected abstract void Cancel ();

	}

}
