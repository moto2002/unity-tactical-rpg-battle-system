using UnityEngine;
using System.Collections;
using Tactical.Unit.Component;

namespace Tactical.Battle.BattleState {

	public class MoveSequenceState : BattleState {

		public override void Enter () {
			base.Enter ();
			StartCoroutine("Sequence");
		}

		private IEnumerator Sequence () {
			Movement m = owner.currentUnit.GetComponent<Movement>();
			yield return StartCoroutine(m.Traverse(owner.currentTile));
			owner.ChangeState<SelectUnitState>();
		}

	}

}
