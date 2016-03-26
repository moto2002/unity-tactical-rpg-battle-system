using System;

namespace Tactical.Grid {

  [Serializable]
  public class GridRange {
    public float min;
    public float max;
  }

  [Serializable]
  public class GridPerimeter {
    public GridRange x;
    public GridRange y;
  }

}
