using UnityEngine;

namespace Tactical.Grid {

  public class GridCell {

    public string name;
    public Vector3 position;
    public GameObject obj;

    public GridCell (Vector3 vectorPosition) {
      name = "Cell_" + position.x + "_" + position.y;
      position = vectorPosition;
    }
  }

}
