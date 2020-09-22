using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed, Damage, Lifetime = 3f;
    public Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	}

	private IEnumerator WaitAndDie()
	{
		yield return new WaitForSeconds(Lifetime);
		Destroy(gameObject);
	}

	public void SetupBullet(float newDirection, float damage, float speed, float lifetime = 0f)
	{
        direction.x = -Mathf.Sin(Mathf.Deg2Rad * newDirection);
        direction.y = Mathf.Cos(Mathf.Deg2Rad * newDirection);
        Damage = damage;
        Speed = speed;
        if(lifetime >= 0f)
		{
            Lifetime = lifetime;
		}
        StartCoroutine(WaitAndDie());
    }

    void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;
        rb.MovePosition(currentPosition + direction * Speed * Time.deltaTime);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        IDamagable hitThing = collision.gameObject.GetComponentInParent<IDamagable>();
        if (hitThing != null)
        {
            hitThing.GetHit(Damage);
        }
        Destroy(gameObject);
    }

}
