using UnityEngine;
using Tactical.Core.Enums;

namespace Tactical.Actor.Component {

	public class HasteStatusEffect : StatusEffect {

		public float effectValue = 2f;

		private Stats myStats;

		private void OnEnable () {
			myStats = GetComponentInParent<Stats>();
			if (myStats) {
				this.AddObserver(OnCounterWillChange, Stats.WillChangeNotification(StatType.CTR), myStats);
			}
		}

		private void OnDisable () {
			this.RemoveObserver(OnCounterWillChange, Stats.WillChangeNotification(StatType.CTR), myStats);
		}

		private void OnCounterWillChange (object sender, object args) {
			var exc = args as ValueChangeException;
			var m = new MultiplyDeltaModifier(0, effectValue);
			exc.AddModifier(m);
		}

	}

}
