using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Tactical.Terrain;

namespace Tactical.Data {

	public class DataManager : MonoBehaviour {

		public Dictionary<string, List<CellTerrainData>> data;
		public List<CellTerrainData> cellTerrains = new List<CellTerrainData>();

		public void LoadAll () {
			cellTerrains = DataLoader.LoadCellTerrains();
			Debug.Log("Data loaded.");
		}
	}

}
