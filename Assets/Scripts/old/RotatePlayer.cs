using UnityEngine;
using System.Collections;

public class RotatePlayer : MonoBehaviour {
	public bool Left = true;
	private PlayerController playerController;

	
	void Start() {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (guiTexture.HitTest (Input.mousePosition))
			{
				if (Left)
					playerController.TurnLeft();
				else
					playerController.TurnRight();
			}
		} else {
			foreach( Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began) 
				{
					if (guiTexture.HitTest(touch.position))
					{
						if (Left)
							playerController.TurnLeft();
						else
							playerController.TurnRight();
					}
				}
			}
		}
	}
}
