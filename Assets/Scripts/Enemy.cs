using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;
	public double health = 100;
	public int value = 50;
	public GameObject dieEffect;

    void Start() {
		health += waveSpawner.waveIndex * 30;
    }

    public void takeDamage(double damage) {
		health -= damage;
		if(health <= 0) {
			die();
			return;
        }
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
