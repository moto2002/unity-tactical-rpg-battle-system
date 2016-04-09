using UnityEngine;
using Tactical.Core.StateMachine;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
using Tactical.Unit.Component;
using Tactical.Battle.Component;
using Tactical.Battle.BattleState;

namespace Tactical.Battle.Controller {

	public class BattleController : StateMachine {

		public CameraRig cameraRig;
		public Board board;
		public LevelData levelData;
		public Transform tileSelectionIndicator;
		public Point pos;
		public GameObject heroPrefab;
		public UnitCore currentUnit;
		public Tile currentTile { get { return board.GetTile(pos); }}

		private void Start () {
			ChangeState<InitBattleState>();
		}
	}

}
