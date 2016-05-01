using Tactical.Core;
using Tactical.Grid.Component;
using Tactical.Actor.Component;

namespace Tactical.Battle.Model {

	public class Turn {

		public UnitCore actor;
		public bool hasUnitMoved;
		public bool hasUnitActed;
		public bool lockMove;

		private Tile startTile;
		private Direction startDir;

		public void Change (UnitCore current) {
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
