using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace Tactical.Data {

	[InitializeOnLoad]
	public static class EditorLoader {

		public static List<CellTerrainData> cellTerrains = new List<CellTerrainData>();

		static EditorLoader () {
			LoadAll();
		}

		private static void LoadAll () {
			cellTerrains = DataLoader.LoadCellTerrains();
			Debug.Log("Editor data loaded.");
		}

		private static List<CellTerrainData> LoadAndGetCellTerrains () {
			return DataLoader.LoadCellTerrains();
		}
	}
}
