using UnityEngine;
using System.Collections.Generic;
using Tactical.Grid.Component;
using Tactical.Actor.Component;

namespace Tactical.Actor.Component {

	public class Ability : MonoBehaviour {

		public const string CanPerformCheck = "Ability.CanPerformCheck";
		public const string FailedNotification = "Ability.FailedNotification";
		public const string DidPerformNotification = "Ability.DidPerformNotification";

		public bool CanPerform () {
			var exc = new BaseException(true);
			this.PostNotification(CanPerformCheck, exc);
			return exc.toggle;
		}

		public void Perform (List<Tile> targets) {
			if (!CanPerform()) {
				this.PostNotification(FailedNotification);
				return;
			}

			for (int i = 0; i < targets.Count; ++i) {
				Perform(targets[i]);
			}

			this.PostNotification(DidPerformNotification);
		}

		private void Perform (Tile target) {
			for (int i = 0; i < transform.childCount; ++i) {
				Transform child = transform.GetChild(i);
				var effect = child.GetComponent<BaseAbilityEffect>();
				effect.Apply(target);
			}
		}
	}

}
