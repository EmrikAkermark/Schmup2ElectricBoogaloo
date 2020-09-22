using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform ModelTransform;
    public float EnemySpeed = 1;
    public EnemySubMovements SubMovement;
    private float time;
    private bool hasSubMovement;

    private void FixedUpdate()
    {
        Move();
        if(hasSubMovement)
		{
            SubMove();
        }
    }

	private void Start()
	{
		if(SubMovement != null)
		{
            hasSubMovement = true;
		}
        else
		{
            hasSubMovement = false;
		}
	}

	private void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.y -= EnemySpeed * Time.fixedDeltaTime;
        transform.position = currentPosition;
    }

    public void EnemyMovementSetup(EnemySubMovements subMovement, float timestagger = 0f)
    {
        SubMovement = subMovement;
        time = timestagger;
    }

    private void SubMove()
   {
        time += Time.fixedDeltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = SubMovement.SubWidth * Mathf.Cos(time * SubMovement.SubHorizontalMod * Mathf.PI);
        newPosition.y = SubMovement.SubHeight * Mathf.Sin(time * SubMovement.SubVerticalMod * Mathf.PI);
        ModelTransform.localPosition = newPosition;
   }
}
