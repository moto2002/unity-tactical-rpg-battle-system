using UnityEngine;
using Tactical.Core.Enums;

namespace Tactical.Actor.Component {

	public class Health : MonoBehaviour {

		public int HP {
			get { return stats[StatType.HP]; }
			set { stats[StatType.HP] = value; }
		}

		public int MHP {
			get { return stats[StatType.MHP]; }
			set { stats[StatType.MHP] = value; }
		}

		private Stats stats;

		private void Awake () {
			stats = GetComponent<Stats>();
		}

		private void OnEnable () {
			this.AddObserver(OnHPWillChange, Stats.WillChangeNotification(StatType.HP), stats);
			this.AddObserver(OnMHPDidChange, Stats.DidChangeNotification(StatType.MHP), stats);
		}

		private void OnDisable () {
			this.RemoveObserver(OnHPWillChange, Stats.WillChangeNotification(StatType.HP), stats);
			this.RemoveObserver(OnMHPDidChange, Stats.DidChangeNotification(StatType.MHP), stats);
		}

		private void OnHPWillChange (object sender, object args) {
			var vce = args as ValueChangeException;
			vce.AddModifier(new ClampValueModifier(int.MaxValue, 0, stats[StatType.MHP]));
		}

		private void OnMHPDidChange (object sender, object args) {
			int oldMHP = (int) args;
			if (MHP > oldMHP) {
				HP += MHP - oldMHP;
			} else {
				HP = Mathf.Clamp(HP, 0, MHP);
			}
		}

	}

}
