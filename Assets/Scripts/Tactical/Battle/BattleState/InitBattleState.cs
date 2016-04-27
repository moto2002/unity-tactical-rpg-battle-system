using UnityEngine;
using System.Collections;
using Tactical.Core;
using Tactical.Actor.Component;
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
			owner.ChangeState<CutSceneState>();
		}

		private void SpawnTestUnits () {
			var jobs = new string[] {"Rogue", "Warrior", "Wizard"};
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

				var p = new Point((int)levelData.tiles[i].x, (int)levelData.tiles[i].z);

				UnitCore unit = instance.GetComponent<UnitCore>();
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
