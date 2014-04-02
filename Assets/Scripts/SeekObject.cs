using UnityEngine;
using System.Collections;

public class SeekObject : MonoBehaviour {

	public GameObject target;

	private PlayerController _playerController;
	private float _lastChange;
	// Use this for initialization
	void Start () {
		_playerController = GetComponent<PlayerController>();
		_lastChange = Time.time;
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
			return;

		Vector3 delta = (target.transform.position - transform.position);

		float deltaAngle = -Mathf.Atan2(delta.x, delta.y) * Mathf.Rad2Deg + 90 + 45;
		if(deltaAngle < 0)
			deltaAngle += 360;


		int direction = (int)(deltaAngle/90)+1;

		if (direction != _playerController.direction && _lastChange < Time.time - 0.25)
		{
			_playerController.direction = direction;
			_lastChange = Time.time;
		}
	}
}
