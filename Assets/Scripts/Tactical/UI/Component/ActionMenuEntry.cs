using UnityEngine;
using UnityEngine.UI;

namespace Tactical.UI.Component {

	public class ActionMenuEntry : MonoBehaviour {

		[System.Flags]
		enum EntryState {
			None = 0,
			Selected = 1 << 0,
			Locked = 1 << 1
		}

		public string Title {
			get { return label.text; }
			set { label.text = value; }
		}
		public bool IsLocked {
			get { return (State & EntryState.Locked) != EntryState.None; }
			set {
				if (value) {
					State |= EntryState.Locked;
				} else {
					State &= ~EntryState.Locked;
				}
			}
		}
		public bool IsSelected {
			get { return (State & EntryState.Selected) != EntryState.None; }
			set {
				if (value) {
					State |= EntryState.Selected;
				} else {
					State &= ~EntryState.Selected;
				}
			}
		}

		[SerializeField] private Image bullet;
		[SerializeField] private Sprite normalSprite;
		[SerializeField] private Sprite selectedSprite;
		[SerializeField] private Sprite disabledSprite;
		[SerializeField] private Text label;
		private Outline outline;

		private void Awake () {
			outline = label.GetComponent<Outline>();
		}

		public void Reset () {
			State = EntryState.None;
		}

		private EntryState State {
			get { return state; }
			set {
				if (state == value) {
					return;
				}
				state = value;

				if (IsLocked) {
					bullet.sprite = disabledSprite;
					label.color = Color.gray;
					outline.effectColor = new Color32(20, 36, 44, 255);
				} else if (IsSelected) {
					bullet.sprite = selectedSprite;
					label.color = new Color32(249, 210, 118, 255);
					outline.effectColor = new Color32(255, 160, 72, 255);
				} else {
					bullet.sprite = normalSprite;
					label.color = Color.white;
					outline.effectColor = new Color32(20, 36, 44, 255);
				}
			}
		}
		private EntryState state;

	}

}
