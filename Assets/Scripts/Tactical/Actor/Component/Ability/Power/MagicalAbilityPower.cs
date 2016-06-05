using UnityEngine;
using Tactical.Core.Enums;

namespace Tactical.Actor.Component {

	public class MagicalAbilityPower : BaseAbilityPower {

		public int level;

		protected override int GetBaseAttack () {
			return GetComponentInParent<Stats>()[StatType.MAT];
		}

		protected override int GetBaseDefense (Unit target) {
			return target.GetComponent<Stats>()[StatType.MDF];
		}

		protected override int GetPower () {
			return level;
		}

	}

}
