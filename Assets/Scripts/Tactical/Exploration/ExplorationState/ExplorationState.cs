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
			ExplorationInputController.MoveEvent += OnMove;
			ExplorationInputController.JumpEvent += OnJump;
		}

		protected override void RemoveListeners () {
			ExplorationInputController.MoveEvent -= OnMove;
			ExplorationInputController.JumpEvent -= OnJump;
		}

		protected virtual void OnMove (object sender, InfoEventArgs<Vector2> e) {}

		protected virtual void OnJump (object sender, InfoEventArgs<float> e) {}

	}

}
