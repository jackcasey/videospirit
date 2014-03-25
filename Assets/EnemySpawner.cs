using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject spawnArea;
	public GameObject enemyPrefab;
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
		float x = Random.Range(spawnArea.transform.position.x - spawnArea.transform.localScale.x/2, spawnArea.transform.position.x - spawnArea.transform.localScale.x/2);
		float z = Random.Range(spawnArea.transform.position.z - spawnArea.transform.localScale.z/2, spawnArea.transform.position.z - spawnArea.transform.localScale.z/2);

		Instantiate (enemyPrefab, new Vector3(x,0,z), Quaternion.Euler(Vector3.zero));
	}
}
