using UnityEngine;
using Tactical.Core.Enums;

namespace Tactical.Core.Controller {

	public class DefeatAllEnemiesVictoryCondition : BaseVictoryCondition {

		protected override void CheckForGameOver () {
			base.CheckForGameOver();
			if (Victor == Alliance.None && PartyDefeated(Alliance.Enemy)) {
				Victor = Alliance.Hero;
			}
		}

	}

}
