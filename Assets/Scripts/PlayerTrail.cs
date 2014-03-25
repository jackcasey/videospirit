using UnityEngine;
using System.Collections;

public class PlayerTrail : MonoBehaviour {
	
	public GameObject trail;
	private Vector4 greenTrail = new Vector4(0f, 1f, 0f, 0.25f);
	private Vector4 blueTrail = new Vector4(0f, 0f, 1f, 0.45f);

	private Material _playerTrail;

	private PlayerController _playerController;

	// Use this for initialization
	void Start () {
		_playerTrail = trail.GetComponent<ParticleSystem>().renderer.material;
		_playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (_playerController.color == 1)
		{
			_playerTrail.SetColor ("_TintColor", blueTrail);
		} 
		
		else 
		{
			_playerTrail.SetColor ("_TintColor", greenTrail);
		}	
	}
}
