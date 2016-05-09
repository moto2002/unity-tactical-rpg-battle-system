using UnityEngine;
using Tactical.Core;

namespace Tactical.Actor.Component {

	public class StopStatusEffect : StatusEffect {

		private Stats myStats;

		private void OnEnable () {
			myStats = GetComponentInParent<Stats>();
			if (myStats) {
				this.AddObserver( OnCounterWillChange, Stats.WillChangeNotification(StatType.CTR), myStats );
			}
		}

		private void OnDisable () {
			this.RemoveObserver( OnCounterWillChange, Stats.WillChangeNotification(StatType.CTR), myStats );
		}

		private void OnCounterWillChange (object sender, object args) {
			var exc = args as ValueChangeException;
			exc.FlipToggle();
		}

	}

}
