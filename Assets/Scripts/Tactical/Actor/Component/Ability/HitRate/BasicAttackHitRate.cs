using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Core.Extensions;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public class BasicAttackHitRate : HitRate {

		public override int Calculate (Tile target) {
			Unit defender = target.content.GetComponent<Unit>();
			if (AutomaticHit(defender)) {
				return Final(0);
			}

			if (AutomaticMiss(defender)) {
				return Final(100);
			}

			int evade = GetEvade(defender);
			evade = AdjustForRelativeFacing(defender, evade);
			evade = AdjustForStatusEffects(defender, evade);
			evade = Mathf.Clamp(evade, 5, 95);
			return Final(evade);
		}

		private int GetEvade (Unit target) {
			Stats s = target.GetComponentInParent<Stats>();
			return Mathf.Clamp(s[StatType.EVD], 0, 100);
		}

		private int AdjustForRelativeFacing (Unit target, int rate) {
			switch (attacker.GetFacing(target)) {
			case Facing.Front:
				return rate;
			case Facing.Side:
				return rate / 2;
			default:
				return rate / 4;
			}
		}

	}

}
