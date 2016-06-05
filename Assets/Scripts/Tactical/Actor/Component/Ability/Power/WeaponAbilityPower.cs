using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Core.Component;
using Tactical.Item.Component;

namespace Tactical.Actor.Component {

	public class WeaponAbilityPower : BaseAbilityPower {

		protected override int GetBaseAttack () {
			return GetComponentInParent<Stats>()[StatType.ATK];
		}

		protected override int GetBaseDefense (Unit target) {
			return target.GetComponent<Stats>()[StatType.DEF];
		}

		protected override int GetPower () {
			int power = PowerFromEquippedWeapon();
			return power > 0 ? power : UnarmedPower();
		}

		private int PowerFromEquippedWeapon () {
			int power = 0;
			Equipment eq = GetComponentInParent<Equipment>();
			Equippable item = eq.GetItem(EquipSlots.Primary);
			StatModifierFeature[] features = item.GetComponentsInChildren<StatModifierFeature>();

			for (int i = 0; i < features.Length; ++i) {
				if (features[i].type == StatType.ATK) {
					power += features[i].amount;
				}
			}

			return power;
		}

		private int UnarmedPower () {
			Job job = GetComponentInParent<Job>();
			for (int i = 0; i < Job.statOrder.Length; ++i) {
				if (Job.statOrder[i] == StatType.ATK) {
					return job.baseStats[i];
				}
			}
			return 0;
		}

	}

}
