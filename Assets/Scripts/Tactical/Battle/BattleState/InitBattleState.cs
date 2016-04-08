using UnityEngine;
using System.Collections;
using Tactical.Grid.Model;
using Tactical.Unit.Component;

namespace Tactical.Battle.BattleState {

	public class InitBattleState : BattleState {

		public override void Enter () {
			base.Enter();
			StartCoroutine(Init());
		}

		private IEnumerator Init () {
			board.Load(levelData);
			var p = new Point((int)levelData.tiles[0].x, (int)levelData.tiles[0].z);
			SelectTile(p);
			SpawnTestUnits();
			yield return null;
			owner.ChangeState<SelectUnitState>();
		}

		private void SpawnTestUnits () {
			var components = new System.Type[] { typeof(WalkMovement), typeof(FlyMovement), typeof(TeleportMovement) };
			for (int i = 0; i < 3; ++i) {
				var instance = Instantiate(owner.heroPrefab) as GameObject;
				instance.transform.parent = transform;

				var p = new Point((int)levelData.tiles[i].x, (int)levelData.tiles[i].z);

				var unit = instance.GetComponent<UnitCore>();
				unit.Place(board.GetTile(p));
				unit.Match();

        Movement m = instance.AddComponent(components[i]) as Movement;
        m.range = 5;
        m.jumpHeight = 2;
			}
		}
	}

}
