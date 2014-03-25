using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int direction = 1;
	public float speed = 20f;
	public int color = 1;
	
	private float _currentRotation;
	private SpriteRenderer _spriteRenderer;
	private Material _playerTrail;

	private Vector4 greenSprite = new Vector4(0.3f,0.9f,0.3f,1f);
	private Vector4 blueSprite = new Vector4(0.3f,0.3f,1f,1f);
	private Vector4 redSprite = new Vector4(1.0f,0.2f,0.0f,1f);

	// Use this for initialization
	void Awake () {
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		SetColor (2);
	}
	public void SetColor(int color_)
	{
		color = color_;
		if (color == 1)
		{
			_spriteRenderer.color = blueSprite;
		} 
		else if (color == 2) 
		{
			_spriteRenderer.color = greenSprite;
		}
		else if (color == 3)
		{
			_spriteRenderer.color = redSprite;
		}

	}
	public void TurnLeft()
	{
		direction++;
		SetColor(1);
	}
	public void TurnRight()
	{
		direction--;
		SetColor(2);
	}
	public void Up()
	{
		direction=2;
	}
	public void Down()
	{
		direction=4;
	}
	public void Left()
	{
		direction=3;
	}
	public void Right()
	{
		direction=1;
	}

	// Update is called once per frame
	void Update () {

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
	
}
