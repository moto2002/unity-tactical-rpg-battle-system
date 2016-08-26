using UnityEngine;
using System.Collections.Generic;
using Tactical.Core.Enums;
using Tactical.Core.EventArgs;
using Tactical.Core.StateMachine;
using Tactical.Core.Controller;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
using Tactical.Actor.Component;
using Tactical.Battle.Model;
using Tactical.Battle.Controller;
using Tactical.Battle.Component;
using Tactical.UI.Controller;

namespace Tactical.Battle.ExplorationState {

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
		public Transform tileSelectionIndicator {
			get { return owner.tileSelectionIndicator; }
		}
		public Point pos {
			get { return owner.pos; }
			set { owner.pos = value; }
		}

		protected BattleController owner;
		protected Driver driver;

		protected virtual void Awake () {
			owner = GetComponent<BattleController>();
		}

		public override void Enter () {
			base.Enter();
		}

		// protected override void AddListeners () {
		// 	InputController.moveEvent += OnMove;
		// 	InputController.fireEvent += OnFire;
		// }

		// protected override void RemoveListeners () {
		// 	InputController.moveEvent -= OnMove;
		// 	InputController.fireEvent -= OnFire;
		// }

		protected virtual void OnMove (object sender, InfoEventArgs<Point> e) {

		}

		protected virtual void OnFire (object sender, InfoEventArgs<int> e) {

		}

	}

}
