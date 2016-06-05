using UnityEngine;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public abstract class BaseAbilityEffect : MonoBehaviour {

		public abstract int Predict (Tile target);
		public abstract void Apply (Tile target);

	}

}
