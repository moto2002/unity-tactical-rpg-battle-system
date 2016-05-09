using UnityEngine;
using Tactical.Battle.Controller;
using Tactical.Actor.Component;

namespace Tactical.Actor.Component {

	public class DurationStatusCondition : StatusCondition {

		public int duration = 10;

		private void OnEnable () {
			this.AddObserver(OnNewTurn, TurnOrderController.RoundBeganNotification);
		}

		private void OnDisable () {
			this.RemoveObserver(OnNewTurn, TurnOrderController.RoundBeganNotification);
		}

		private void OnNewTurn (object sender, object args) {
			duration--;
			if (duration <= 0) {
				Remove();
			}
		}
	}

}
