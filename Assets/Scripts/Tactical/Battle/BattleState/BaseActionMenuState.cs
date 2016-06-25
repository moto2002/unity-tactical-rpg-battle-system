using System.Collections.Generic;
using Tactical.Core.Enums;
using Tactical.Core.EventArgs;
using Tactical.Grid.Model;

namespace Tactical.Battle.BattleState {

	public abstract class BaseActionMenuState : BattleState {

		/// <summary>
		/// The title of the menu.
		/// </summary>
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

		/// <summary>
		/// Called when the owner is controlled by a player to initialize the menu.
		/// </summary>
		protected abstract void LoadMenu ();
		/// <summary>
		/// Called when the player select a menu item.
		/// </summary>
		protected abstract void Confirm ();
		/// <summary>
		/// Called when the player cancels.
		/// </summary>
		protected abstract void Cancel ();

	}

}
