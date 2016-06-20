using UnityEngine;
using System.Collections.Generic;
using Tactical.Core.Enums;
using Tactical.Actor.Component;
using Tactical.Actor.Component.AI;
using Tactical.Battle.Controller;
using Tactical.Grid.Component;

namespace Tactical.Actor.Controller {

	public class ComputerPlayerController : MonoBehaviour {

		private BattleController bc;
		private Unit actor {
			get {
				return bc.turn.actor;
			}
		}

		private void Awake () {
			bc = GetComponent<BattleController>();
		}

		public PlanOfAttack Evaluate () {
			// Create and fill out a plan of attack
			var poa = new PlanOfAttack();

			// Step 1: Decide what ability to use
			AttackPattern pattern = actor.GetComponentInChildren<AttackPattern>();
			if (pattern) {
				pattern.Pick(poa);
			} else {
				// TODO: Remove default pattern and throw instead?
				DefaultAttackPattern(poa);
			}

			// Step 2: Determine where to move and aim to best use the ability
			PlaceholderCode(poa);

			// Return the completed plan
			return poa;
		}

		private void DefaultAttackPattern (PlanOfAttack poa) {
			// Just get the first "Attack" ability
			poa.ability = actor.GetComponentInChildren<Ability>();
			poa.target = Targets.Foe;
		}

		// TODO: Replace this with real code based on some sort of AI.
		private void PlaceholderCode (PlanOfAttack poa) {
			// Move to a random location within the unit's move range
			List<Tile> tiles = actor.GetComponent<Movement>().GetTilesInRange(bc.board);
			Tile randomTile = (tiles.Count > 0) ? tiles[ Random.Range(0, tiles.Count) ] : null;
			poa.moveLocation = (randomTile != null) ? randomTile.pos : actor.tile.pos;

			// Pick a random attack direction (for direction based abilities)
			poa.attackDirection = (Directions)Random.Range(0, 4);

			// Pick a random fire location based on having moved to the random tile
			Tile start = actor.tile;
			actor.Place(randomTile);
			tiles = poa.ability.GetComponent<AbilityRange>().GetTilesInRange(bc.board);
			if (tiles.Count == 0) {
				poa.ability = null;
				poa.fireLocation = poa.moveLocation;
			} else {
				randomTile = tiles[ Random.Range(0, tiles.Count) ];
				poa.fireLocation = randomTile.pos;
			}
			actor.Place(start);
		}

		// TODO: Replace this with real code based on some sort of AI.
		public Directions DetermineEndFacingDirection () {
			return (Directions) Random.Range(0, 4);
		}

	}

}
