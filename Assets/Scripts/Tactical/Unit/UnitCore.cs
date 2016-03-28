using UnityEngine;
using Tactical.Grid;

namespace Tactical.Unit {

	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class UnitCore : MonoBehaviour {

		public Vector3 gridPosition;

		private UnitJob jobComponent;
		private UnitName nameComponent;

		private void OnEnable () {
			CellCursorMovement.OnCursorMoved += ShowInformation;
		}

		private void OnDisable () {
			CellCursorMovement.OnCursorMoved -= ShowInformation;
		}

		private void Update () {
			if (jobComponent == null) {
				jobComponent = GetComponent<UnitJob>();
			}

			if (nameComponent == null) {
				nameComponent = GetComponent<UnitName>();
			}

			UpdatePosition(gridPosition);
		}

		private void UpdatePosition (Vector3 targetPosition) {
			transform.position = GridController.GridToUnitPosition(targetPosition);
		}

		private void ShowInformation (Vector3 position) {
			if (gridPosition == position) {
				UIManager.instance.informationController.visible = true;

				if (nameComponent) {
					UIManager.instance.informationController.title = nameComponent.GetFullName();
				}

				if (jobComponent) {
					UIManager.instance.informationController.subtitle = jobComponent.job.name;
				}
			}
		}

	}

}
