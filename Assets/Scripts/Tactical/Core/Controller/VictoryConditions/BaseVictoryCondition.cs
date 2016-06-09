using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Battle.Controller;
using Tactical.Actor.Component;

namespace Tactical.Core.Controller {

	public abstract class BaseVictoryCondition : MonoBehaviour {

		public Enums.Alliance Victor {
			get { return victor; }
			protected set { victor = value; }
		}
		protected BattleController bc;

		private Enums.Alliance victor = Enums.Alliance.None;

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
			// CheckForGameOver();
		}

		protected virtual bool IsDefeated (Unit unit) {
			Health health = unit.GetComponent<Health>();
			if (health) {
				return health.MinHP == health.HP;
			}

			Stats stats = unit.GetComponent<Stats>();
			return stats[StatType.HP] == 0;
		}

	}

}
