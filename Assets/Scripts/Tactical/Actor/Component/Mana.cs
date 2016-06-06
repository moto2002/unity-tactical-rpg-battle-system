using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Battle.Controller;

namespace Tactical.Actor.Component {

	public class Mana : MonoBehaviour {

		public int MP {
			get { return stats[StatType.MP]; }
			set { stats[StatType.MP] = value; }
		}

		public int MMP {
			get { return stats[StatType.MMP]; }
			set { stats[StatType.MMP] = value; }
		}

		private Unit unit;
		private Stats stats;

		private void Awake () {
			stats = GetComponent<Stats>();
			unit = GetComponent<Unit>();
		}

		private void OnEnable () {
			this.AddObserver(OnMPWillChange, Stats.WillChangeNotification(StatType.MP), stats);
			this.AddObserver(OnMMPDidChange, Stats.DidChangeNotification(StatType.MMP), stats);
			this.AddObserver(OnTurnBegan, TurnOrderController.TurnBeganNotification, unit);
		}

		private void OnDisable () {
			this.RemoveObserver(OnMPWillChange, Stats.WillChangeNotification(StatType.MP), stats);
			this.RemoveObserver(OnMMPDidChange, Stats.DidChangeNotification(StatType.MMP), stats);
			this.RemoveObserver(OnTurnBegan, TurnOrderController.TurnBeganNotification, unit);
		}

		private void OnMPWillChange (object sender, object args) {
			var vce = args as ValueChangeException;
			vce.AddModifier(new ClampValueModifier(int.MaxValue, 0, stats[StatType.MHP]));
		}

		private void OnMMPDidChange (object sender, object args) {
			int oldMMP = (int)args;
			if (MMP > oldMMP) {
				MP += MMP - oldMMP;
			} else {
				MP = Mathf.Clamp(MP, 0, MMP);
			}
		}

		private void OnTurnBegan (object sender, object args) {
			if (MP < MMP) {
				MP += Mathf.Max(Mathf.FloorToInt(MMP * 0.1f), 1);
			}
		}

	}

}
