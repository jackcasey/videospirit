using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			// Game Over!
			return;
		}
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		if (enemy)
			enemy.Die();
	}
}
