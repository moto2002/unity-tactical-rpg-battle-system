using UnityEngine;
using System.Collections.Generic;
using Tactical.Core.EventArgs;
using Tactical.Core.StateMachine;
using Tactical.Core.Controller;
using Tactical.Grid.Model;
using Tactical.Actor.Component;
using Tactical.Battle.Component;
using Tactical.Exploration.Controller;

namespace Tactical.Exploration.ExplorationState {

	public abstract class ExplorationState : State {

		public CameraRig cameraRig {
			get { return owner.cameraRig; }
		}
		public Board board {
			get { return owner.board; }
		}
		public LevelData levelData {
			get { return owner.levelData; }
		}
		public Unit player {
			get { return owner.player; }
		}

		protected ExplorationController owner;

		protected virtual void Awake () {
			owner = GetComponent<ExplorationController>();
		}

		public override void Enter () {
			base.Enter();
		}

		protected override void AddListeners () {
			InputController.moveEvent += OnMove;
			InputController.fireEvent += OnFire;
		}

		protected override void RemoveListeners () {
			InputController.moveEvent -= OnMove;
			InputController.fireEvent -= OnFire;
		}

		protected virtual void OnMove (object sender, InfoEventArgs<Point> e) {

		}

		protected virtual void OnFire (object sender, InfoEventArgs<int> e) {

		}

	}

}
