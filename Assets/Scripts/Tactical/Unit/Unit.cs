using UnityEngine;
using Tactical.Grid;

namespace Tactical.Unit {

	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class Unit : MonoBehaviour {

		public Vector3 gridPosition;
		public string firstName;
		public string lastName;

		private HasJob jobComponent;

		/// <summary>
		/// Get the full name of the unit.
		/// </summary>
		///
		/// <returns>The full name of the unit.</returns>
		public string GetFullName () {
			return firstName + " " + lastName;
		}

		private void OnEnable () {
			CellCursorMovement.OnCursorMoved += ShowInformation;
		}

		private void OnDisable () {
			CellCursorMovement.OnCursorMoved -= ShowInformation;
		}

		private void Update () {
			if (jobComponent == null) {
				jobComponent = GetComponent<HasJob>();
			}

			UpdatePosition(gridPosition);
		}

		private void UpdatePosition (Vector3 targetPosition) {
			transform.position = GridController.GridToUnitPosition(targetPosition);
		}

		private void ShowInformation (Vector3 position) {
			if (gridPosition == position) {
				UIManager.instance.informationController.visible = true;
				UIManager.instance.informationController.title = GetFullName();

				if (jobComponent) {
					UIManager.instance.informationController.subtitle = jobComponent.job.name;
				}
			}
		}

	}

}
