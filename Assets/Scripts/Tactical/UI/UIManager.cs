using UnityEngine;
using Tactical.UI;

namespace Tactical {

	public class UIManager : MonoBehaviour {

		public static UIManager instance;
		public InformationController informationController;

		private void Awake() {
			// Check if instance already exists
			if (instance == null) {
				// if not, set instance to this
				informationController = transform.FindChild("Information").GetComponent<InformationController>();
				instance = this;
			}
			// If instance already exists and it's not this
			else if (instance != this) {
				// Then destroy this. This enforces our singleton pattern, meaning
				// there can only ever be one instance of a UIManager.
				Destroy(gameObject);
			}

			// Sets this to not be destroyed when reloading scene.
			DontDestroyOnLoad(gameObject);
		}

	}

}
