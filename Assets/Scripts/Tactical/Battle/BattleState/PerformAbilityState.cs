using UnityEngine;
using System.Collections;

namespace Tactical.Battle.BattleState {

	public class PerformAbilityState : BattleState {

		public override void Enter () {
			base.Enter ();
			turn.hasUnitActed = true;
			if (turn.hasUnitMoved) {
				turn.lockMove = true;
			}
			StartCoroutine(Animate());
		}

		private IEnumerator Animate () {
			// TODO: Play animations, etc
			yield return null;
			ApplyAbility();

			if (turn.hasUnitMoved) {
				owner.ChangeState<EndFacingState>();
			} else {
				owner.ChangeState<CommandSelectionState>();
			}
		}

		private void ApplyAbility () {
			turn.ability.Perform(turn.targets);
		}

	}

}
