using UnityEngine;
using System.Collections.Generic;
using Tactical.Core;
using Tactical.Core.Component;
using Tactical.Item.Component;

namespace Tactical.Actor.Component {

	public class Job : MonoBehaviour {

		public static readonly StatType[] statOrder = new StatType[] {
			StatType.MHP,
			StatType.MMP,
			StatType.ATK,
			StatType.DEF,
			StatType.MAT,
			StatType.MDF,
			StatType.SPD
		};

		public int[] baseStats = new int[ statOrder.Length ];
		public float[] growStats = new float[ statOrder.Length ];
		private Stats stats;

		private void OnDestroy () {
			this.RemoveObserver(OnLvlChangeNotification, Stats.DidChangeNotification(StatType.LVL));
		}

		public void Employ () {
			stats = gameObject.GetComponentInParent<Stats>();
			this.AddObserver(OnLvlChangeNotification, Stats.DidChangeNotification(StatType.LVL), stats);

			Feature[] features = GetComponentsInChildren<Feature>();
			for (int i = 0; i < features.Length; ++i) {
				features[i].Activate(gameObject);
			}
		}

		public void UnEmploy () {
			Feature[] features = GetComponentsInChildren<Feature>();
			for (int i = 0; i < features.Length; ++i) {
				features[i].Deactivate();
			}

			this.RemoveObserver(OnLvlChangeNotification, Stats.DidChangeNotification(StatType.LVL), stats);
			stats = null;
		}

		public void LoadDefaultStats () {
			for (int i = 0; i < statOrder.Length; ++i) {
				StatType type = statOrder[i];
				stats.SetValue(type, baseStats[i], false);
			}

			stats.SetValue(StatType.HP, stats[StatType.MHP], false);
			stats.SetValue(StatType.MP, stats[StatType.MMP], false);
		}

		protected virtual void OnLvlChangeNotification (object sender, object args) {
			int oldValue = (int)args;
			int newValue = stats[StatType.LVL];

			for (int i = oldValue; i < newValue; ++i) {
				LevelUp();
			}
		}

		private void LevelUp () {
			for (int i = 0; i < statOrder.Length; ++i) {
				StatType type = statOrder[i];
				int whole = Mathf.FloorToInt(growStats[i]);
				float fraction = growStats[i] - whole;

				int value = stats[type];
				value += whole;
				if (UnityEngine.Random.value > (1f - fraction)) {
					value++;
				}

				stats.SetValue(type, value, false);
			}

			stats.SetValue(StatType.HP, stats[StatType.MHP], false);
			stats.SetValue(StatType.MP, stats[StatType.MMP], false);
		}

	}

}
