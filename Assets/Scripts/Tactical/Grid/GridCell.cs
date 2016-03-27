using UnityEngine;

namespace Tactical.Grid {

	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class GridCell : MonoBehaviour {

		public Vector3 gridPosition;

		private void Update () {
			UpdatePosition(gridPosition);
		}

		private void UpdatePosition (Vector3 targetPosition) {
			// TODO: Create and use GridToCellPosition instead.
			transform.position = targetPosition;
		}

	}

}
