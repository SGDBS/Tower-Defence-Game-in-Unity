﻿using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	[Header("Attributes")]
	private Transform target;  //the target to lock on and shoot
	public string EnemyTag = "Enemy";
	public Transform partToRotation;  //the position to rotate the top of turret

	[Header("Unity Setup Fields")]
	public float range = 15f;
	public float turnSpeed = 15f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public GameObject bulletPrefab;
	public Transform firePoint;   //the position to instantiate	the bullet

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
        }
		else {
			target = null;
        }
    }
	
	
	void Update () {
		if (target == null)
			return;
		LockOnTarget();
		if(fireCountdown <= 0f) {
			Shoot();
			fireCountdown = 1f / fireRate;
        }
		fireCountdown -= Time.deltaTime;
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
