using UnityEngine;
using System;
using Tactical.Core.Enums;

namespace Tactical.UI.Controller {

	public class UnitDirectionController : MonoBehaviour {

		[SerializeField] private Transform[] directions;
		[SerializeField] private Material materialDefault;
		[SerializeField] private Material materialActive;
		private Direction dir;

		private void Start () {
			Hide();

			if (directions.Length == 0) {
				throw new Exception(string.Format("Missing property: directions."));
			}
		}

		public void Show () {
			SetVisibility(true);
		}

		public void Show (Direction direction) {
			SetDirection(direction);
			Show();
		}

		public void Hide () {
			SetVisibility(false);
		}

		public void SetPosition (Vector3 position) {
			gameObject.transform.localPosition = position;
		}

		public void SetDirection (Direction direction) {
			dir = direction;

			for (var i = 0; i < directions.Length; i++) {
				var directionRenderer = directions[i].GetComponent<Renderer>();

				if (i == (int) dir) {
					directionRenderer.material = materialActive;
				}	else {
					directionRenderer.material = materialDefault;
				}
			}
		}

		private void SetVisibility (bool visibility) {
			foreach (Transform direction in directions) {
				direction.GetComponent<Renderer>().enabled = visibility;
			}
		}

	}

}
