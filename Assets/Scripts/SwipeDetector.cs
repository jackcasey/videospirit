using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour {
		
	// Values to set:	
	public float comfortZone = 3.0f;
	public float minSwipeDist = 14.0f;
	public float maxSwipeTime = 1.0f;

	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;

	public enum SwipeDirection {	
		None,
		Left,		
		Right
	}

	public SwipeDirection lastSwipe = SwipeDetector.SwipeDirection.None;
	public float lastSwipeTime;

	void Left()
	{
		GetComponent<PlayerController>().TurnLeft();
	}

	void Right()
	{
		GetComponent<PlayerController>().TurnRight();
	}

	void Update() 	
	{
		if (Input.touchCount > 0)		
		{
			Touch touch = Input.touches[0];

			switch (touch.phase) 
			{
			case TouchPhase.Began:
				lastSwipe = SwipeDetector.SwipeDirection.None;
				lastSwipeTime = 0;
				couldBeSwipe = true;
				startPos = touch.position;
				startTime = Time.time;
				break;

			case TouchPhase.Moved:
				float dist = Mathf.Abs(touch.position.x - startPos.x);
				float strayed = dist / Mathf.Abs(touch.position.y - startPos.y);
				if (strayed < comfortZone && dist > 20.0f) 
				{
					Debug.Log("Not a swipe. Swipe strayed" + strayed + 
					          "amount.");
					couldBeSwipe = false;
				}
				break;
				
			case TouchPhase.Ended:
				if (couldBeSwipe)
				{
					float swipeTime = Time.time - startTime;
					float swipeDist = touch.position.x - startPos.x;

					if ((swipeTime < maxSwipeTime) && (Mathf.Abs(swipeDist) > minSwipeDist)) 
					{
						// It's a swiiiiiiiiiiiipe!
						float swipeValue = Mathf.Sign(swipeDist);
						// If the swipe direction is positive, it was an upward swipe.
						if (swipeValue > 0)
						{
							lastSwipe = SwipeDetector.SwipeDirection.Right;
							Right();
						}
						else if (swipeValue < 0)
						{
							lastSwipe = SwipeDetector.SwipeDirection.Left;
							Left();
						}
						
						// Set the time the last swipe occured, useful for other scripts to check:
						lastSwipeTime = Time.time;
						Debug.Log("Found a swipe!  Direction: " + lastSwipe);
					}
				}
				break;
			}
		}
	}
}