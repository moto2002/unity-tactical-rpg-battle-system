using UnityEngine;
using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Grid.Component;

namespace Tactical.Battle.Component {

	public class Board : MonoBehaviour {

		[SerializeField] private GameObject tilePrefab;

		public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

		public void Load (LevelData data) {
			for (int i = 0; i < data.tiles.Count; ++i) {
				var instance = Instantiate(tilePrefab);
				instance.transform.parent = transform;
				Tile t = instance.GetComponent<Tile>();
				t.Load(data.tiles[i]);
				tiles.Add(t.pos, t);
			}
		}
	}

}
