using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int direction = 1;
	public float speed = 20f;
	public int color = 1;

	public GameObject trail;
	private Vector4 greenTrail = new Vector4(0f, 1f, 0f, 0.25f);
	private Vector4 blueTrail = new Vector4(0f, 0f, 1f, 0.45f);
	private Vector4 greenSprite = new Vector4(0.3f,0.9f,0.3f,1f);
	private Vector4 blueSprite = new Vector4(0.3f,0.3f,1f,1f);



	private float _currentRotation;
	private SpriteRenderer _spriteRenderer;
	private Material _playerTrail;

	// Use this for initialization
	void Start () {
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		_playerTrail = trail.GetComponent<ParticleSystem>().renderer.material;
		SetColor (2);
	}
	public void SetColor(int color_)
	{
		color = color_;
		if (color == 1)
		{
			_spriteRenderer.color = blueSprite;
			_playerTrail.SetColor ("_TintColor", blueTrail);
		} 

		else 
		{
			_spriteRenderer.color = greenSprite;
			_playerTrail.SetColor ("_TintColor", greenTrail);
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

		if (Input.GetKeyDown("left"))
			TurnLeft ();
		else if (Input.GetKeyDown("right"))
			TurnRight ();

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
