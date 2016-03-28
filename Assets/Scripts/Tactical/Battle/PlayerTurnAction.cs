using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tactical.Unit;

namespace Tactical.Battle {

	public class PlayerTurnAction : MonoBehaviour {

		public delegate void MovementStartedAction();
		public static event MovementStartedAction OnMovementStarted;

		public void StartMovementPhase () {
			if (OnMovementStarted != null) {
				Debug.Log("StartMovementPhase");
				OnMovementStarted();
			}
		}

	}

}
