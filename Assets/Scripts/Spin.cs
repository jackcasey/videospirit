using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float spin_z = 0.0f;
	public float spin_x = 0.0f;
	public float spin_y = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x + Time.deltaTime * spin_x, 
			transform.eulerAngles.y + Time.deltaTime * spin_y, 
			transform.eulerAngles.z + Time.deltaTime * spin_z);
	}
}
