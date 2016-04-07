using UnityEngine;
using Tactical.Core.StateMachine;
using Tactical.Grid.Model;
using Tactical.Battle.Component;
using Tactical.Battle.BattleState;

namespace Tactical.Battle.Controller {

	public class BattleController : StateMachine {

		public CameraRig cameraRig;
		public Board board;
		public LevelData levelData;
		public Transform tileSelectionIndicator;
		public Point pos;

		private void Start () {
			ChangeState<InitBattleState>();
		}
	}

}
