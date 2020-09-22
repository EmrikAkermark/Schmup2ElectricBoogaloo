using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeleter : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		IDamagable thingOutOfBounds = collision.gameObject.GetComponentInParent<IDamagable>();
		if(thingOutOfBounds != null)
		{
			thingOutOfBounds.Delete();
		}
	}
}
