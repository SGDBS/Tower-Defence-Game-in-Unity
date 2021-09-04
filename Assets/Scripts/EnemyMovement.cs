using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
	private Transform target;
	private int waypointIndex = 0;    //the target waypoint index
	private Enemy enemy;
	void Start() {
		target = WayPoints.points[0];    //first position to move to
        enemy = GetComponent<Enemy>();
		enemy.speed = enemy.startSpeed;
    }

    // Update is called once per frame
    void Update() {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) < 0.2f) {
			getNextPoint();  //if we have got to the waypoint,we will move the next one
		}
		enemy.speed = enemy.startSpeed;
	}

	void getNextPoint() {
		if (waypointIndex >= WayPoints.points.Length - 1) { //we have got to the last waypoints
			Destroy(gameObject);
			EndPath();
			return;
		}
		waypointIndex++;
		target = WayPoints.points[waypointIndex];
	}

	void EndPath() {
		PlayerStatus.life -= 1;
	}
}
