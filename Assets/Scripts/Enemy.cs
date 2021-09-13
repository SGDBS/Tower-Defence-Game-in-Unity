using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;
	public float startHealth = 100;
	private float health;
	public int value = 50;
	public GameObject dieEffect;


	[Header("Unity Stuff")]
	public Image healthbar;

    void Start() {
		startHealth += waveSpawner.waveIndex * 30;
		startHealth = Mathf.Min(startHealth, 300f);
		startSpeed += waveSpawner.waveIndex * 0.5f;
		startSpeed = Mathf.Min(20f, startSpeed);
		health = startHealth;
		speed = startSpeed;
    }

    public void takeDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			die();
			return;
        }
		healthbar.fillAmount = health / startHealth;
    }

	public void changeSpeed(float pct) {
		speed = (1 - pct) * startSpeed;
	}

	void die() {
		PlayerStatus.money += value;
		GameObject effect = (GameObject)Instantiate(dieEffect, this.transform.position, this.transform.rotation);
		Destroy(this.gameObject);
		Destroy(effect, 2.5f);
    }
}
