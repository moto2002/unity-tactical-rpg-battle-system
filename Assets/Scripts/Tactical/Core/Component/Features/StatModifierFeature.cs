using UnityEngine;
using Tactical.Core;
using Tactical.Unit.Component;

namespace Tactical.Core.Component {

	public class StatModifierFeature : Feature {

		public StatType type;
		public int amount;

		private Stats stats {
			get {
				return _target.GetComponentInParent<Stats>();
			}
		}

		protected override void OnApply () {
			stats[type] += amount;
		}

		protected override void OnRemove () {
			stats[type] -= amount;
		}

	}

}
