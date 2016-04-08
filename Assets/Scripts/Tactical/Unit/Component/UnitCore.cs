using UnityEngine;
using Tactical.Core;
using Tactical.Grid.Component;

namespace Tactical.Unit.Component {

	public class UnitCore : MonoBehaviour {

		public Tile tile { get; protected set; }
		public Direction dir;

		public void Place (Tile target) {
			// Make sure old tile location is not still pointing to this unit
			if (tile != null && tile.content == gameObject) {
				tile.content = null;
			}

			// Link unit and tile references
			tile = target;

			if (target != null) {
				target.content = gameObject;
			}
		}

		public void Match () {
			transform.localPosition = tile.center + new Vector3(0f, transform.lossyScale.y, 0f);
			transform.localEulerAngles = dir.ToEuler();
		}

	}

	// [ExecuteInEditMode]
	// [DisallowMultipleComponent]
	// public class UnitCore : MonoBehaviour {

	// 	public Vector3 gridPosition;

	// 	private UnitJob jobComponent;
	// 	private UnitName nameComponent;

	// 	private void OnEnable () {
	// 		CellCursorMovement.OnCursorMoved += ShowInformation;
	// 	}

	// 	private void OnDisable () {
	// 		CellCursorMovement.OnCursorMoved -= ShowInformation;
	// 	}

	// 	private void Update () {
	// 		if (jobComponent == null) {
	// 			jobComponent = GetComponent<UnitJob>();
	// 		}

	// 		if (nameComponent == null) {
	// 			nameComponent = GetComponent<UnitName>();
	// 		}

	// 		UpdatePosition(gridPosition);
	// 	}

	// 	private void UpdatePosition (Vector3 targetPosition) {
	// 		transform.position = GridController.GridToUnitPosition(targetPosition);
	// 	}

	// 	private void ShowInformation (Vector3 position) {
	// 		if (gridPosition == position) {
	// 			UIManager.instance.unitInfo.visible = true;

	// 			if (nameComponent) {
	// 				UIManager.instance.unitInfo.title = nameComponent.GetFullName();
	// 			}

	// 			if (jobComponent) {
	// 				UIManager.instance.unitInfo.subtitle = jobComponent.job.name;
	// 			}
	// 		}
	// 	}

	// }

}
