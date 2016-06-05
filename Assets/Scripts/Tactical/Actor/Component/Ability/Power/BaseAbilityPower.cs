using UnityEngine;
using Tactical.Actor.Model;

namespace Tactical.Actor.Component {

	public abstract class BaseAbilityPower : MonoBehaviour {

		protected abstract int GetBaseAttack ();
		protected abstract int GetBaseDefense (Unit target);
		protected abstract int GetPower ();

		private void OnEnable () {
			this.AddObserver(OnGetBaseAttack, DamageAbilityEffect.GetAttackNotification);
			this.AddObserver(OnGetBaseDefense, DamageAbilityEffect.GetDefenseNotification);
			this.AddObserver(OnGetPower, DamageAbilityEffect.GetPowerNotification);
		}

		private void OnDisable () {
			this.RemoveObserver(OnGetBaseAttack, DamageAbilityEffect.GetAttackNotification);
			this.RemoveObserver(OnGetBaseDefense, DamageAbilityEffect.GetDefenseNotification);
			this.RemoveObserver(OnGetPower, DamageAbilityEffect.GetPowerNotification);
		}

		private void OnGetBaseAttack (object sender, object args) {
			var info = args as AbilityPowerInfo;
			if (info == null || info.attacker != GetComponentInParent<Unit>()) {
				return;
			}

			var mod = new AddValueModifier(0, GetBaseAttack());
			info.mods.Add(mod);
		}

		private void OnGetBaseDefense (object sender, object args) {
			var info = args as AbilityPowerInfo;
			if (info == null || info.attacker != GetComponentInParent<Unit>()) {
				return;
			}

			var mod = new AddValueModifier(0, GetBaseDefense(info.target));
			info.mods.Add(mod);
		}

		private void OnGetPower (object sender, object args) {
			var info = args as AbilityPowerInfo;
			if (info == null || info.attacker != GetComponentInParent<Unit>()) {
				return;
			}

			var mod = new AddValueModifier(0, GetPower());
			info.mods.Add(mod);
		}

	}

}
