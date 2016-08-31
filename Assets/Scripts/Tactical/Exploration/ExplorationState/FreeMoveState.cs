using UnityEngine;
using System.Collections;
using Tactical.Exploration.ExplorationState;
using Tactical.Core.EventArgs;
using Tactical.Grid.Model;
using Tactical.Actor.Component;

namespace Tactical.Exploration.ExplorationState {

	public class FreeMoveState : ExplorationState {

		public override void Enter () {
			base.Enter();

			StartCoroutine("Init");
		}

		private IEnumerator Init () {
			yield return null;
		}

		protected override void OnMove (object sender, InfoEventArgs<Point> e) {
			// Get the player tile and reset the prev tile to make sure the movement
			// starts from the current position.
			var playerTile = player.tile;
			playerTile.prev = null;

			// Set the destination tile and set the prev tile to the current
			// player tile to start the movement from there.
			var destinationTile = board.GetTile(playerTile.pos + e.info);

			if (destinationTile) {
				destinationTile.prev = playerTile;
				owner.destinationTile = destinationTile;
				owner.ChangeState<MoveSequenceState>();
			}
		}

	}

	public class MoveSequenceState : ExplorationState {

		public override void Enter () {
			base.Enter();

			StartCoroutine("Sequence");
		}

		private IEnumerator Sequence () {
			var m = player.GetComponent<Movement>();
			m.timeScale = owner.timeController.scale;

			yield return StartCoroutine(m.Traverse(owner.destinationTile));

			owner.ChangeState<FreeMoveState>();
		}

	}

}
