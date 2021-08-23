using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
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
			return ;
        }
		waypointIndex++;
		target = WayPoints.points[waypointIndex];
    }
}
