using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Core.Extensions;

namespace Tactical.Actor.Component {

	public class StatusEffectHitRate : HitRate {

		public override int Calculate (Unit attacker, Unit target) {
			if (AutomaticMiss(attacker, target)) {
				return Final(100);
			}

			if (AutomaticHit(attacker, target)) {
				return Final(0);
			}

			int res = GetResistance(target);
			res = AdjustForStatusEffects(attacker, target, res);
			res = AdjustForRelativeFacing(attacker, target, res);
			res = Mathf.Clamp(res, 0, 100);
			return Final(res);
		}

		private int GetResistance (Unit target) {
			Stats s = target.GetComponentInParent<Stats>();
			return s[StatType.RES];
		}

		private int AdjustForRelativeFacing (Unit attacker, Unit target, int rate) {
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
