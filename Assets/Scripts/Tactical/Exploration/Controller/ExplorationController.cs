using UnityEngine;
using System;
using System.Collections.Generic;
using Tactical.Core.Component;
using Tactical.Core.StateMachine;
using Tactical.Core.Controller;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
using Tactical.Actor.Component;
using Tactical.Battle.Component;
using Tactical.Exploration.ExplorationState;

namespace Tactical.Exploration.Controller {

	public class ExplorationController : StateMachine {

		public CameraRig cameraRig;
		public Board board;
		public LevelData levelData;
		public GameObject heroPrefab;
		public TimeController timeController;
		public Tile destinationTile;
		public Unit player;

		private void Start () {
			ChangeState<InitExplorationState>();
		}

		private void OnEnable () {
			this.AddObserver(OnStateChangeTriggered, StateTrigger.StateChangeTriggered);
		}

		private void OnDisable () {
			this.RemoveObserver(OnStateChangeTriggered, StateTrigger.StateChangeTriggered);
		}

		// TODO: Check the current state before changing state?
		// 			 Allow only some combinaisons/transitions maybe.
		private void OnStateChangeTriggered (object sender, object args) {
			var state = Type.GetType((string) args);

			if (state != null) {
				// TODO: Change the state using "state";
				// ChangeState<state>();
			} else {
				Debug.LogWarning("Invalid State: " + args);
			}
		}

	}

}
