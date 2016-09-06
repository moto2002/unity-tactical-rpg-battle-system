using UnityEngine;
using System.Collections;
using Tactical.Exploration.ExplorationState;
using Tactical.Core.EventArgs;
using Tactical.Grid.Model;
using Tactical.Actor.Component;

namespace Tactical.Exploration.ExplorationState {

	public class FreeMoveState : ExplorationState {

		private FreeMovement movement;

		public override void Enter () {
			base.Enter();

			StartCoroutine("Init");
		}

		private IEnumerator Init () {
			movement = player.GetComponent<FreeMovement>();

			yield return null;
		}

		protected override void OnMove (object sender, InfoEventArgs<Vector2> e) {
			if (movement == null) { return; }

			movement.MoveHorizontally(e.info);
		}

		protected override void OnJump (object sender, InfoEventArgs<float> e) {
			if (movement == null) { return; }

			movement.Jump();
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
