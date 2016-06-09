using UnityEngine;
using Tactical.Core.Enums;

namespace Tactical.Actor.Component {

	public class Health : MonoBehaviour {

		public int HP {
			get { return stats[StatType.HP]; }
			set { stats[StatType.HP] = value; }
		}

		public int MaxHP {
			get { return stats[StatType.MHP]; }
			set { stats[StatType.MHP] = value; }
		}

		public int MinHP;

		private Stats stats;

		private void Awake () {
			stats = GetComponent<Stats>();
		}

		private void OnEnable () {
			this.AddObserver(OnHPWillChange, Stats.WillChangeNotification(StatType.HP), stats);
			this.AddObserver(OnMaxPDidChange, Stats.DidChangeNotification(StatType.MHP), stats);
		}

		private void OnDisable () {
			this.RemoveObserver(OnHPWillChange, Stats.WillChangeNotification(StatType.HP), stats);
			this.RemoveObserver(OnMaxPDidChange, Stats.DidChangeNotification(StatType.MHP), stats);
		}

		private void OnHPWillChange (object sender, object args) {
			var vce = args as ValueChangeException;
			vce.AddModifier(new ClampValueModifier(int.MaxValue, MinHP, stats[StatType.MHP]));
		}

		private void OnMaxPDidChange (object sender, object args) {
			int oldMaxHP = (int) args;
			if (MaxHP > oldMaxHP) {
				HP += MaxHP - oldMaxHP;
			} else {
				HP = Mathf.Clamp(HP, MinHP, MaxHP);
			}
		}

	}

}
