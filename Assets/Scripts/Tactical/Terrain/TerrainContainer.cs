 using System.Collections.Generic;
 using System.Xml.Serialization;
 using System.IO;

namespace Tactical.Data {

	[XmlRoot("cellTerrainCollection")]
	public class CellTerrainCollection
	{
		[XmlArray("cellTerrains")]
		[XmlArrayItem("cellTerrain")]
		public List<CellTerrainData> cellTerrains = new List<CellTerrainData>();

		public static CellTerrainCollection Load (string path) {
			var serializer = new XmlSerializer(typeof(CellTerrainCollection));

			using(var stream = new FileStream(path, FileMode.Open)) {
				return serializer.Deserialize(stream) as CellTerrainCollection;
			}
		}
	}

}
