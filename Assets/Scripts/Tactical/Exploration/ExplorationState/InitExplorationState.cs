using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tactical.Actor.Factory;
using Tactical.Grid.Component;
using Tactical.Actor.Component;
using Tactical.Core.Enums;
using Tactical.Exploration.ExplorationState;

namespace Tactical.Exploration.ExplorationState {

	public class InitExplorationState : ExplorationState {

		public override void Enter () {
			base.Enter();
			StartCoroutine("Init");
		}

		private IEnumerator Init () {
			// Load the board.
			board.Load(levelData);

			// Spawn test units.
			// TODO: Use a real system to spawn units depending on the situation.
			SpawnTestUnits();

			// Attach the camera to the player.
			cameraRig.follow = player.transform;

			yield return null;

			owner.ChangeState<FreeMoveState>();
		}

		private void SpawnTestUnits () {
			GameObject instance = UnitFactory.Create("Ramza", 1);
			instance.transform.parent = owner.board.unitsContainer;

			var locations = new List<Tile>(board.tiles.Values);
			int random = Random.Range(0, locations.Count);
			Tile randomTile = locations[random];

			Unit unit = instance.GetComponent<Unit>();
			unit.Place(randomTile);
			unit.dir = (Directions) Random.Range(0, 4);
			unit.Match();

			// Add a box collider to trigger the battle.
			instance.AddComponent<BoxCollider>();
			instance.GetComponent<BoxCollider>().isTrigger = true;
			// instance.AddComponent<Rigidbody>();
			// instance.GetComponent<Rigidbody>().isKinematic = true;

			// Tag the player.
			instance.tag = "Player";

			owner.player = unit;
		}

	}

}
