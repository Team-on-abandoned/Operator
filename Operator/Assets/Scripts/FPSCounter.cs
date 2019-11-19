using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {
	string label = "";

	void Start() {
		GUI.depth = 2;
	}

	private void Update() {
		label = "FPS :" + (Mathf.Round(1 / Time.unscaledDeltaTime));
	}

	void OnGUI() {
		GUIStyle guiStyle = new GUIStyle();
		guiStyle.fontSize = 70;
		GUI.Label(new Rect(0, 0, 300, 100), label, guiStyle);
	}
}
