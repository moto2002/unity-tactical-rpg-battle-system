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
			string sign = (amount < 0) ? "" : "+";
			label.text = string.Format("{0}% {1}{2} {3}", chance, sign, Mathf.Abs(amount), "HP");
		}

		public void Show () {
			canvas.gameObject.SetActive(true);
			SetPanelPos(ShowKey);
		}

		public void Hide () {
			SetPanelPos(HideKey);
		}

		private void SetPanelPos (string pos) {
			if (transition != null && transition.IsPlaying) {
				transition.Stop();
			}

			transition = panel.SetPosition(pos, false);
		}

	}

}
