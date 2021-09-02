using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;  //the target to hit
	public float speed = 70f;  //speed of moving
	public GameObject impactEffect; // the impact effect when hitting the target
	public float explosionRadius = 0f;
	public int damage = 50;
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
		transform.LookAt(target);
	}

	void hitTarget() {
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		if (explosionRadius > 0f) {
			explode();
			Destroy(effectIns, 5f);
		}
		else {
			Damege(target);
			Destroy(effectIns, 2f);
		}
		Destroy(gameObject);
	}

	void explode() {
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach(Collider collider in colliders) {
			if(collider.tag == "Enemy") {
				Damege(collider.transform);
            }
        }
    }

	void Damege (Transform enemy) {
		Enemy e = enemy.GetComponent<Enemy>();
		if (e == null)
			return;
		e.takeDamage(damage);
    }

    private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
