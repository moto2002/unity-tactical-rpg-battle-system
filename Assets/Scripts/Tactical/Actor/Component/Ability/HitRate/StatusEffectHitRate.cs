using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Core.Extensions;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public class StatusEffectHitRate : HitRate {

		public override int Calculate (Tile target) {
			Unit defender = target.content.GetComponent<Unit>();
			if (AutomaticMiss(defender)) {
				return Final(100);
			}

			if (AutomaticHit(defender)) {
				return Final(0);
			}

			int res = GetResistance(defender);
			res = AdjustForStatusEffects(defender, res);
			res = AdjustForRelativeFacing(defender, res);
			res = Mathf.Clamp(res, 0, 100);
			return Final(res);
		}

		private int GetResistance (Unit target) {
			Stats s = target.GetComponentInParent<Stats>();
			return s[StatType.RES];
		}

		private int AdjustForRelativeFacing (Unit target, int rate) {
			switch (attacker.GetFacing(target)) {
			case Facing.Front:
				return rate;
			case Facing.Side:
				return rate - 10;
			default:
				return rate - 20;
			}
		}

	}

}
