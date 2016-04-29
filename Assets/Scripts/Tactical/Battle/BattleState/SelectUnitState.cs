using System.Collections;

namespace Tactical.Battle.BattleState {

	public class SelectUnitState : BattleState {

		private int index = -1;

		public override void Enter () {
			base.Enter();
			StartCoroutine("ChangeCurrentUnit");
		}

		public override void Exit () {
			base.Exit();
			statPanelController.HidePrimary();
		}

		private IEnumerator ChangeCurrentUnit () {
			index = (index + 1) % units.Count;
			turn.Change(units[index]);
			RefreshPrimaryStatPanel(pos);
			yield return null;
			owner.ChangeState<CommandSelectionState>();
		}

	}

}
