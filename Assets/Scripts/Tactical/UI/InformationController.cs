using UnityEngine;
using UnityEngine.UI;

namespace Tactical.UI {

	[DisallowMultipleComponent]
	public class InformationController : MonoBehaviour {

		public string title;
		public bool visible;
		public Text titleText;

		private void Update () {
			UpdateVisibility();

			if (visible) {
				UpdateInformations();
			}
		}

		private void UpdateVisibility () {
			gameObject.GetComponent<Canvas>().enabled = visible;
		}

		private void UpdateInformations () {
			titleText.text = title;
		}

	}

}
