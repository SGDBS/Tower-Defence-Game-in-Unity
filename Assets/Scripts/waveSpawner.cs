using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public Text waveCountdownText;
	public float timeBetweenWavers = 5f;

	private float countdown = 2f;
	public static int waveIndex = 0;

    void Start() {
		waveIndex = 0;  
    }

    void Update () {
		if(countdown <= 0f) {
			StartCoroutine(spawnWave());
			countdown = timeBetweenWavers;
        }
		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator spawnWave() {
		waveIndex++;
		PlayerStatus.rounds++;
		for (int i = 0; i < Mathf.Min(waveIndex, 10); i++) {
			spawnEnemy();
			yield return new WaitForSeconds(0.5f);
        }
    }

	void spawnEnemy() {
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
