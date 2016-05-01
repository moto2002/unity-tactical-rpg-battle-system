using UnityEngine;
using System.Collections.Generic;
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
		public ActionMenuPanelController actionMenuPanelController {
			get { return owner.actionMenuPanelController; }
		}
		public StatPanelController statPanelController {
			get { return owner.statPanelController; }
		}
		public Turn turn {
			get { return owner.turn; }
		}
		public List<Unit> units {
			get { return owner.units; }
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
			tileSelectionIndicator.localPosition = board.tiles[p].center;
		}

		protected virtual Unit GetUnit (Point p) {
			Tile t = board.GetTile(p);
			GameObject content = t != null ? t.content : null;
			return content != null ? content.GetComponent<Unit>() : null;
		}

		protected virtual void RefreshPrimaryStatPanel (Point p) {
			var target = GetUnit(p);
			if (target != null) {
				statPanelController.ShowPrimary(target.gameObject);
			} else {
				statPanelController.HidePrimary();
			}
		}

		protected virtual void RefreshSecondaryStatPanel (Point p) {
			var target = GetUnit(p);
			if (target != null) {
				statPanelController.ShowSecondary(target.gameObject);
			} else {
				statPanelController.HideSecondary();
			}
		}

	}

}
