using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Tactical.Data {

	public class DataManager : MonoBehaviour {

		public Dictionary<string, List<CellTerrainData>> data;
		public List<CellTerrainData> cellTerrains = new List<CellTerrainData>();

		public void LoadAll () {
			cellTerrains = DataLoader.LoadCellTerrains();
			Debug.Log("Data loaded.");
		}

		public CellTerrainData GetCellTerrain (int id) {
			return cellTerrains.Find(cellTerrain => cellTerrain.id == id);
		}

		public List<CellTerrainData> GetCellTerrains () {
			return cellTerrains;
		}

		private static List<CellTerrainData> LoadAndGetCellTerrains () {
			return DataLoader.LoadCellTerrains();
		}
	}

	public static class DataLoader {

		private const string ROOT_PATH = "Data/";
		private const string CELL_TERRAIN_FILENAME = "CellTerrains.xml";

		public static List<CellTerrainData> LoadCellTerrains () {
			string path = Path.Combine(Application.dataPath, ROOT_PATH + CELL_TERRAIN_FILENAME);
			return CellTerrainCollection.Load(path).cellTerrains;
		}

	}

}
