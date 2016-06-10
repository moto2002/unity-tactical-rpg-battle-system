using UnityEngine;
using Tactical.Core.Enums;

namespace Tactical.Core.Controller {

	public class DefeatTargetVictoryCondition : BaseVictoryCondition {

		public Tactical.Actor.Component.Unit target;

		protected override void CheckForGameOver () {
			base.CheckForGameOver();
			if (Victor == Alliance.None && IsDefeated(target)) {
				Victor = Alliance.Hero;
			}
		}

	}

}
