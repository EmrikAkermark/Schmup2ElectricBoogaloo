using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed, Damage;
    public Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 newDirection)
	{
        direction = newDirection.normalized;
	}

    void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;
        rb.MovePosition(currentPosition + direction * Speed * Time.deltaTime);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log($"We hit something! It was {collision.gameObject.name}");
        IEnemy hitEnemy = collision.gameObject.GetComponent<IEnemy>();
        if (hitEnemy != null)
        {
            hitEnemy.GetHit(Damage);
        }
        gameObject.SetActive(false);
    }

}
