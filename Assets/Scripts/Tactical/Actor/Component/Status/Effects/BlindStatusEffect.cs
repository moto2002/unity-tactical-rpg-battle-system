using UnityEngine;
using Tactical.Actor.Component;
using Tactical.Actor.Model;

namespace Tactical.Actor.Component {

	public class BlindStatusEffect : StatusEffect {

		private void OnEnable () {
			this.AddObserver( OnHitRateStatusCheck, HitRate.StatusCheckNotification );
		}

		private void OnDisable () {
			this.RemoveObserver( OnHitRateStatusCheck, HitRate.StatusCheckNotification );
		}

		private void OnHitRateStatusCheck (object sender, object args) {
			var info = args as HitRateInfo;
			Unit owner = GetComponentInParent<Unit>();
			if (owner == info.attacker) {
				// The attacker is blind
				info.rate += 50;
			} else if (owner == info.target) {
				// The defender is blind
				info.rate -= 20;
			}
		}

	}

}
