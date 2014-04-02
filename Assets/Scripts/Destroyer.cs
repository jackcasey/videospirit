using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	private Scoreboard scoreboard;

	// Use this for initialization
	void Awake () {
		GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
		if (gameController)
			scoreboard = gameController.GetComponent<Scoreboard>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			// Game Over!
			return;
		}
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy)
		{
			enemy.Die();
			if (scoreboard)
				scoreboard.GetGlitch ();
		}
	}
}
