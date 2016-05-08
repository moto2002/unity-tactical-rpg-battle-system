using UnityEngine;
using System.Collections.Generic;
using Tactical.Core;
using Tactical.Grid.Component;
using Tactical.Actor.Component;

namespace Tactical.Battle.Model {

	public class Turn {

		public Unit actor;
		public bool hasUnitMoved;
		public bool hasUnitActed;
		public bool lockMove;
		public GameObject ability;
		public List<Tile> targets;

		private Tile startTile;
		private Direction startDir;

		public void Change (Unit current) {
			actor = current;
			hasUnitMoved = false;
			hasUnitActed = false;
			lockMove = false;
			startTile = actor.tile;
			startDir = actor.dir;
		}

		public void UndoMove () {
			hasUnitMoved = false;
			actor.Place(startTile);
			actor.dir = startDir;
			actor.Match();
		}
	}

}
