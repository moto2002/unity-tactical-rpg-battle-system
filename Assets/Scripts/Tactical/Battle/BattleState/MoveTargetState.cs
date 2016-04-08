using UnityEngine;
using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
using Tactical.Unit.Component;
using Tactical.Core.EventArgs;

namespace Tactical.Battle.BattleState {

	public class MoveTargetState : BattleState {

		private List<Tile> tiles;

		public override void Enter () {
			base.Enter();
			Movement mover = owner.currentUnit.GetComponent<Movement>();
			tiles = mover.GetTilesInRange(board);
			board.SelectTiles(tiles);
		}

		public override void Exit () {
			base.Exit();
			board.DeSelectTiles(tiles);
			tiles = null;
		}

		protected override void OnMove (object sender, InfoEventArgs<Point> e) {
			SelectTile(e.info + pos);
		}

		protected override void OnFire (object sender, InfoEventArgs<int> e) {
			if (tiles.Contains(owner.currentTile)) {
				owner.ChangeState<MoveSequenceState>();
			} else {
				Debug.Log(string.Format("Out of range"));
			}
		}

	}

}

