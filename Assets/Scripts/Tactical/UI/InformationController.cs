using UnityEngine;
using UnityEngine.UI;

namespace Tactical.UI {

	[DisallowMultipleComponent]
	public class InformationController : MonoBehaviour {

		public bool visible;

		public string title;
		public Text titleText;

		public string subtitle;
		public Text subtitleText;

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
			subtitleText.text = subtitle;
		}

	}

}
