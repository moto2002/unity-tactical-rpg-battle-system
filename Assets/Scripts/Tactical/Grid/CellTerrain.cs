using UnityEngine;
using UnityEditor;

namespace Tactical.Terrain {

	using Data;

	[ExecuteInEditMode]
	public class CellTerrain : MonoBehaviour {

		public CellTerrainData terrain;

		private Renderer renderer;

		private void Start () {
			renderer = GetComponent<Renderer>();
		}

		private void OnRenderObject () {
			UpdateMaterialColor();
		}

		private void UpdateMaterialColor () {
			if (terrain == null || renderer == null || renderer.sharedMaterial.name == terrain.material) { return; }

			renderer.sharedMaterial = Resources.Load("Materials/" + terrain.material, typeof(Material)) as Material;
		}
	}

	[CustomEditor(typeof(CellTerrain))]
	public class CellTerrainEditor : Editor {

		public override void OnInspectorGUI () {
			var myTarget = (CellTerrain) target;

			var selectedIds = myTarget.terrain != null ? myTarget.terrain.id : 1;
			var names = EditorLoader.cellTerrains.ConvertAll(item => item.name).ToArray();
			var ids = EditorLoader.cellTerrains.ConvertAll(item => item.id).ToArray();

			var newId = EditorGUILayout.IntPopup("Terrain", selectedIds, names, ids);
			myTarget.terrain = EditorLoader.cellTerrains.Find(item => item.id == newId);
		}
	}
}
