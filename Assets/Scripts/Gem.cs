using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	public int color = 1;
	public Material blueMaterial;
	public Material greenMaterial;

	public ParticleSystem effect;

	private Scoreboard scoreboard;

	// Use this for initialization
	void Awake () {
		GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
		if (gameController)
			scoreboard = gameController.GetComponent<Scoreboard>();
	}
	void Start() {
		if (color == 0)
			color = Random.Range(1,3);

		if (color == 1)
		{
			renderer.material = blueMaterial;
		} else if (color == 2) 
		{
			renderer.material = greenMaterial;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			// if we're the right colour then yay points
			if (player.color == color){
				Collect();
				if (scoreboard)
					scoreboard.GetGem ();
			} else {
				Destroy(other.gameObject);
				Collect();
				if (scoreboard)
					scoreboard.Hurt();
			}
			// otherwise die!
		}
	}

	public void Collect() {
		ParticleSystem instance = GameObject.Instantiate(effect, transform.position, transform.rotation) as ParticleSystem;
		Destroy (instance.gameObject, 2.0f);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
