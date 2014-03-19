using UnityEngine;
using System.Collections;

public class CameraSpin : MonoBehaviour {
	public float spin = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x, 
			transform.eulerAngles.y, 
			transform.eulerAngles.z + Time.deltaTime * spin);
	}
}
