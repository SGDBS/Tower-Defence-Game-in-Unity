using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public Text waveCountdownText;
	public float timeBetweenWavers = 5f;

	private float countdown = 2f;
	private int waveIndex = 0;

	
	void Update () {
		if(countdown <= 0f) {
			StartCoroutine(spawnWave());
			countdown = timeBetweenWavers;
        }
		countdown -= Time.deltaTime;
		waveCountdownText.text = "Next Wave :" + Mathf.Round(countdown).ToString();
	}

	IEnumerator spawnWave() {
		waveIndex++;
		for (int i = 0; i < waveIndex; i++) {
			spawnEnemy();
			yield return new WaitForSeconds(0.5f);
        }
    }

	void spawnEnemy() {
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
