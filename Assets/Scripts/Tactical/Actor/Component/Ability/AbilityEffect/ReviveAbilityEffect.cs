using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public class ReviveAbilityEffect : BaseAbilityEffect {

		[Range(0,100)]
		public int percent;

		public override int Predict (Tile target) {
			Stats s = target.content.GetComponent<Stats>();
			return Mathf.FloorToInt(s[StatTypes.MHP] * percent / 100);
		}

		protected override int OnApply (Tile target) {
			Stats s = target.content.GetComponent<Stats>();
			int value = s[StatTypes.HP] = Predict(target);
			return value;
		}

	}

}
