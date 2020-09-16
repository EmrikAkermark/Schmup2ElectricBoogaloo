using System.Collections;
using System.Collections.Generic;
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
	private bool shouldFire, stillSpawning;
	private WaveSpawner self;

	private void Start()
	{
		StartCoroutine(SpawnWaveStaggered());
		self = gameObject.GetComponent<WaveSpawner>();
	}

	

	public void RemoveEnemyFromList(IEnemy enemy)
	{
		spawnedEnemies.Remove(enemy);
	}

	private IEnumerator TellEnemiesToFire()
	{
		while (shouldFire)
		{
			yield return new WaitForSeconds(AvarageTimeBetweenShots + Random.Range(-TimeBetweenShotsSpread, TimeBetweenShotsSpread));
			if (spawnedEnemies.Count == 0 && stillSpawning)
			{
				continue;
			}
			else if(spawnedEnemies.Count == 0 && !stillSpawning)
			{
				shouldFire = false;
			}
			spawnedEnemies[Random.Range(0, spawnedEnemies.Count)].Shoot();
		}
	}

	private IEnumerator SpawnWaveStaggered()
	{
		stillSpawning = true;
		shouldFire = true;
		StartCoroutine(TellEnemiesToFire());
		Vector3 spawnPointCoordinates = SpawnPoint.position;
		for (int i = 0; i < AmountToSpawn; i++)
		{
			GameObject spawnedEnemy = Instantiate(Enemy);
			spawnedEnemy.transform.position = spawnPointCoordinates;
			EnemyMovement spawnedEnemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
			StandardEnemy enemySelf = spawnedEnemy.GetComponent<StandardEnemy>();
			enemySelf.SetupEnemy(self);
			spawnedEnemyMovement.EnemyMovementSetup(SubMovement);
			spawnedEnemies.Add(spawnedEnemy.GetComponent<IEnemy>());
			yield return new WaitForSeconds(staggerAmount);
		}
		stillSpawning = false;
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
			StandardEnemy enemySelf = spawnedEnemy.GetComponent<StandardEnemy>();
			enemySelf.SetupEnemy(self);
		}
		StartCoroutine(TellEnemiesToFire());
	}
}
