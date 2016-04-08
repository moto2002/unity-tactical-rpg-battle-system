using UnityEngine;
using Tactical.Grid.Model;
using Tactical.Core.EventArgs;
using Tactical.Core.StateMachine;
using Tactical.Core.Controller;
using Tactical.Battle.Controller;
using Tactical.Battle.Component;

namespace Tactical.Battle.BattleState {

	public abstract class BattleState : State {

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

		protected virtual void Awake () {
			owner = GetComponent<BattleController>();
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

		protected virtual void SelectTile (Point p) {
			if (pos == p || !board.tiles.ContainsKey(p)) {
				return;
			}

			pos = p;
			tileSelectionIndicator.localPosition = board.tiles[p].center + new Vector3(0f, tileSelectionIndicator.lossyScale.y / 2f, 0f);
		}

	}

}
