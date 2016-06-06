using UnityEngine;
using System;
using System.Collections.Generic;
using Tactical.Actor.Component;

namespace Tactical.Battle.BattleState {

	public class CommandCategorySelectionState : BaseActionMenuState {

		public override void Enter () {
			base.Enter();
			statPanelController.ShowPrimary(turn.actor.gameObject);
		}

		public override void Exit () {
			base.Exit();
			statPanelController.HidePrimary();
		}

		protected override void LoadMenu () {
			if (menuOptions == null) {
				menuOptions = new List<string>();
			} else {
				menuOptions.Clear();
			}

			menuTitle = "Action";
			menuOptions.Add("Attack");

			AbilityCatalog catalog = turn.actor.GetComponentInChildren<AbilityCatalog>();
			if (catalog == null) {
				throw new Exception("Missing component AbilityCatalog in children.");
			}

			for (int i = 0; i < catalog.CategoryCount(); ++i) {
				menuOptions.Add( catalog.GetCategory(i).name );
			}

			actionMenuPanelController.Show(menuTitle, menuOptions);
		}

		protected override void Confirm () {
			if (actionMenuPanelController.selection == 0) {
				Attack();
			} else {
				SetCategory(actionMenuPanelController.selection - 1);
			}
		}

		protected override void Cancel () {
			owner.ChangeState<CommandSelectionState>();
		}

		private void Attack () {
			turn.ability = turn.actor.GetComponentInChildren<Ability>();
			owner.ChangeState<AbilityTargetState>();
		}

		private void SetCategory (int index) {
			ActionSelectionState.category = index;
			owner.ChangeState<ActionSelectionState>();
		}

	}

}
