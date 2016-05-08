using UnityEngine;
using Tactical.Grid.Component;

namespace Tactical.Actor.Component {

	public abstract class AbilityEffectTarget : MonoBehaviour {

		public abstract bool IsTarget (Tile tile);

	}

}
