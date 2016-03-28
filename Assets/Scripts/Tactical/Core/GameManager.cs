using UnityEngine;
using Tactical.Data;
using Tactical.Battle;

namespace Tactical.Core {

	public class GameManager : MonoBehaviour {

		public static GameManager instance;
		public string firstSceneName = "Level1";
		[HideInInspector] public BattleManager battleManager;

		private DataManager dataManager;

		private void Awake() {
			// Check if instance already exists
			if (instance == null) {
				// if not, set instance to this
				instance = this;
			}
			// If instance already exists and it's not this
			else if (instance != this) {
				// Then destroy this. This enforces our singleton pattern, meaning
				// there can only ever be one instance of a GameManager.
				Destroy(gameObject);
			}

      // Sets this to not be destroyed when reloading scene.
      DontDestroyOnLoad(gameObject);

      // Get the data manager and load all the data.
			dataManager = GetComponent<DataManager>();
			dataManager.LoadAll();

      // Get the combat manager.
			battleManager = GetComponent<BattleManager>();

			UnityEngine.SceneManagement.SceneManager.LoadScene(firstSceneName);
		}

	}

}
