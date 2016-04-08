using UnityEngine;
using System.Collections;
using Tactical.Core;
using Tactical.Grid.Component;
using Tactical.Unit.Component;

namespace Tactical.Unit.Component {

	public class FlyMovement : Movement {

		public override IEnumerator Traverse (Tile tile) {

			// Store the distance between the start tile and target tile
			float dist = Mathf.Sqrt(Mathf.Pow(tile.pos.x - unit.tile.pos.x, 2) + Mathf.Pow(tile.pos.y - unit.tile.pos.y, 2));
			unit.Place(tile);

			// Fly high enough not to clip through any ground tiles
			float y = Tile.STEP_HEIGHT * 10;
			Debug.Log(string.Format("y: {0}", y));
			float duration = (y - jumper.position.y) * 0.5f;
			// FIXME: Find out why this isn't working!
			Tweener tweener = jumper.MoveToLocal(new Vector3(0, y, 0), duration, EasingEquations.EaseInOutQuad);
			// while (tweener != null) {
			// 	yield return null;
			// }

			// Turn to face the general direction
			Direction dir;
			Vector3 toTile = (tile.center - transform.position);
			if (Mathf.Abs(toTile.x) > Mathf.Abs(toTile.z)) {
				dir = toTile.x > 0 ? Direction.East : Direction.West;
			} else {
				dir = toTile.z > 0 ? Direction.North : Direction.South;
			}
			yield return StartCoroutine(Turn(dir));

			// Move to the correct position
			duration = dist * 0.5f;
			tweener = transform.MoveTo(tile.center + new Vector3(0, transform.lossyScale.y, 0), duration, EasingEquations.EaseInOutQuad);
			while (tweener != null) {
				yield return null;
			}

			// Land
			duration = (y - tile.center.y) * 0.5f;
			tweener = jumper.MoveToLocal(Vector3.zero, 0.5f, EasingEquations.EaseInOutQuad);
			while (tweener != null) {
				yield return null;
			}
		}

	}

}
