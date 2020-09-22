using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	private PlayerShip playerShip;

	private void Start()
	{
		playerShip = gameObject.GetComponent<PlayerShip>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		IDamagable hitThing = collision.gameObject.GetComponentInParent<IDamagable>();
		if (hitThing != null)
		{

		}
	}

}
