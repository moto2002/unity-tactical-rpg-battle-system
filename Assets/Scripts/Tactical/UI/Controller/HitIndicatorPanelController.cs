using UnityEngine;
using UnityEngine.UI;
using Tactical.UI.Component;

namespace Tactical.UI.Controller {

	public class HitIndicatorPanelController : MonoBehaviour {

		private const string ShowKey = "Show";
		private const string HideKey = "Hide";

		[SerializeField] private Canvas canvas;
		[SerializeField] private Panel panel;
		[SerializeField] private Image arrow;
		[SerializeField] private Text label;
		private Tweener transition;

		private void Start () {
			panel.SetPosition(HideKey, false);
			canvas.gameObject.SetActive(false);
		}

		public void SetStats (int chance, int amount) {
			arrow.fillAmount = (chance / 100f);
			label.text = string.Format("{0}% {1} dmg", chance, amount);
		}

		public void Show () {
			canvas.gameObject.SetActive(true);
			SetPanelPos(ShowKey);
		}

		public void Hide () {
			SetPanelPos(HideKey);
		}

		private void SetPanelPos (string pos) {
			if (transition != null && transition.easingControl.IsPlaying) {
				transition.easingControl.Stop();
			}

			transition = panel.SetPosition(pos, false);
		}

	}

}
