using UnityEngine;

using System.Collections.Generic;

namespace Tactical.Unit {

	public class UnitManager : MonoBehaviour {

		public List<GameObject> units = new List<GameObject>();

		private const string UNIT_TAG = "Unit";

		private void Update () {
			UpdateUnits();
		}

		private void UpdateUnits () {
			// TODO: Handle new and dead units.
			if (units.Count == 0) {
				foreach (GameObject unit in GameObject.FindGameObjectsWithTag(UNIT_TAG)) {
					units.Add(unit);
				}
			}
		}

	}

}
