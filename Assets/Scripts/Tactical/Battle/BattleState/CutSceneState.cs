using UnityEngine;
using Tactical.Core.EventArgs;
using Tactical.Core.Controller;
using Tactical.Core.Model;

namespace Tactical.Battle.BattleState {

	public class CutSceneState : BattleState {

		private ConversationController conversationController;
		private ConversationData data;

		protected override void Awake () {
			base.Awake();
			conversationController = owner.GetComponentInChildren<ConversationController>();
			// data = Resources.Load<ConversationData>("Conversations/Battle1 - Intro");
		}

		protected override void OnDestroy () {
			base.OnDestroy();
			if (data) {
				Resources.UnloadAsset(data);
			}
		}

		public override void Enter () {
			base.Enter();
			if (data != null) {
				conversationController.Show(data);
			}
		}

		protected override void AddListeners () {
			base.AddListeners();
			ConversationController.completeEvent += OnCompleteConversation;
		}

		protected override void RemoveListeners () {
			base.RemoveListeners();
			ConversationController.completeEvent -= OnCompleteConversation;
		}

		protected override void OnFire (object sender, InfoEventArgs<int> e) {
			base.OnFire (sender, e);
			conversationController.Next();
		}

		private void OnCompleteConversation (object sender, System.EventArgs e) {
			owner.ChangeState<SelectUnitState>();
		}


	}

}
