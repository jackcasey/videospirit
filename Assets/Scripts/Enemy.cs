using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public ParticleSystem effect;

	void Start() {
		GetComponent<PlayerController>().SetColor(3);
	}

	public void Die() {
		ParticleSystem instance = GameObject.Instantiate(effect, transform.position, transform.rotation) as ParticleSystem;
		Destroy (instance.gameObject, 2.0f);
		Destroy (gameObject);
	}
}
