using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Tactical.Data {

	public class DataManager : MonoBehaviour {

		private const string ROOT_PATH = "Data/";
		private const string CELL_TERRAIN_FILENAME = "CellTerrains.xml";

		public List<CellTerrainData> cellTerrains = new List<CellTerrainData>();

		public void Load () {
			cellTerrains = GetLoadedCellTerrains();
			Debug.Log("Data loaded.");
		}

		private static List<CellTerrainData> GetLoadedCellTerrains () {
			string path = Path.Combine(Application.dataPath, ROOT_PATH + CELL_TERRAIN_FILENAME);
			return CellTerrainCollection.Load(path).cellTerrains;
		}

		public CellTerrainData GetCellTerrain (int id) {
			return cellTerrains.Find(cellTerrain => cellTerrain.id == id);
		}

		public List<CellTerrainData> GetCellTerrains () {
			return cellTerrains;
		}
	}
}
