using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour, IEnemy
{
    public float Health;
	public Transform FiringPoint;
	public GameObject Projectile;

	public void GetHit(float damage)
	{
		TakeDamage(damage);
	}

	public void Shoot()
	{
		Debug.Log($"{gameObject.name} sa Pang!");
	}

	private void TakeDamage(float damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			gameObject.SetActive(false);
		}
	}

}
