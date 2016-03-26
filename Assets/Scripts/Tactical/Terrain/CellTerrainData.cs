using System;
using System.Xml.Serialization;

namespace Tactical.Data {

	public enum TerrainType {
		[XmlEnumAttribute("1")] Solid,
		[XmlEnumAttribute("2")] Liquid
	}

	public class CellInformation {
		public string text;
	}

	[Serializable]
	public class CellTerrainData {

		[XmlAttribute] public int id;
		[XmlAttribute] public TerrainType type;
		[XmlElement]   public string name;
		[XmlElement]   public string material;
		[XmlElement]   public CellInformation informations;

	}

}
