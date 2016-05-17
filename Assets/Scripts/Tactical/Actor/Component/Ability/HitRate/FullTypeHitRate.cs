using UnityEngine;

namespace Tactical.Actor.Component {

	public class FullHitRate : HitRate {

		public override int Calculate (Unit attacker, Unit target) {
			if (AutomaticMiss(attacker, target)) {
				return Final(100);
			}

			return Final(0);
		}

	}

}
