using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Common;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int AmountToSpawn;
    public float staggerAmount;
	public GameObject Enemy;
	public Transform SpawnPoint;
	public EnemySubMovements SubMovement;
	public float AvarageTimeBetweenShots, TimeBetweenShotsSpread;

	private List<IEnemy> spawnedEnemies = new List<IEnemy>();
	private bool shouldFire;

	private void Start()
	{
		SpawnWaveInstant();
	}

	private void SpawnWaveInstant()
	{
		shouldFire = true;
		Vector3 spawnPointCoordinates = SpawnPoint.position;
		for (int i = 0; i < AmountToSpawn; i++)
		{
			GameObject spawnedEnemy = Instantiate(Enemy);
			spawnedEnemy.transform.position = spawnPointCoordinates;
			EnemyMovement spawnedEnemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
			spawnedEnemyMovement.EnemyMovementSetup(SubMovement, staggerAmount * i);
			spawnedEnemies.Add(spawnedEnemy.GetComponent<IEnemy>());
		}
		StartCoroutine(TellEnemiesToFire());
	}

	private IEnumerator TellEnemiesToFire()
	{
		while (shouldFire)
		{
			spawnedEnemies[Random.Range(0, spawnedEnemies.Count)].Shoot();
			yield return new WaitForSeconds(AvarageTimeBetweenShots + Random.Range(-TimeBetweenShotsSpread, TimeBetweenShotsSpread));
		}
	}

	//private IEnumerator SpawnWaveStaggered()
	//{

	//}
}
