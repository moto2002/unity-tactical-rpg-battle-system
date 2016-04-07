using UnityEngine;
using System.Collections;
using Tactical.Grid.Model;

namespace Tactical.Battle.BattleState {

	public class InitBattleState : BattleState {

		public override void Enter () {
			base.Enter();
			StartCoroutine(Init());
		}

		private IEnumerator Init () {
			board.Load(levelData);
			var p = new Point((int)levelData.tiles[0].x, (int)levelData.tiles[0].z);
			SelectTile(p);

			yield return null;

			owner.ChangeState<MoveTargetState>();
		}
	}

}
