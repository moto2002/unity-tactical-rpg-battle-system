using UnityEngine;
using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
using Tactical.Battle.Component;

namespace Tactical.Actor.Component {

	public abstract class AbilityArea : MonoBehaviour {

		public abstract List<Tile> GetTilesInArea (Board board, Point pos);

	}

}
