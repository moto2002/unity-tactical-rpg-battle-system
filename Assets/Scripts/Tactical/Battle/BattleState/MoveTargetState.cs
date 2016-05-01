using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
using Tactical.Actor.Component;
using Tactical.Core.EventArgs;

namespace Tactical.Battle.BattleState {

	public class MoveTargetState : BattleState {

		private List<Tile> tiles;

		public override void Enter () {
			base.Enter();
			Movement mover = owner.turn.actor.GetComponent<Movement>();
			tiles = mover.GetTilesInRange(board);
			board.SelectTiles(tiles);
			RefreshPrimaryStatPanel(pos);
		}

		public override void Exit () {
			base.Exit();
			board.DeSelectTiles(tiles);
			tiles = null;
			statPanelController.HidePrimary();
		}

		protected override void OnMove (object sender, InfoEventArgs<Point> e) {
			SelectTile(e.info + pos);
			RefreshPrimaryStatPanel(pos);
		}

		protected override void OnFire (object sender, InfoEventArgs<int> e) {
			if (e.info == 0) {
				if (tiles.Contains(owner.currentTile)) {
					owner.ChangeState<MoveSequenceState>();
				}
			} else {
				owner.ChangeState<CommandSelectionState>();
			}
		}
	}

}

