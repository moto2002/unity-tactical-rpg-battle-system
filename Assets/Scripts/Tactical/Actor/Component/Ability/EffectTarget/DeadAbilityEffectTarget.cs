using Tactical.Core;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public class DeadAbilityEffectTarget : AbilityEffectTarget {

		public override bool IsTarget (Tile tile) {
			if (tile == null || tile.content == null) {
				return false;
			}

			Stats s = tile.content.GetComponent<Stats>();
			return s != null && s[StatType.HP] <= 0;
		}

	}

}
