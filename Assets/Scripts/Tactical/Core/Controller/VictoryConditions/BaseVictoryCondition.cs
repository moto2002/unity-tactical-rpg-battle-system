using UnityEngine;
using Tactical.Battle.Controller;
using Tactical.Actor.Component;

using AllianceEnum = Tactical.Core.Enums.Alliance;
using StatType = Tactical.Core.Enums.StatType;

namespace Tactical.Core.Controller {

	public abstract class BaseVictoryCondition : MonoBehaviour {

		public AllianceEnum Victor {
			get { return victor; }
			protected set { victor = value; }
		}
		protected BattleController bc;

		private AllianceEnum victor = AllianceEnum.None;

		protected virtual void Awake () {
			bc = GetComponent<BattleController>();
		}

		protected virtual void OnEnable () {
			this.AddObserver(OnHPDidChangeNotification, Stats.DidChangeNotification(StatType.HP));
		}

		protected virtual void OnDisable () {
			this.RemoveObserver(OnHPDidChangeNotification, Stats.DidChangeNotification(StatType.HP));
		}

		protected virtual void OnHPDidChangeNotification (object sender, object args) {
			CheckForGameOver();
		}

		protected virtual bool IsDefeated (Unit unit) {
			Health health = unit.GetComponent<Health>();
			if (health) {
				return health.MinHP == health.HP;
			}

			Stats stats = unit.GetComponent<Stats>();
			return stats[StatType.HP] == 0;
		}

		protected virtual bool PartyDefeated (AllianceEnum type) {
			for (int i = 0; i < bc.units.Count; ++i) {
				Alliance a = bc.units[i].GetComponent<Alliance>();
				if (a == null) {
					continue;
				}

				if (a.type == type && !IsDefeated(bc.units[i])) {
					return false;
				}
			}
			return true;
		}

		protected virtual void CheckForGameOver () {
			if (PartyDefeated(AllianceEnum.Hero)) {
				Victor = AllianceEnum.Enemy;
			}
		}

	}

}
