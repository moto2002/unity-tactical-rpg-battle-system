using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Tactical.Terrain;
using Tactical.Unit;

namespace Tactical.Data {

	[InitializeOnLoad]
	public static class EditorLoader {

		public static List<CellTerrainData> cellTerrains = new List<CellTerrainData>();
		public static List<JobData> jobs = new List<JobData>();

		static EditorLoader () {
			LoadAll();
		}

		private static void LoadAll () {
			cellTerrains = DataLoader.LoadCellTerrains();
			jobs = DataLoader.LoadJobs();
			Debug.Log("Editor data loaded.");
		}
	}
}
