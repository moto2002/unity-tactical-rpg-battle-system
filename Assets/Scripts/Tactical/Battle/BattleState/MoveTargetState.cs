using UnityEngine;
using Tactical.Grid.Model;
using Tactical.Core.EventArgs;

namespace Tactical.Battle.BattleState {

	public class MoveTargetState : BattleState {

		protected override void OnMove (object sender, InfoEventArgs<Point> e) {
			SelectTile(e.info + pos);
		}
	}

}

