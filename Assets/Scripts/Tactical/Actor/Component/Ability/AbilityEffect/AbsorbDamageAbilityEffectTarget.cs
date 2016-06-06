using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public class AbsorbDamageAbilityEffectTarget : BaseAbilityEffect {

		public int trackedSiblingIndex;
		private BaseAbilityEffect effect;
		private int amount;

		private void Awake () {
			effect = GetTrackedEffect();
		}

		private void OnEnable () {
			this.AddObserver(OnEffectHit, BaseAbilityEffect.HitNotification, effect);
			this.AddObserver(OnEffectMiss, BaseAbilityEffect.MissedNotification, effect);
		}

		private void OnDisable () {
			this.RemoveObserver(OnEffectHit, BaseAbilityEffect.HitNotification, effect);
			this.RemoveObserver(OnEffectMiss, BaseAbilityEffect.MissedNotification, effect);
		}

		public override int Predict (Tile target) {
			return 0;
		}

		protected override int OnApply (Tile target) {
			Stats s = GetComponentInParent<Stats>();
			s[StatType.HP] += amount;
			return amount;
		}

		private void OnEffectHit (object sender, object args) {
			amount = (int) args;
		}

		private void OnEffectMiss (object sender, object args) {
			amount = 0;
		}

		private BaseAbilityEffect GetTrackedEffect () {
			Transform owner = GetComponentInParent<Ability>().transform;
			if (trackedSiblingIndex >= 0 && trackedSiblingIndex < owner.childCount) {
				Transform sibling = owner.GetChild(trackedSiblingIndex);
				return sibling.GetComponent<BaseAbilityEffect>();
			}
			return null;
		}

	}

}
