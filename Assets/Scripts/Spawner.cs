using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnArea;
	public GameObject prefab;
	public float spawnInterval = 2.0f;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(ContinueSpawning());
	}
	
	IEnumerator ContinueSpawning()
	{
		while (true) {
			yield return new WaitForSeconds(spawnInterval);
			SpawnEnemy();
		}
	}

	void SpawnEnemy() {
		float x = Random.Range(spawnArea.transform.position.x - spawnArea.transform.localScale.x*5, spawnArea.transform.position.x + spawnArea.transform.localScale.x*5);
		float y = Random.Range(spawnArea.transform.position.y - spawnArea.transform.localScale.y*2.5f, spawnArea.transform.position.y + spawnArea.transform.localScale.y*2.5f);
		Instantiate (prefab, new Vector3(x,y,0), Quaternion.Euler(Vector3.zero));
	}
}
