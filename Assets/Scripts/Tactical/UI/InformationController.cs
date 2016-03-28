using UnityEngine;
using UnityEngine.UI;

namespace Tactical.UI {

	[DisallowMultipleComponent]
	[RequireComponent (typeof (Canvas))]
	public class InformationController : MonoBehaviour {

		[HideInInspector] public bool visible;
		[HideInInspector] public string title;
		[HideInInspector] public string subtitle;

		private Text titleText;
		private Text subtitleText;
		private Canvas canvas;

		private void Start () {
			canvas = gameObject.GetComponent<Canvas>();
			titleText = transform.Find("Title").GetComponent<Text>();
			subtitleText = transform.Find("Subtitle").GetComponent<Text>();
		}

		private void Update () {
			UpdateVisibility();

			if (visible) {
				UpdateInformations();
			}
			Debug.Log("titleText.text"+ titleText.text);
		}

		private void UpdateVisibility () {
			canvas.enabled = visible;
		}

		private void UpdateInformations () {
			if (titleText != null) {
				titleText.text = title;
			}
			if (subtitleText != null) {
				subtitleText.text = subtitle;
			}
		}

	}

}
