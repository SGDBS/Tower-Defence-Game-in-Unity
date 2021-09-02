using UnityEngine;

public class BasicBulled : MonoBehaviour
{

	private Transform target;
	public float speed = 70f;
	public GameObject impactEffect;
	public void seek(Transform _target) {
		target = _target;
	}

	void Update() {
		if (target == null) {
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {
			hitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

	void hitTarget() {
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 1f);
		Destroy(gameObject);
	}
}