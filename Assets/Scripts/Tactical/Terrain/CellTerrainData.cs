using UnityEngine;
using System;
using System.Xml.Serialization;

namespace Tactical.Data {

	public enum TerrainType {
		[XmlEnumAttribute("1")] Dirt,
		[XmlEnumAttribute("2")] Water
	}

	[Serializable]
	public class CellTerrainData {

		[XmlAttribute]
		public int id;
		public string name;

		[XmlAttribute]
		public TerrainType type;

		public string material;

		// [XmlIgnore]
		// public Color color;

		// [XmlElement(ElementName = "color")]
		// public string color_XmlSurrogate {
		// 	get { return ColorConverter.ColorToHex(color); }
		// 	set { color = ColorConverter.HexToColor(value); }
		// }

	}

}
