using UnityEngine;

public class Bulled : MonoBehaviour {

	private Transform target;  //the target to hit
	public float speed = 70f;  //speed of moving
	public GameObject impactEffect;	// the impact effect when hitting the target
	public void seek(Transform _target) {  // using for initialize the target
		target = _target;
    }

	void Update () {
		if(target == null) {  // if the bulled do not have a target to hit
			Destroy(gameObject);  //we need to destroy it
			return;
        }

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame) {  //The bulled will hit the target next frame
			hitTarget();
			return;
        }
															
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

	void hitTarget() {
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 2f);
		Destroy(gameObject);
    }
}
