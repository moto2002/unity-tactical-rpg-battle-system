using UnityEngine;

namespace Tactical.Grid {

	public class CellColor : MonoBehaviour {

		public Color color = Color.white;

		private void Update () {
			GetComponent<Renderer>().material.color = color;
		}

	}

}
