using UnityEngine;
using System.Collections;

public class PlayerKeyboardController : MonoBehaviour {
	
	public GameObject player;
	
	private PlayerController playerController;
	
	void Start() {
		playerController = player.GetComponent<PlayerController>();
	}
	
	void Update () 
	{	
		if (Input.GetKeyDown("left"))
		{
			playerController.TurnLeft();
		}
		else if (Input.GetKeyDown("right"))
		{
			playerController.TurnRight();
		}
	}
}
