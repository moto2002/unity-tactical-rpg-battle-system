using UnityEngine;

namespace Tactical.Grid {

	public enum BlendMode {
		Opaque,
		Cutout,
		Fade,
		Transparent
	}

	public class CellOverlay : MonoBehaviour {

		private const string objectName = "Overlay";
		private Color materialColor = new Color(1f, 1f, 1f, 0.1f);
		private GameObject obj;

		private void OnEnable () {
			CreateObject();
		}

		private void OnDisable () {
			DestroyObject();
		}

		private void CreateObject () {
			obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.name = objectName;
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3(0, 0.5f, 0);
			obj.transform.localScale = new Vector3(0.9f, 0.05f, 0.9f);

			var objRenderer = obj.GetComponent<Renderer>();
			objRenderer.material.color = materialColor;
			SetupMaterialWithBlendMode(objRenderer.material, BlendMode.Transparent);
		}

		private void SetupMaterialWithBlendMode (Material material, BlendMode blendMode) {
			switch (blendMode) {
				case BlendMode.Opaque:
					material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
					material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
					material.SetInt("_ZWrite", 1);
					material.DisableKeyword("_ALPHATEST_ON");
					material.DisableKeyword("_ALPHABLEND_ON");
					material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
					material.renderQueue = -1;
					break;
				case BlendMode.Transparent:
					material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
					material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
					material.SetInt("_ZWrite", 0);
					material.DisableKeyword("_ALPHATEST_ON");
					material.DisableKeyword("_ALPHABLEND_ON");
					material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
					material.renderQueue = 3000;
					break;
			}
		}

		private void DestroyObject () {
			Destroy(obj);
		}

	}

}
