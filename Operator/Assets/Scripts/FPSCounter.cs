using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {
	string label = "";

	void Start() {
		StartCoroutine(UpdateCounter());
	}

	IEnumerator UpdateCounter() {
		while (true) {
			label = "FPS :" + (Mathf.Round(1 / Time.unscaledDeltaTime));
			yield return new WaitForSeconds(0.2f);
		}
	}

	void OnGUI() {
		GUIStyle guiStyle = new GUIStyle();
		guiStyle.fontSize = 70;
		GUI.Label(new Rect(0, 0, 300, 100), label, guiStyle);
	}
}
