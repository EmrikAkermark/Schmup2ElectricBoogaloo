using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour, IEnemy, IDamagable
{
	public Transform FiringPoint;
	public GameObject Projectile;
	private WaveSpawner mySpawner;
	public float Damage, Health, ProjectileSpeed, ProjectileLifeTime;

	public void GetHit(float damage)
	{
		TakeDamage(damage);
	}

	public void Shoot()
	{
		GameObject projectile = Instantiate(Projectile, FiringPoint.position, FiringPoint.rotation);
		Projectile firedProjectile = projectile.GetComponent<Projectile>();
		firedProjectile.SetupBullet(FiringPoint.rotation.eulerAngles.z, Damage, ProjectileSpeed, ProjectileLifeTime);
	}

	public void SetupEnemy(WaveSpawner spawner)
	{
		mySpawner = spawner;
	}

	private void TakeDamage(float damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Die();
		}
	}

	public void PlayerCollision()
	{
		Die();
	}

	private void Die()
	{
		var OwnShit = gameObject.GetComponent<IEnemy>();
		mySpawner.RemoveEnemyFromList(OwnShit);
		Destroy(gameObject);
	}

	public void Delete()
	{
		Die();
	}
}
