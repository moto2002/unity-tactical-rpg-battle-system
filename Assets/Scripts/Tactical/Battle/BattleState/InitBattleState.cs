using UnityEngine;
using System.Collections;
using Tactical.Core;
using Tactical.Actor.Component;
using Tactical.Grid.Model;
using Tactical.Battle.Controller;

namespace Tactical.Battle.BattleState {

	public class InitBattleState : BattleState {

		public override void Enter () {
			base.Enter();
			StartCoroutine("Init");
		}

		private IEnumerator Init () {
			// Load the board.
			board.Load(levelData);

			// Select the tile at [0,0].
			var p = new Point((int)levelData.tiles[0].x, (int)levelData.tiles[0].z);
			SelectTile(p);

			// Spawn test units.
			// TODO: Use a real system to spawn units depending on the situation.
			SpawnTestUnits();
			yield return null;
			owner.round = owner.gameObject.AddComponent<TurnOrderController>().Round();

			// Load the Cut scene state.
			owner.ChangeState<CutSceneState>();
		}

		private void SpawnTestUnits () {
			string[] jobs = {"Rogue", "Warrior", "Wizard"};
			for (int i = 0; i < jobs.Length; ++i) {
				var instance = Instantiate(owner.heroPrefab);

				Stats s = instance.AddComponent<Stats>();
				s[StatType.LVL] = 1;

				GameObject jobPrefab = Resources.Load<GameObject>( "Jobs/" + jobs[i] );
				var jobInstance = Instantiate(jobPrefab);
				jobInstance.transform.SetParent(instance.transform);

				Job job = jobInstance.GetComponent<Job>();
				job.Employ();
				job.LoadDefaultStats();
				instance.name = string.Format("Character #{0}", i+1);
				instance.transform.parent = owner.board.unitsContainer;

				var p = new Point((int)levelData.tiles[i].x, (int)levelData.tiles[i].z);

				Unit unit = instance.GetComponent<Unit>();
				unit.Place(board.GetTile(p));
				unit.Match();

				instance.AddComponent<WalkMovement>();

				units.Add(unit);

				ExperienceRank rank = instance.AddComponent<ExperienceRank>();
				rank.Init(10);
			}
		}
	}

}
