using UnityEngine;
using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Core;

namespace Tactical.Grid.Component {

	public class BoardController : MonoBehaviour {

		[SerializeField] private GameObject marker;
		[SerializeField] private Point markerPos;
		[SerializeField] private Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

		// public Transform marker {
		// 	get {
		// 		if (_marker == null) {
		// 			var instance = Instantiate(tileSelectionIndicatorPrefab);
		// 			_marker = instance.transform;
		// 			_marker.parent = transform;
		// 		}
		// 		return _marker;
		// 	}
		// }
		// private Transform _marker;

		public void UpdateMarker () {
			Tile t = tiles.ContainsKey(markerPos) ? tiles[markerPos] : null;
			marker.transform.localPosition = t != null ? t.center + new Vector3(0f, 0.1f, 0f) : new Vector3(markerPos.x, 0, markerPos.y);
		}

		private void OnEnable () {
			RegisterInputsActions();
		}

		private void OnDisable () {
			DeregisterInputsActions();
		}

		private void Start () {
			var childrenTiles = transform.GetComponentsInChildren<Tile>();
			for (int i = 0; i < childrenTiles.Length; i++) {
				tiles.Add(childrenTiles[i].pos, childrenTiles[i]);
			}
		}

		private void FixedUpdate () {
			UpdateMarker();
		}

		private void MoveUp () {
			markerPos.x += 1;
		}

		private void MoveRight () {
			markerPos.y -= 1;
		}

		private void MoveDown () {
			markerPos.x -= 1;
		}

		private void MoveLeft () {
			markerPos.y += 1;
		}

		/// <summary>
		/// Register the input actions.
		/// </summary>
		private void RegisterInputsActions () {
			PlayerInput.OnButtonUpPressed += MoveUp;
			PlayerInput.OnButtonRightPressed += MoveRight;
			PlayerInput.OnButtonDownPressed += MoveDown;
			PlayerInput.OnButtonLeftPressed += MoveLeft;
		}

		/// <summary>
		/// Deregister the input actions.
		/// </summary>
		private void DeregisterInputsActions () {
			PlayerInput.OnButtonUpPressed -= MoveUp;
			PlayerInput.OnButtonRightPressed -= MoveRight;
			PlayerInput.OnButtonDownPressed -= MoveDown;
			PlayerInput.OnButtonLeftPressed -= MoveLeft;
		}

	}

}
