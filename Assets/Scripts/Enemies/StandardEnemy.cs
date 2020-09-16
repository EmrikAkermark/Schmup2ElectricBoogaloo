using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour, IEnemy
{
	public Transform FiringPoint;
	public GameObject Projectile;
	private WaveSpawner mySpawner;
	public float damage, health, speed;

	public void GetHit(float damage)
	{
		TakeDamage(damage);
	}

	public void Shoot()
	{
		GameObject projectile = Instantiate(Projectile, FiringPoint.position, FiringPoint.rotation);
		Projectile firedProjectile = projectile.GetComponent<Projectile>();
		firedProjectile.SetupBullet(FiringPoint.rotation.eulerAngles.z, damage, speed);
	}

	public void SetupEnemy(WaveSpawner spawner)
	{
		mySpawner = spawner;
	}

	private void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			var OwnShit = gameObject.GetComponent<IEnemy>();
			mySpawner.RemoveEnemyFromList(OwnShit);
			gameObject.SetActive(false);
		}
	}

}
