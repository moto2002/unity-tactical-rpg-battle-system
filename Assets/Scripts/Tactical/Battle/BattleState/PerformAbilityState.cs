using UnityEngine;
using System.Collections;
using Tactical.Actor.Component;

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

			// The battle is over.
			if (IsBattleOver()) {
				owner.ChangeState<CutSceneState>();
			}
			// The unit finished their turn.
			else if (!UnitHasControl()) {
				owner.ChangeState<SelectUnitState>();
			}
			// The unit can still move.
			else if (turn.hasUnitMoved) {
				owner.ChangeState<EndFacingState>();
			}
			// The unit is starting their turn.
			else {
				owner.ChangeState<CommandSelectionState>();
			}
		}

		private bool UnitHasControl () {
			return turn.actor.GetComponentInChildren<DeadStatusEffect>() == null;
		}

		private void ApplyAbility () {
			turn.ability.Perform(turn.targets);
		}

	}

}
