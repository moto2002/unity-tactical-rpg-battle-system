using UnityEngine;
using System;
using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Grid.Component;

namespace Tactical.Battle.Component {

	public class Board : MonoBehaviour {

		public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

		[SerializeField] private GameObject tilePrefab;
		private Point[] dirs = new Point[4] {
			new Point(0, 1),
			new Point(0, -1),
			new Point(1, 0),
			new Point(-1, 0)
		};
		private Color selectedTileColor = new Color(0.15f, 0.15f, 0.4f, 1);

		public void Load (LevelData data) {
			for (int i = 0; i < data.tiles.Count; ++i) {
				var instance = Instantiate(tilePrefab);
				instance.transform.parent = transform;
				Tile t = instance.GetComponent<Tile>();
				t.Load(data.tiles[i]);
				tiles.Add(t.pos, t);
			}
		}

		public void SelectTiles (List<Tile> tiles) {
			for (int i = tiles.Count - 1; i >= 0; --i) {
				tiles[i].GetComponent<Renderer>().material.SetColor("_DefaultColor", tiles[i].GetComponent<Renderer>().material.color);
				tiles[i].GetComponent<Renderer>().material.SetColor("_Color", selectedTileColor);
			}
		}

		public void DeSelectTiles (List<Tile> tiles) {
			for (int i = tiles.Count - 1; i >= 0; --i) {
				tiles[i].GetComponent<Renderer>().material.SetColor("_Color", tiles[i].GetComponent<Renderer>().material.GetColor("_DefaultColor"));
			}
		}

		public List<Tile> Search (Tile start, Func<Tile, Tile, bool> addTile) {
			var retValue = new List<Tile>();
			retValue.Add(start);

			ClearSearch();
			var checkNext = new Queue<Tile>();
			var checkNow = new Queue<Tile>();

			start.distance = 0;
			checkNow.Enqueue(start);

			while (checkNow.Count > 0) {
				Tile t = checkNow.Dequeue();

				for (int i = 0; i < 4; ++i) {
					Tile next = GetTile(t.pos + dirs[i]);
					if (next == null || next.distance <= t.distance + 1) {
						continue;
					}

					if (addTile(t, next)) {
						next.distance = t.distance + 1;
						next.prev = t;
						checkNext.Enqueue(next);
						retValue.Add(next);
					}
				}

				if (checkNow.Count == 0) {
					SwapReference(ref checkNow, ref checkNext);
				}
			}

			return retValue;
		}

		public Tile GetTile (Point p) {
			return tiles.ContainsKey(p) ? tiles[p] : null;
		}

		private void SwapReference (ref Queue<Tile> a, ref Queue<Tile> b) {
			Queue<Tile> temp = a;
			a = b;
			b = temp;
		}

		private void ClearSearch () {
			foreach (Tile t in tiles.Values) {
				t.prev = null;
				t.distance = int.MaxValue;
			}
		}
	}

}