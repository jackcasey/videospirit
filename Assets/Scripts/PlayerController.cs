using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int direction = 1;
	public float speed = 20f;

	private float _currentRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("left"))
			direction++;
		else if (Input.GetKeyDown("right"))
			direction--;

		if (direction > 4)
			direction -= 4;
		else if (direction < 1)
			direction += 4;

		GetComponent<Animator>().SetBool("moving", direction > 0);
	}

	void FixedUpdate() {
		rigidbody2D.velocity = Vector3.zero;

		if (direction > 0) 
		{
			transform.rotation = Quaternion.Euler(0f, 0f, (direction-1)*90f);
			switch(direction)
			{
			case 1:
				rigidbody2D.AddForce ( speed * Vector2.right );
				break;
			case 2:
				rigidbody2D.AddForce ( speed * Vector2.up );
				break;
			case 3:
				rigidbody2D.AddForce ( speed * -Vector2.right );
				break;
			case 4:
				rigidbody2D.AddForce ( speed * -Vector2.up );
				break;
			}
		} 
		else 
		{
			//rigidbody.velocity = Vector3.zero;
		}
	}

	void OldUpdate () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (h > 0 && direction != 3)
		{
			direction = 1;
		}
		else if (h < 0 && direction != 1)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 180f);
			direction = 3;
		}
		else if (v < 0 && direction != 2)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 270f);
			direction = 4;
		}
		else if (v > 0 && direction != 4)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 90f);
			direction = 2;
		} 
//		else 
//		{
//			direction = 0;
//		}
		if (direction > 0)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, (direction-1)*90f);
		}
		GetComponent<Animator>().SetBool("moving", direction > 0);
	}
}
