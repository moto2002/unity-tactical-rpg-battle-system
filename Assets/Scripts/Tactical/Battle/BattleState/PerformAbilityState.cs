using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tactical.Core;
using Tactical.Core.EventArgs;
using Tactical.Grid.Model;
using Tactical.Grid.Component;
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
			// TODO: Apply ability effect, etc
			TemporaryAttackExample();

			if (turn.hasUnitMoved) {
				owner.ChangeState<EndFacingState>();
			} else {
				owner.ChangeState<CommandSelectionState>();
			}
		}

		private void TemporaryAttackExample () {
			for (int i = 0; i < turn.targets.Count; ++i) {
				GameObject obj = turn.targets[i].content;
				Stats stats = obj != null ? obj.GetComponentInChildren<Stats>() : null;
				if (stats != null) {
					stats[StatType.HP] -= 50;
					if (stats[StatType.HP] <= 0) {
						Debug.Log("KO'd Uni!", obj);
					}
				}
			}
		}

	}

}
