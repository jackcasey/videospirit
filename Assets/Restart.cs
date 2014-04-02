using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public string nextScene;

	public void RestartGame() {
		Application.LoadLevel(nextScene);
	}

	void Update() {
		if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
		{
			RestartGame();
			return;
		} else {
			foreach( Touch touch in Input.touches) {
				RestartGame();
				return;
			}
		}
	}
}
