using System;
using System.Xml.Serialization;

namespace Tactical.Unit {

	public class JobInformation {
		public string text;
	}

	[Serializable]
	public class JobData {
		[XmlAttribute] public int id;
		[XmlElement]   public string name;
		[XmlElement]   public JobInformation informations;
	}

}
