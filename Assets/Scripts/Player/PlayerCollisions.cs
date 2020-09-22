using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	private PlayerShip playerShip;

	private void Start()
	{
		playerShip = gameObject.GetComponent<PlayerShip>();
	}
	//Can't collide, don't know why
	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		IDamagable hitThing = collision.gameObject.GetComponentInParent<IDamagable>();
		if (hitThing != null)
		{
			hitThing.PlayerCollision();
			playerShip.PlayerCollision();
		}
	}

}
