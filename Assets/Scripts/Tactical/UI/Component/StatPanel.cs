using UnityEngine;
using UnityEngine.UI;
using Tactical.Core;
using Tactical.Actor.Component;

namespace Tactical.UI.Component {

	public class StatPanel : MonoBehaviour {

		public Panel panel;
		public Sprite allyBackground;
		public Sprite enemyBackground;
		public Image background;
		public Image avatar;
		public Text nameLabel;
		public Text hpLabel;
		public Text mpLabel;
		public Text lvLabel;

		public void Display (GameObject obj) {
			// TODO: Choose the sprites depending on the actor.
			background.sprite = allyBackground;
			// avatar.sprite = null; Need a component which provides this data

			nameLabel.text = obj.name;
			Stats stats = obj.GetComponent<Stats>();
			if (stats) {
				hpLabel.text = string.Format( "HP {0} / {1}", stats[StatType.HP], stats[StatType.MHP] );
				mpLabel.text = string.Format( "MP {0} / {1}", stats[StatType.MP], stats[StatType.MMP] );
				lvLabel.text = string.Format( "LV. {0}", stats[StatType.LVL]);
			}
		}
	}

}
