using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	private Transform target;  //the target to lock on and shoot
	private Enemy targetEnemy;
	[Header("Attributes")]
	public string EnemyTag = "Enemy";
	public Transform partToRotation;  //the position to rotate the top of turret

	[Header("Unity Setup Fields")]
	public float range = 15f;
	public float turnSpeed = 15f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public Transform firePoint;   //the position to instantiate	the bullet
	[Header("use bullet")]
	public GameObject bulletPrefab;
	[Header("use laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer;
	public ParticleSystem laserEffect;
	public Light lightEffect;
	public float damagePerSecond = 50;
	public float slowPct = 0.5f;

	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // call function "UpdateTarget" per 0.5 second
	}

    void UpdateTarget() {  // find the target to lock on
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach(GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(shortestDistance > distanceToEnemy) {
				nearestEnemy = enemy;
				shortestDistance = distanceToEnemy;
            }
        }

		if(nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
			targetEnemy = target.GetComponent<Enemy>();
        }
		else {
			target = null;
        }
    }
	
	
	void Update () {
		fireCountdown -= Time.deltaTime;
		if (target == null) {
			if (useLaser && lineRenderer.enabled) {
				lineRenderer.enabled = false;
				laserEffect.Stop();
				lightEffect.enabled = false;
			}
			return;
		}
		LockOnTarget();
		if(useLaser) {
			LaserShoot();
			return;
        }
		if(fireCountdown <= 0f) {
			Shoot();
			fireCountdown = 1f / fireRate;
        }
	}


	void LaserShoot() {
		if (lineRenderer.enabled == false) {
			lineRenderer.enabled = true;
			laserEffect.Play();
			lightEffect.enabled = true;
		}
		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);

		targetEnemy.takeDamage(damagePerSecond * Time.deltaTime);
		targetEnemy.changeSpeed(slowPct);

		Vector3 dir = firePoint.position - target.position;
		laserEffect.transform.position = target.position + dir.normalized;
		laserEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

	void Shoot() {
		GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGo.GetComponent<Bullet>();
		bullet.seek(target);
	}

	void LockOnTarget() {
		Vector3 dir = target.transform.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotation.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

	void OnDrawGizmosSelected() {  // show the range of fire in the Scene(not in game)
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, range);
    }
}
