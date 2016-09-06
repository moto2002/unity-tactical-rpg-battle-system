using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tactical.Actor.Factory;
using Tactical.Grid.Component;
using Tactical.Actor.Component;
using Tactical.Core.Enums;
using Tactical.Exploration.ExplorationState;

namespace Tactical.Exploration.ExplorationState {

	public class InitExplorationState : ExplorationState {

		public override void Enter () {
			base.Enter();
			StartCoroutine("Init");
		}

		private IEnumerator Init () {
			// Attach the camera to the player.
			cameraRig.follow = player.transform;

			yield return null;

			owner.ChangeState<FreeMoveState>();
		}

	}

}
