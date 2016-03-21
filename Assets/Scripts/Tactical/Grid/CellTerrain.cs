using UnityEngine;

namespace Tactical.Terrain {

	using Data;

	public class CellTerrain : MonoBehaviour {

		public CellTerrainData data;

		public static CellTerrain CreateComponent (GameObject target, int id) {
			CellTerrain component = target.AddComponent<CellTerrain>();
			component.data = GameManager.instance.dataManager.GetCellTerrain(id);

			return component;
		}

		private void Update () {
			GetComponent<Renderer>().material.color = data.color;
		}
	}

}
