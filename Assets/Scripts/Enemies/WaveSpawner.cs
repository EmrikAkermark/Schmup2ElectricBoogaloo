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

	private void Start()
	{
		SpawnWaveInstant();
	}

	private void SpawnWaveInstant()
	{
		Vector3 spawnPointCoordinates = SpawnPoint.position;
		for (int i = 0; i < AmountToSpawn; i++)
		{
			GameObject spawnedEnemy = Instantiate(Enemy);
			spawnedEnemy.transform.position = spawnPointCoordinates;
			EnemyMovement spawnedEnemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
			spawnedEnemyMovement.EnemyMovementSetup(SubMovement, staggerAmount * i);
		}
	}

	//private IEnumerator SpawnWaveStaggered()
	//{

	//}
}
