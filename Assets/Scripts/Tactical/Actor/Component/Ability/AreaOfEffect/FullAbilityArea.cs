using UnityEngine;
using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
using Tactical.Battle.Component;

namespace Tactical.Actor.Component {

	public class FullAbilityArea : AbilityArea {

		public override List<Tile> GetTilesInArea (Board board, Point pos) {
			AbilityRange ar = GetComponent<AbilityRange>();
			return ar.GetTilesInRange(board);
		}

	}

}
