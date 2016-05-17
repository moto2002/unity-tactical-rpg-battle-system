using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Core.Extensions;

namespace Tactical.Actor.Component {

	public class BasicAttackHitRate : HitRate {

		public override int Calculate (Unit attacker, Unit target) {
			if (AutomaticHit(attacker, target)) {
				return Final(0);
			}

			if (AutomaticMiss(attacker, target)) {
				return Final(100);
			}

			int evade = GetEvade(target);
			evade = AdjustForRelativeFacing(attacker, target, evade);
			evade = AdjustForStatusEffects(attacker, target, evade);
			evade = Mathf.Clamp(evade, 5, 95);
			return Final(evade);
		}

		private int GetEvade (Unit target) {
			Stats s = target.GetComponentInParent<Stats>();
			return Mathf.Clamp(s[StatType.EVD], 0, 100);
		}

		private int AdjustForRelativeFacing (Unit attacker, Unit target, int rate) {
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
