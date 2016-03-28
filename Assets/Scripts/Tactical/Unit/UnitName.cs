using UnityEngine;

namespace Tactical.Unit {

	[DisallowMultipleComponent]
	public class UnitName : MonoBehaviour {

		public string firstName;
		public string lastName;

		/// <summary>
		/// Get the full name of the unit.
		/// </summary>
		///
		/// <returns>The full name of the unit.</returns>
		public string GetFullName () {
			return firstName + " " + lastName;
		}

	}

}
