using UnityEngine;

namespace Tactical.Unit {


	[DisallowMultipleComponent]
	public class PlayerControllable : MonoBehaviour {

		public enum Player {
			Player1,
			Player2
		}

		public Player player;
	}

}
