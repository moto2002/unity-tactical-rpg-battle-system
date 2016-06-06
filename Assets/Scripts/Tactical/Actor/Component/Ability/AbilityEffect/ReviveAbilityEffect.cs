using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public abstract class ReviveAbilityEffect : BaseAbilityEffect {

		public float percent;

		public override int Predict (Tile target) {
			Stats s = target.content.GetComponent<Stats>();
			return Mathf.FloorToInt(s[StatType.MHP] * percent);
		}

		protected override int OnApply (Tile target) {
			Stats s = target.content.GetComponent<Stats>();
			int value = s[StatType.HP] = Predict(target);
			return value;
		}

	}

}
