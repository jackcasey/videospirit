using UnityEngine;
using System.Collections;

public class OnScreenControls : MonoBehaviour {	
	public GUIElement leftButton;
	public GUIElement rightButton;

	private PlayerController playerController;

	void Start() {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void RegisterPush( Vector2 position )
	{
		if (rightButton.HitTest(position))
			playerController.TurnRight();
		if (leftButton.HitTest(position))
			playerController.TurnLeft();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0))
		{
			RegisterPush(Input.mousePosition);
		} else {
			foreach( Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began) 
				{
					RegisterPush(touch.position);
				}
			}
		}
	}
}
