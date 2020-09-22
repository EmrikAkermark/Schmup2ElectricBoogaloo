using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
	public int Weapon;
	public float ScrollSpeed;

	private void FixedUpdate()
	{
		Vector2 currentPosition = transform.position;
		currentPosition.y -= ScrollSpeed * Time.fixedDeltaTime;
		transform.position = currentPosition;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerWeapons playerWeapon = collision.gameObject.GetComponentInParent<PlayerWeapons>();
		playerWeapon.PickedUpWeapon(Weapon);
		Destroy(gameObject);
	}
}
