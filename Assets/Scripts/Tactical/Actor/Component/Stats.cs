using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Tactical.Core.Enums;

namespace Tactical.Actor.Component {

	public class Stats : MonoBehaviour {

		// Indexer to allow us to iterate on the stats like an array.
		public int this[StatType s] {
			get { return _data[(int) s]; }
			set { SetValue(s, value, true); }
		}

		[SerializeField] private int[] _data = new int[ (int) StatType.Count ];
		private static Dictionary<StatType, string> _willChangeNotifications = new Dictionary<StatType, string>();
		private static Dictionary<StatType, string> _didChangeNotifications = new Dictionary<StatType, string>();

		public void SetValue (StatType type, int value, bool allowExceptions) {
			int oldValue = this[type];
			if (oldValue == value) {
				return;
			}

			if (allowExceptions) {
				// Allow exceptions to the rule here
				var exc = new ValueChangeException(oldValue, value);

				// The notification is unique per stat type
				this.PostNotification(WillChangeNotification(type), exc);

				// Did anything modify the value?
				value = Mathf.FloorToInt(exc.GetModifiedValue());

				// Did something nullify the change?
				if (!exc.toggle || value == oldValue) {
					return;
				}
			}

			_data[(int)type] = value;
			this.PostNotification(DidChangeNotification(type), oldValue);
		}

		public static string WillChangeNotification (StatType type) {
			if (!_willChangeNotifications.ContainsKey(type)) {
				_willChangeNotifications.Add(type, string.Format("Stats.{0}WillChange", type));
			}
			return _willChangeNotifications[type];
		}

		public static string DidChangeNotification (StatType type) {
			if (!_didChangeNotifications.ContainsKey(type)) {
				_didChangeNotifications.Add(type, string.Format("Stats.{0}DidChange", type));
			}
			return _didChangeNotifications[type];
		}

	}

	[CustomEditor(typeof(Stats))]
	public class StatsInspector : Editor {

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
