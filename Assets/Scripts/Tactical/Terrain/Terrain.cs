using UnityEngine;

namespace Tactical.Terrain {

  public enum TerrainType {
    Dirt,
    Water
  }

  public class Terrain : MonoBehaviour {

    public TerrainType type;

    // TODO: Store the terrain types in games data (xml) and load them when the
    // game loads.
    private static Color GetTerrainTypeColor (TerrainType type) {
      switch (type) {
        case TerrainType.Dirt:
          return new Color(0.4f, 0.2f, 0f, 1f);
        case TerrainType.Water:
          return new Color(0.2f, 0.2f, 0.6f, 1f);
        default:
          return Color.black;
      }
    }

    private void Update () {
      GetComponent<Renderer>().material.color = GetTerrainTypeColor(type);
    }

  }

}
