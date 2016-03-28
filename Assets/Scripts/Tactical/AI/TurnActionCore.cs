using UnityEngine;
using System.Collections;
using Tactical.Unit;
using Tactical.Battle;

namespace Tactical.AI {

	public class TurnActionCore : MonoBehaviour {

		private void OnEnable () {
			TurnManager.OnNPCActionStarted += HandleNPCActionStarted;
		}

		private void OnDisable () {
			TurnManager.OnNPCActionStarted -= HandleNPCActionStarted;
		}

		// TODO: Remove this code and use real AI to play for this action.
		private IEnumerator HandleNPCActionStarted (GameObject unit) {
			Debug.Log(string.Format("{0} action [start]", "NPC"));
			yield return null;
			unit.GetComponent<UnitMovement>().Move(
			 new Vector3(Mathf.Floor(Random.Range(0f, 4f)), 0, Mathf.Floor(Random.Range(0f, 4f)))
			);
			Debug.Log(string.Format("{0} action [end]", "NPC"));
		}
	}

}
