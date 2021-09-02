using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	public int health = 100;
	public int value = 50;
	public GameObject dieEffect;
	private Transform target;
	private int waypointIndex = 0;	  //the target waypoint index

	void Start () {
		target = WayPoints.points[0];	 //first position to move to
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) < 0.2f) {
			getNextPoint();	 //if we have got to the waypoint,we will move the next one
        }
	}

	void getNextPoint() {
		if(waypointIndex >= WayPoints.points.Length - 1) { //we have got to the last waypoints
			Destroy(gameObject);
			EndPath();
			return ;
        }
		waypointIndex++;
		target = WayPoints.points[waypointIndex];
    }

	void EndPath() {
		PlayerStatus.life -= 1;
    }

	public void takeDamage(int damage) {
		health -= damage;
		if(health <= 0) {
			die();
			return;
        }
    }

	void die() {
		PlayerStatus.money += value;
		GameObject effect = (GameObject)Instantiate(dieEffect, this.transform.position, this.transform.rotation);
		Destroy(this.gameObject);
		Destroy(effect, 2.5f);
    }
}
