using UnityEngine;
using UnityEditor;
using Tactical.Core.Enums;
using Tactical.Actor.Component;

namespace Tactical.Actor.Editor {

	[CustomEditor(typeof(Stats))]
	public class StatsInspector : UnityEditor.Editor {

		public Stats current {
			get { return (Stats) target; }
		}

		public override void OnInspectorGUI () {
			DrawDefaultInspector();

			GUILayout.Label(string.Format("Level: {0}", current[StatType.LVL]));
			BasicStatButton(StatType.LVL, 1);

			GUILayout.Label(string.Format("Experience: {0}", current[StatType.EXP]));
			BasicStatButton(StatType.EXP, 25);
		}

		private void BasicStatButton (StatType statType, int step) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("-" + step)) {
				current.SetValue(statType, current[statType] - step, true);
			}
			if (GUILayout.Button("+" + step)) {
				current.SetValue(statType, current[statType] + step, true);
			}
			GUILayout.EndHorizontal();
		}

	}

}
