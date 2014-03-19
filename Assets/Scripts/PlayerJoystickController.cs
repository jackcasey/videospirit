using UnityEngine;
using System.Collections;

public class PlayerJoystickController : MonoBehaviour {
	
	public UMJDemo_Joystick MoveJoystick;
	
	private PlayerController playerController;
	
	void Start() {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update () 
	{	
		if ( MoveJoystick.JSK_TouchForce > 20 ) {
			Vector2 direction = MoveJoystick.JSK_DirectionNormalized;
			if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
			{
				if (direction.x > 0)
				{
					playerController.Right();
				}
				else if (direction.x < 0)
				{
					playerController.Left();
				}
			}
			else 
			{
				if (direction.y > 0)
				{
					playerController.Up();
				}
				else if (direction.y < 0)
				{
					playerController.Down();
				}
			}
			
		}
		
	}
}