using UnityEngine;
using Tactical.Grid.Model;
using Tactical.Unit.Component;
using Tactical.Core.EventArgs;

namespace Tactical.Battle.BattleState {

	public class ExploreState : BattleState {

		protected override void OnMove (object sender, InfoEventArgs<Point> e) {
			SelectTile(e.info + pos);
		}

		protected override void OnFire (object sender, InfoEventArgs<int> e) {
			if (e.info == 0) {
				owner.ChangeState<CommandSelectionState>();
			}
		}
	}

}
