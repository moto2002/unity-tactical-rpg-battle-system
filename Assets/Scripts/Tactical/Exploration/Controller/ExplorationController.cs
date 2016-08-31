using UnityEngine;
using System.Collections.Generic;
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
		// public List<Unit> units = new List<Unit>();
		public TimeController timeController;
		public Tile destinationTile;
		public Unit player;
		// public Tile playerTile;

		private void Start () {
			ChangeState<InitExplorationState>();
		}

	}

}
