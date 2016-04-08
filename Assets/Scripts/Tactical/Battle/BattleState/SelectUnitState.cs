using UnityEngine;
using Tactical.Grid.Model;
using Tactical.Unit.Component;
using Tactical.Core.EventArgs;

namespace Tactical.Battle.BattleState {

	public class SelectUnitState : BattleState {

		protected override void OnMove (object sender, InfoEventArgs<Point> e) {
			SelectTile(e.info + pos);
		}

		protected override void OnFire (object sender, InfoEventArgs<int> e) {
			GameObject content = owner.currentTile.content;
			if (content != null) {
				owner.currentUnit = content.GetComponent<UnitCore>();
				owner.ChangeState<MoveTargetState>();
			}
		}

	}

}
