using UnityEngine;

using System.Collections.Generic;

namespace Tactical.Unit {

	public class UnitController : MonoBehaviour {

		public List<Unit> units = new List<Unit>();

		private void Start () {
			foreach (Transform child in transform) {
				units.Add(child.GetComponent<Unit>());
			}
		}

	}

}
