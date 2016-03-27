 using System.Collections.Generic;
 using System.Xml.Serialization;
 using System.IO;
 using Tactical.Unit;

namespace Tactical.Unit {

	[XmlRoot("jobCollection")]
	public class JobCollection {

		[XmlArray("jobs")]
		[XmlArrayItem("job")]
		public List<JobData> jobs = new List<JobData>();

		public static JobCollection Load (string path) {
			var serializer = new XmlSerializer(typeof(JobCollection));

			using(var stream = new FileStream(path, FileMode.Open)) {
				return serializer.Deserialize(stream) as JobCollection;
			}
		}
	}

}
