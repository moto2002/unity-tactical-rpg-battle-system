using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Tactical.Terrain;
using Tactical.Unit;

namespace Tactical.Data {

	public static class DataLoader {

		private const string ROOT_PATH = "Data/";
		private const string CELL_TERRAIN_FILENAME = "CellTerrains.xml";
		private const string JOB_FILENAME = "Jobs.xml";

		public static List<CellTerrainData> LoadCellTerrains () {
			string path = Path.Combine(Application.dataPath, ROOT_PATH + CELL_TERRAIN_FILENAME);
			return CellTerrainCollection.Load(path).cellTerrains;
		}

		public static List<JobData> LoadJobs () {
			string path = Path.Combine(Application.dataPath, ROOT_PATH + JOB_FILENAME);
			return JobCollection.Load(path).jobs;
		}

	}

}
