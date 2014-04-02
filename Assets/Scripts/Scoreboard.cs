using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {

	public GUIText scoreText;
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetGem() {
		score += 5;
		scoreText.text = score.ToString ();
	}

	public void GetGlitch() {
		score += 1;
		scoreText.text = score.ToString ();
	}


	public void Hurt() {
		Debug.Log( "HURT" );
		Invoke ( "GameOver", 1 );
		// TODO die
	}

	public void GameOver() {
		Application.LoadLevel("over");
	}
}
